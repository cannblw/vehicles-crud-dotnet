FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VehiclesTest/VehiclesTest.csproj", "VehiclesTest/"]
RUN dotnet restore "VehiclesTest/VehiclesTest.csproj"
COPY . .
WORKDIR "/src/VehiclesTest"
RUN dotnet build "VehiclesTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehiclesTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehiclesTest.dll"]
