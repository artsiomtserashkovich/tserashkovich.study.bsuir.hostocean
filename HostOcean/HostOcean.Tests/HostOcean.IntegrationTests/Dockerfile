FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src

COPY /HostOcean/*.sln .
COPY /HostOcean/HostOcean.Tests/HostOcean.IntegrationTests/*.csproj ./HostOcean.Tests/HostOcean.IntegrationTests/
COPY /HostOcean/HostOcean.Api/*.csproj ./HostOcean.Api/
RUN dotnet restore

COPY /HostOcean .

WORKDIR /src/HostOcean.Api
RUN dotnet build 

FROM build AS testrunner
WORKDIR /src/HostOcean.Tests/HostOcean.IntegrationTests/

ENTRYPOINT ["dotnet", "test","-v n"]
