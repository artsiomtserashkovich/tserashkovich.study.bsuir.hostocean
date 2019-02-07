FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

COPY ../../*.sln .
COPY ../../HostOcean.Tests/HostOcean.IntegrationTests/*.csproj ./HostOcean.Tests/HostOcean.IntegrationTests/
COPY ../../HostOcean.Api/*.csproj ./HostOcean.Api/
RUN dotnet restore

COPY ../../ .

WORKDIR /src/HostOcean.Api
RUN dotnet build 

FROM base AS testrunner
WORKDIR /src/HostOcean.Tests/HostOcean.IntegrationTests/

ENTRYPOINT ["dotnet", "test", "--logger:trx"]
