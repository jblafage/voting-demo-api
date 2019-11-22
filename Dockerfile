FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 3039
EXPOSE 44311

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src

# Copy csproj and restore as distinct layer
COPY api_voting_demo.csproj ./
RUN dotnet restore "api_voting_demo.csproj"

# Copy everything else and build
COPY . ./
RUN dotnet build "api_voting_demo.csproj" -c Release

FROM build AS publish
RUN dotnet publish "api_voting_demo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api_voting_demo.dll"]