# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/job-host/*.csproj ./src/job-host/
COPY src/application/*.csproj ./src/application/
COPY src/domain/*.csproj ./src/domain/
COPY src/infrastructure/*.csproj ./src/infrastructure/
RUN dotnet restore

# copy the rest of the file so we can run the publish command
COPY . ./
RUN dotnet publish -c Release -o publish

# genereate a runtime image (why? runtime image is smaller that sdk image)
FROM mcr.microsoft.com/dotnet/runtime:5.0 
WORKDIR /source

# copy all file form the folder where we published our porject at the root folder
COPY --from=build-env /source/publish ./

# set up the entry point just as we did with dotnet .\MyBackroundProces.Host.dll
ENTRYPOINT ["dotnet", "MyBackgroundProces.JobHost.dll"]