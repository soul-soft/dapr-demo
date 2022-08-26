#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api2/Api2.csproj", "Api2/"]
RUN dotnet restore "Api2/Api2.csproj"
COPY . .
WORKDIR "/src/Api2"
RUN dotnet build "Api2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Api2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api2.dll"]