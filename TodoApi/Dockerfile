FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY *.sln .
COPY TodoApi/*.csproj TodoApi/
COPY TodoApi.Tests/*.csproj TodoApi.Tests/

RUN dotnet restore --disable-parallel

COPY . .

WORKDIR /src/TodoApi

RUN dotnet build -c Release --no-restore

WORKDIR /src/TodoApi.Tests
RUN dotnet test --no-build --verbosity normal

WORKDIR /src/TodoApi
RUN dotnet publish -c Release -o /app/publish --no-build

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "TodoApi.dll"]
