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
1. [Setup container and restore dependencies](#dockerfile-setup-container-and-restore-dependencies)
2. [Publishing our app](#dockerfile-how-to-publish-your-app)
3. [Setup entry point for our container](#dockerfile-setup-an-entry-point-for-our-container)

Once we have a good dockerfile you can [Build and run your docker container](#build-and-run-a-docker-container)

### Dockerfile: Setup container and restore dependencies

To setup a container to gather all information needed for publishing your application, you need the following:
1. Use a docker image containing dotnet sdk (for building purposes)
2. Setting up a destination folder for the build (in our case source)
3. Copy solution files and project files to the recently created folder for nuget package restoring purposes.
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

Now that we have solved every needed dependency, we need to take the following actions:
1. After restoring all nugget packages, copy everything we need to compile (remember .dockerignore? this is where it serves its purpose).
2. Publish our application
> Remember to use **-o flag** to specify the *output folder* for tidiness.
```
# copy the rest of the file so we can run the publish command
COPY . ./
RUN dotnet publish -c Release -o publish
```

### Dockerfile: setup an entry point for our container

To keep our images lean we need a smaller image than the sdk. They all can be found at [microsoft docker image](https://hub.docker.com/_/microsoft-dotnet).
> Usually for aspnet core we use aspnet image but since we are using a console app we will use runtime

Therefore, we will execute the following actions:
1. Use a container smaller image 
2. Go back to our original working directory
3. Copy the contents of the folder where we published our application in to the containers root
4. Setting up the entry point

```
# genereate a runtime image (why? runtime image is smaller that sdk image)
FROM mcr.microsoft.com/dotnet/runtime:5.0 
WORKDIR /source

# copy all file form the folder where we published our porject at the root folder
COPY --from=build-env /source/publish ./

# set up the entry point just as we did with dotnet .\MyBackroundProces.Host.dll
ENTRYPOINT ["dotnet", "MyBackroundProces.Host.dll"]
```
> When defining entry point we are doing something similar to what we did int the previous when [making sure we can run our project](00-CreatingYourApp.md#making-sure-we-can-run-our-project)

### Build and run a docker container

Docker build [as seen before](#docker-file) is a fairly straightforward command. The tricky part comes when you want to run an image with no tag.
>Save yourself some troubles tagging all your images (using the -t flag) so you can easily run them afterwards.

Following the former advice, it would go something like the following:
```
docker build -t my-background-process .
docker run my-background-process
 ```