ARG REGISTRY_NAME
FROM ${REGISTRY_NAME}baseimages/microsoft/aspnetcore-runtime:linux-2.1 AS base
WORKDIR /app
ARG REGISTRY_NAME
ENV REGISTRY_NAME=${REGISTRY_NAME}

FROM ${REGISTRY_NAME}baseimages/microsoft/dotnet-sdk:linux-2.1 AS build
WORKDIR /src
COPY src/QuoteService/QuoteService.csproj src/QuoteService/
COPY NuGet.Config .
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
ARG A_CONNECTIONSTRING
ENV CONNECTIONSTRING=${A_CONNECTIONSTRING}
ENV VERSION=0.0.10
ENTRYPOINT ["dotnet", "QuoteService.dll"]
