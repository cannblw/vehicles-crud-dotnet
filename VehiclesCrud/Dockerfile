FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VehiclesCrud/VehiclesCrud.csproj", "VehiclesCrud/"]
RUN dotnet restore "VehiclesCrud/VehiclesCrud.csproj"
COPY . .
WORKDIR "/src/VehiclesCrud"
RUN dotnet build "VehiclesCrud.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehiclesCrud.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehiclesCrud.dll"]
