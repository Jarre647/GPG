#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update \
    && apt-get install curl -y \
	&& curl -sL https://deb.nodesource.com/setup_12.x | bash \
	&& apt-get install nodejs -y \
	&& node -v \
	&& npm -v

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebVue/WebVue.csproj", "WebVue/"]
RUN dotnet restore "WebVue/WebVue.csproj"
COPY . .
WORKDIR "/src/WebVue"
RUN dotnet build "WebVue.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebVue.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebVue.dll"]