#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://*:8080
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ApiGatewayService/ApiGatewayService.csproj", "ApiGatewayService/"]
RUN dotnet restore "ApiGatewayService/ApiGatewayService.csproj"
COPY . .
WORKDIR "/src/ApiGatewayService"
RUN dotnet build "ApiGatewayService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiGatewayService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiGatewayService.dll"]
