FROM hostocean.api.image:latest as image 

WORKDIR /

COPY /HostOcean.Tests/HostOcean.IntegrationTests /src/HostOcean.Tests/HostOcean.IntegrationTests

FROM image AS testrunner
WORKDIR /src/HostOcean.Tests/HostOcean.IntegrationTests/

ENTRYPOINT ["dotnet", "test"]
