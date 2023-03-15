FROM  node:14 AS client
WORKDIR /app/ClientApp

COPY ./ClientApp/package*.json ./

RUN npm install

COPY ./ClientApp ./

RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY ["Catalog Online.csproj", "./"]


RUN dotnet restore "./Catalog Online.csproj"

COPY . .

RUN dotnet build "./Catalog Online.csproj" -c Release -o /app/build


FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .
COPY --from=client /app/ClientApp/dist ./ClientApp/dist

EXPOSE 5001
ENTRYPOINT ["dotnet", "Catalog Online.dll"]