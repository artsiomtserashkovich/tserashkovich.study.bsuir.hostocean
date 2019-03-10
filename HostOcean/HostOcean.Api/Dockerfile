FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk as builder

WORKDIR /

COPY /HostOcean.Api/HostOcean.Api.csproj /src/HostOcean.Api/
COPY /HostOcean.Infrastructure/HostOcean.Infrastructure.csproj /src/HostOcean.Infrastructure/
COPY /HostOcean.Persistence/HostOcean.Persistence.csproj /src/HostOcean.Persistence/
COPY /HostOcean.Domain/HostOcean.Domain.csproj /src/HostOcean.Domain/
COPY /HostOcean.Application/HostOcean.Application.csproj /src/HostOcean.Application/

RUN dotnet restore /src/HostOcean.Api/HostOcean.Api.csproj

COPY . /src

RUN dotnet build /src/HostOcean.Api/HostOcean.Api.csproj -c Release
RUN dotnet publish /src/HostOcean.Api/HostOcean.Api.csproj -c Release -o /app

FROM runtime AS final
WORKDIR /app
COPY --from=builder /app .
ENTRYPOINT ["dotnet", "HostOcean.Api.dll"]

