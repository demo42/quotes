FROM microsoft/dotnet-nightly:2.1-aspnetcore-runtime AS base
WORKDIR /app
FROM microsoft/dotnet-nightly:2.1-sdk AS build
WORKDIR /src
COPY src/QuoteService/QuoteService.csproj src/QuoteService/
COPY NuGet.Config .
RUN dotnet restore src/QuoteService/QuoteService.csproj
COPY . .
WORKDIR /src/src/QuoteService
RUN dotnet build QuoteService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish QuoteService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ARG A_CONNECTIONSTRING
ENV CONNECTIONSTRING=${A_CONNECTIONSTRING}
RUN echo Env ConnStr=$CONNECTIONSTRING 
RUN echo BuildArg A_CONNECTIONSTRING=${A_CONNECTIONSTRING}
ENTRYPOINT ["dotnet", "QuoteService.dll"]
