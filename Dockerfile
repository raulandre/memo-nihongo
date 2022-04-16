FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

WORKDIR /app
COPY . .
RUN dotnet publish Memo.Api -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
CMD ASPNETCORE_ENVIRONMENT=Production ASPNETCORE_URLS=http://*:$PORT dotnet Memo.Api.dll