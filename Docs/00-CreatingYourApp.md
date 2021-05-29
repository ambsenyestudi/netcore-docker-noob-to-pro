# Creating your application

## Setting up your project

### Solution
I'm starting by setting up an unusual folder structure in may project. My solution will stay at the root of the project. So, let's create our solution.
´´´
dotnet new sln -n MyBackgroundProcess
´´´
### Create your console app and add it to the solution
To avoid mixing concepts, all my projects will be inside the *src* folder. Each project will live have their own folder.
```
├───Docs
└───src
    └───host
```

Let's create and add our console app to the project:
1. Create your console app at your **src host** subfolder
2. Add your console app at your existing solution


```
dotnet new console -n MyBackgroundProcess -o src\host\
dotnet sln add .\src\host\MyBackroundProces.Host.csproj
``` 
 ### Checking everything

 To make sure that all steps were successful, let's:
 1. Build our app
 2. Run our app specifying a project
> Since we don't have sln and csproj files in the same folder is mandatory to run with the **-p flag** specifying the project or else we will get an error saying *Couldn't find a project to run*
 ```
dotnet build
dotnet run -p .\src\host\MyBackroundProces.Host.csproj
 ```

 ### Making sure we can run our project

 To make absolutely sure that everything workds we will:
 1. Publish our app
 2. Run our app
> Remember to use **-o flag** to specify the *output folder* for tidiness
´´´
dotnet publish -o publish
dotnet .\MyBackroundProces.Host.dll
´´´



