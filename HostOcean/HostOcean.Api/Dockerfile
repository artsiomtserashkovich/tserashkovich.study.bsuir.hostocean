FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["HostOcean.Api/HostOcean.Api.csproj", "HostOcean.Api/"]
COPY ["HostOcean.Persistence/HostOcean.Persistence.csproj", "HostOcean.Persistence/"]
COPY ["HostOcean.Domain/HostOcean.Domain.csproj", "HostOcean.Domain/"]
RUN dotnet restore "HostOcean.Api/HostOcean.Api.csproj"
COPY . .
WORKDIR "/src/HostOcean.Api"
RUN dotnet build "HostOcean.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "HostOcean.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HostOcean.Api.dll"]