FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /
COPY /HostOcean.Api/HostOcean.Api.csproj /src/HostOcean.Api/
COPY /HostOcean.Persistence/HostOcean.Persistence.csproj /src/HostOcean.Persistence/
COPY /HostOcean.Domain/HostOcean.Domain.csproj /src/HostOcean.Domain/

RUN dotnet restore /src/HostOcean.Api/HostOcean.Api.csproj

COPY . /src
RUN dotnet build /src/HostOcean.Api/HostOcean.Api.csproj -c Release

FROM build AS publish
RUN dotnet publish /src/HostOcean.Api/HostOcean.Api.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "HostOcean.Api.dll"]