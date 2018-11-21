FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 3039
EXPOSE 44311

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["api_voting_demo/api_voting_demo.csproj", "api_voting_demo/"]
RUN dotnet restore "api_voting_demo/api_voting_demo.csproj"
COPY . .
WORKDIR "/src/api_voting_demo"
RUN dotnet build "api_voting_demo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api_voting_demo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api_voting_demo.dll"]