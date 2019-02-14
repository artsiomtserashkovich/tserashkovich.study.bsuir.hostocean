FROM microsoft/dotnet:2.2-sdk AS build

WORKDIR /
COPY /HostOcean.Api/HostOcean.Api.csproj /src/HostOcean.Api/
COPY /HostOcean.Persistence/HostOcean.Persistence.csproj /src/HostOcean.Persistence/
COPY /HostOcean.Domain/HostOcean.Domain.csproj /src/HostOcean.Domain/

RUN dotnet restore /src/HostOcean.Api/HostOcean.Api.csproj

COPY . /src
RUN dotnet build /src/HostOcean.Api/HostOcean.Api.csproj -c Release

#Restore test
COPY /HostOcean.Tests/HostOcean.IntegrationTests/HostOcean.IntegrationTests.csproj /src/HostOcean.Tests/HostOcean.IntegrationTests/

RUN dotnet restore /src//HostOcean.Tests/HostOcean.IntegrationTests/HostOcean.IntegrationTests.csproj

WORKDIR /src/HostOcean.Tests/HostOcean.IntegrationTests/

ENTRYPOINT ["dotnet", "test"]