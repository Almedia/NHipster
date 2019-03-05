FROM microsoft/dotnet:2.2-sdk

WORKDIR /app

COPY . .

RUN dotnet restore

RUN dotnet publish ./Hipster.Api/Hipster.Api.csproj -o /publish/

WORKDIR /publish

ENTRYPOINT ["dotnet", "Hipster.Api.dll"]