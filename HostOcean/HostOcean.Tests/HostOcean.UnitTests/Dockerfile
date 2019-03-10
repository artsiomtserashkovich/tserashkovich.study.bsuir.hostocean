FROM hostocean.api.image:latest as image 

WORKDIR /

COPY /HostOcean.Tests/HostOcean.UnitTests /src/HostOcean.Tests/HostOcean.UnitTests

FROM image AS testrunner
WORKDIR /src/HostOcean.Tests/HostOcean.UnitTests/

ENTRYPOINT ["dotnet", "test"]