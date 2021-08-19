#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/Services/Library/UnitTest.Library/UnitTest.Library.csproj", "src/Services/Library/UnitTest.Library/"]
COPY ["src/Services/Library/Application.Library.Implementation/Application.Library.Implementation.csproj", "src/Services/Library/Application.Library.Implementation/"]
COPY ["src/Utilities/Utilities.Configuration/Utilities.Configuration.csproj", "src/Utilities/Utilities.Configuration/"]
COPY ["src/Services/Library/Infrastructure.Library.Implementation/Infrastructure.Library.Implementation.csproj", "src/Services/Library/Infrastructure.Library.Implementation/"]
COPY ["src/Services/Library/Domain.Library/Domain.Library.csproj", "src/Services/Library/Domain.Library/"]
COPY ["src/Services/Library/Application.Product.Interfaces/Application.Library.Interfaces.csproj", "src/Services/Library/Application.Product.Interfaces/"]
COPY ["src/Services/Library/Domain.Library.Configuration.Dtos/Domain.Library.Configuration.Dtos.csproj", "src/Services/Library/Domain.Library.Configuration.Dtos/"]
COPY ["src/Services/Library/DistributedServices.Library/DistributedServices.Library.csproj", "src/Services/Library/DistributedServices.Library/"]
RUN dotnet restore "src/Services/Library/UnitTest.Library/UnitTest.Library.csproj"
COPY . .
WORKDIR "/src/src/Services/Library/UnitTest.Library"
RUN dotnet build "UnitTest.Library.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UnitTest.Library.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UnitTest.Library.dll"]