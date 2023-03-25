#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Presentation/Onix.WebApi/Onix.WebApi.csproj", "src/Presentation/Onix.WebApi/"]
RUN dotnet restore "src/Presentation/Onix.WebApi/Onix.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Onix.WebApi"
RUN dotnet build "Onix.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onix.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onix.WebApi.dll"]
#
#FROM mcr.microsoft.com/dotnet/core/sdk:7.0
#WORKDIR /app
#COPY . .
#RUN dotnet restore
#RUN dotnet publish Onix.WebApi.csproj -c Release -o out
#WORKDIR out
#ENV ASPNETCORE_URLS="http://*:1453"
#ENTRYPOINT ["dotnet", "Onix.WebApi.dll"]