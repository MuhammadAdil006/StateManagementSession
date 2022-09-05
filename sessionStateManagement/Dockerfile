#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY ["sessionStateManagement/sessionStateManagement.csproj", "sessionStateManagement/"]
RUN dotnet restore "sessionStateManagement/sessionStateManagement.csproj"
COPY . .
WORKDIR "/src/sessionStateManagement"
RUN dotnet build "sessionStateManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "sessionStateManagement.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "sessionStateManagement.dll"]