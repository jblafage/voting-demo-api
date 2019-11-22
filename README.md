# Introduction 
API portal used by voting app (as a demo) that store data into a postgresql database. It uses dotnet core (sdk 2.1).

# Getting Started

**Make sure you have dotnet core SDK (2.1 or later) installed on your machine**

```bash
# clone repo
git clone https://faurecia-cloud@dev.azure.com/faurecia-cloud/Demo/_git/api_voting_demo

# change directory to your local repository
cd api_voting_demo

# install dependencies
dotnet restore
```
# Build

```bash
# clean previous build
dotnet clean

# build
dotnet build
```
## Build a Docker image

```shell
# Build image
docker build --rm \
    --file "Dockerfile" \
    --build-arg http_proxy="http://euedcunil0200.edc.eu.corp:7070" \
    --build-arg https_proxy="http://euedcunil0200.edc.eu.corp:7070" \
    -t voting-demo-api:latest  .
```


# Configuration

You can set connection string to your postgresql database by different ways:
1. by modifying *appsettings.json* 
2. by setting environment variable *ConnectionStrings__VotingDb*

Connection string format sample:
Host=\[db-host\];Port=\[db-port\];Database=\[db-name\];Username=\[db-user\];Password=\[db-pwd\]

# Run Migrations

This project uses Entity Framework Core with a code first approach. To apply migrations on your database, run the following command:

```bash
# Run migrations
dotnet ef database update
```

# Run application

```bash
# Launch application
dotnet run
```
Then open a web browser and go to https://localhost:5001 or http://localhost:5000
By default you access to swagger UI.

# Build and run as a container

A docker file is available at root of the project and allow you to build a docker image (based on Linux OS) and to execute your application through a container.

# Contribute

```bash
# Add new migrations
dotnet ef migrations add [Name Of Your Migration]
```