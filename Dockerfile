FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /ArtsofteMain/ClientApp
EXPOSE 80

FROM microsoft/aspnetcore-build AS build
WORKDIR /

FROM base
COPY /ArtsofteTestWebApp.sln .
RUN dotnet restore .
COPY . .
RUN dotnet build ArtsofteTestWebApp.sln -c Release -o out 

FROM build AS publish
WORKDIR /ArtsofteTestWebApp
RUN dotnet publish -c Release -o out 

FROM base AS final 
WORKDIR /ArtsofteMain/ClientApp
COPY --from=publish /ArtsofteMain/ClientApp .
ENTRYPOINT [ "dotnet", "ArtsofteMain.dll" ]
