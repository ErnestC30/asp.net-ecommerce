### Ecommerce Store Features

TODO:
Unit testing?? (did product service, could do others)

Try and move context in controllers to service layer (categories, ...)
API versioning
Rate limiting

Stripe integration? (implement as interface that can take other payment types..?)

- docs @ https://docs.stripe.com/payments/about

Search bar feature (could try elastic search or postgres tsvector)

Emailing process(?)

## Pages:

- user login / registration page
- landing page
- category products page
- product detail page
- checkout page
- payment pages
- user dashboard (past orders, add / change address)
- admin panel

## Features:

- manage different models
  - products, categories, orders, cart, user, address
- pagination
- checkout integration
- emails (registration, order made, order completed)

# Authentication:

- store user data as JWT inside a HttpOnly cookie
- browser will store cookie and pass this on every request for authentication
- refresh token is used to create new JWT on expiry

# Cart:

- persistent storage for logged in users
- each user can only have one cart at a time
- when the cart is checked out and an order is paid, then the cart will be cleared
- frontend can retrieve this data and store it locally

# Payment:

- payment processors: stripe
- can checkout as user or anonymous guest
- product prices are snapshotted to Order
  - need to decide when in the order creation process (right before payment selection? or address entering?)
  - will need to prevent old orders from being checked out (otherwise user could hold the order for long time)

# Docker support:

- .env file to load secrets onto docker compose file
- docker compose injects variables to db connection string in appsettings.json file
