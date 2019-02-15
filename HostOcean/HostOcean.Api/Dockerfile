FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM hostocean.api.image:latest as image 

FROM base AS final
WORKDIR /app
COPY --from=image /app .
ENTRYPOINT ["dotnet", "HostOcean.Api.dll"]

