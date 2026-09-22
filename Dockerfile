FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["VehiclesApp/VehiclesApp.csproj", "VehiclesApp/"]
RUN dotnet restore "VehiclesApp/VehiclesApp.csproj"

COPY . .
WORKDIR "/src/VehiclesApp"
RUN dotnet build "VehiclesApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehiclesApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS=8080
COPY --from=publish /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "VehiclesApp.dll"]