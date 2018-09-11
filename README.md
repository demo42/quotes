# Demo 42 - Quotes API

## Building the image locally
```sh
docker build -t demo42/quotes-api:dev  -f ./src/QuoteService/Dockerfile --build-arg demo42.azurecr.io .
```

## Building the image with ACR Build
```sh
az acr build -t demo42/quotes-api:{{.Build.ID}} -f ./src/QuoteService/Dockerfile --build-arg REGISTRY_NAME=demo42.azurecr.io .
```