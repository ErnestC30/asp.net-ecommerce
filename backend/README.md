dotnet run --launch-profile https

Generate controller for model
dotnet aspnet-codegenerator controller -name CategoriesController -m Category -dc ApiDbContext -outDir Controllers -api
