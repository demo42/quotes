ARG REGISTRY_NAME=demo42.azurecr.io/
FROM ${REGISTRY_NAME}baseimages/microsoft/aspnetcore/runtime:linux-2.1.10 AS base
WORKDIR /app
ARG REGISTRY_NAME
ENV REGISTRY_NAME=${REGISTRY_NAME}
ENV LEAKY_CONNECTIONSTRING="a value you don't want to leak"

FROM ${REGISTRY_NAME}baseimages/microsoft/dotnet/sdk:linux-2.1.10 AS build
WORKDIR /src
COPY src/QuoteService/QuoteService.csproj src/QuoteService/
RUN dotnet restore src/QuoteService/QuoteService.csproj
COPY . .
WORKDIR /src/src/QuoteService
RUN dotnet build QuoteService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish QuoteService.csproj -c Release -o /app

#FROM build AS test

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENV VERSION=0.0.25
ENTRYPOINT ["dotnet", "QuoteService.dll"]
