FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY . .

RUN dotnet restore "api_voting_demo.csproj" && \
    dotnet build "api_voting_demo.csproj" -c Release && \
    dotnet publish "api_voting_demo.csproj" -c Release -o /app

#==== RUNTIME ====#
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.16 AS runtime

LABEL maintainers="TEAM-Cloud Ninjas <TEAM-cloudninjas@faurecia.onmicrosoft.com>"

EXPOSE 8080

ARG APP_USER=faurvoting
ENV ASPNETCORE_URLS "http://*:8080"
ENV UseHttpsRedirection="false"

RUN adduser -D ${APP_USER}

WORKDIR /app

COPY --from=build --chown=${APP_USER}:${APP_USER} /app .

USER ${APP_USER}

ENTRYPOINT ["dotnet", "api_voting_demo.dll"]
