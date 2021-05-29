# Dockerfile and dockerignore

This time let us start in reverse. Since when using docker we want to avoid oversizing our image we must write a *.dockerignore* file.
How to write a docker ignore file:
1. At the root folder of your source (where our solution lives):
2. Create a file called *.dockerignore*
3. Inside this fill you must specify what folder to ignore
> In our particular case since we have many subfolders we need to use the ** wildcard to avoid coping them.

I added the publish folder that is where we did our publishing test to check that every change we make is ok
```
/bin
/obj
/publish
**/bin
**/obj
```

## Docker file

Docker file is what docker uses when you execute the following command:
> Don’t forget the period (.) at the end that means execute in the current directory
```
docker build .
```
The .dockerfile purpose boils down to we saw at the previous lesson:
> publish your application at a particular folder and run it.

## The docker file recipe 

To build a successful docker file we need to take the following actions:
1. [Setup container and restore dependencies]("#dockerfile-setup-container-and-restore-dependencies")
2. [Publishing our app](#dockerfile-how-to-publish-your-app)

### Dockerfile: Setup container and restore dependencies

To setup a container to gather all information need for publish your application you need the following:
1. Use a docker image containing dotnet sdk (for building purposes)
2. Setting up a destination folder for the build (in our case source)
3. Copy solution files and project files to the recently created folder for nuget package restoring purposes.
4. After restoring all nugget packages, copy everything we need to compile (remember .dockerignore? this is where it serves its purpose).

```
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/host/*.csproj ./src/host/
RUN dotnet restore
```
### Dockerfile: how to publish your app

