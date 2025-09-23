using backend.Interfaces;
using backend.Models;
using backend.Models.OrderDto;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace backend.Services;

public class OrderService : IOrderService
{
    private readonly ApiDbContext _context;

    public OrderService(ApiDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a pending order for the start of checkout process.
    /// </summary>
    /// <param name="orderCreateDto"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<OrderViewDto> CreateOrder(OrderCreateDto orderCreateDto, string? userId)
    {
        /* This should be called after user passes in billing + address details, along with the cart data
         * The order will be created as 'Pending' status and prices are locked in. 
         * If order is 'Pending' for too long, then prices should be refetched?
         * Keep track of products whose price has changed (prices from cart do not match the db prices)
        */

        // should return some dto to frontend - this includes checking price changes and displaying if price has changed
        // may want to use some form of idempotency so that duplicate orders cannot be created

        string refId = GenerateRefId();
        var pendingStatusId = await GetPendingStatusId();

        var order = new Order
        {
            UserId = userId,
            RefId = refId,
            OrderStatusId = pendingStatusId,
            FirstName = orderCreateDto.FirstName,
            LastName = orderCreateDto.LastName,
            Email = orderCreateDto.Email,
            Amount = 0,
            PaymentProvider = orderCreateDto.PaymentProvider,
            BillingAddress = new Address
            {
                Line1 = orderCreateDto.BillingLine1,
                Line2 = orderCreateDto.BillingLine2,
                Country = orderCreateDto.BillingCountry,
                City = orderCreateDto.BillingCity,
                PostalCode = orderCreateDto.BillingPostalCode,
            },
            ShippingAddress = new Address
            {
                Line1 = orderCreateDto.ShippingLine1,
                Line2 = orderCreateDto.ShippingLine2,
                Country = orderCreateDto.ShippingCountry,
                City = orderCreateDto.ShippingCity,
                PostalCode = orderCreateDto.ShippingPostalCode,
            }
        };

        // Add Line Items to Order
        var lineItemsDto = await PrepareLineItems(orderCreateDto.LineItems);
        AddLineItems(order, lineItemsDto);

        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        return OrderToOrderViewDto(order);
    }

    public async Task<ICollection<OrderStatusViewDto>> GetOrderStatusOptions()
    {
        var orderStatusesDto = await _context.OrderStatuses.Select(os => OrderStatustoOrderStatusViewDto(os)).ToListAsync();
        return orderStatusesDto;
    }

    private string GenerateRefId()
    {
        return Guid.NewGuid().ToString("N");
    }

    private async Task<long> GetPendingStatusId()
    {
        // should cache value of id
        var orderStatus = await _context.OrderStatuses.FirstOrDefaultAsync(os => os.Slug == "pending") ?? throw new Exception("Could not find order status with \"pending\" status ");
        return orderStatus.Id;
    }

    /// <summary>
    /// Fetch the most recent data for each product and update line items if needed.
    /// </summary>
    /// <param name="lineItemsDto"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Product could not be found.</exception>
    private async Task<ICollection<OrderLineItemCreateDto>> PrepareLineItems(ICollection<OrderLineItemCreateDto> lineItemsDto)
    {
        var products = await _context.Products.Where(p => lineItemsDto.Select(li => li.ProductUuid).ToList().Contains(p.Uuid.ToString())).ToListAsync();

        foreach (var li in lineItemsDto)
        {
            var product = products.FirstOrDefault(p => p.Uuid.ToString() == li.ProductUuid) ?? throw new Exception("Product could not be found");
            li.Name = product.Name;
            li.Price = product.Price;
            li.DiscountPrice = product.DiscountPrice;
        }

        return lineItemsDto;
    }

    private void AddLineItems(Order order, ICollection<OrderLineItemCreateDto> lineItemsDto)
    {

        foreach (var lineItem in lineItemsDto)
        {
            order.AddLineItem(lineItem.ProductUuid, lineItem.Name, lineItem.Price, lineItem.DiscountPrice, lineItem.Quantity);
        }
    }

    private static OrderViewDto OrderToOrderViewDto(Order order)
    {
        return new OrderViewDto
        {
            LineItems = order.LineItems.Select(li => LineItemToOrderLineItemViewDto(li)).ToList(),
            FirstName = order.FirstName,
            LastName = order.LastName,
            Email = order.Email,
            PaymentProvider = order.PaymentProvider,
            BillingLine1 = order.BillingAddress.Line1,
            BillingLine2 = order.BillingAddress.Line2,
            BillingCountry = order.BillingAddress.Country,
            BillingCity = order.BillingAddress.City,
            BillingPostalCode = order.BillingAddress.PostalCode,
            ShippingLine1 = order.ShippingAddress.Line1,
            ShippingLine2 = order.ShippingAddress.Line2,
            ShippingCountry = order.ShippingAddress.Country,
            ShippingCity = order.ShippingAddress.City,
            ShippingPostalCode = order.ShippingAddress.PostalCode
        };
    }

    private static OrderLineItemViewDto LineItemToOrderLineItemViewDto(OrderLineItem lineItem)
    {
        return new OrderLineItemViewDto
        {
            ProductUuid = lineItem.ProductUuid,
            Name = lineItem.Name,
            Price = lineItem.Price,
            DiscountPrice = lineItem.DiscountPrice,
            Quantity = lineItem.Quantity,
        };
    }

    private static OrderStatusViewDto OrderStatustoOrderStatusViewDto(OrderStatus status)
    {
        return new OrderStatusViewDto
        {
            Name = status.Name,
            Slug = status.Slug,
        };
    }
}
