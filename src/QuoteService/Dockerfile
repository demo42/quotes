ARG REGISTRY_NAME
FROM ${REGISTRY_NAME}baseimages/microsoft/dotnet/aspnetcore-runtime:2.1-nightly AS base
WORKDIR /app

FROM ${REGISTRY_NAME}baseimages/microsoft/dotnet/sdk:2.1-nightly AS build
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
ENV VERSION=0.0.8
ENTRYPOINT ["dotnet", "QuoteService.dll"]
