dotnet run --launch-profile https

Generate controller for model
dotnet aspnet-codegenerator controller -name CategoriesController -m Category -dc ApiDbContext -outDir Controllers -api


visual studio requires .sln file to open as project type

add csproj to overall project sln (EcommerceBackend.sln) for discovery process (for tests...)
> dotnet new sln -n MyApp <.csproj link>

