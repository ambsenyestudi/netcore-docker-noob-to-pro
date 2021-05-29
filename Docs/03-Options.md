# Options

In order to have a configurable environment we need to take advantage on environment variables, this is conveniently solved by the [Options pattern](https://docs.microsoft.com/en-us/dotnet/core/extensions/options-library-authors#:~:text=The%20options%20pattern%20enables%20consumers%20of%20your%20library,removes%20the%20burden%20of%20manually%20parsing%20string%20values.)

To implement such a pattern we need:
1. [options package](https://www.nuget.org/packages/Microsoft.Extensions.Options)
2. [options configuration extensions](https://www.nuget.org/packages/Microsoft.Extensions.Options.ConfigurationExtensions)
4. An appsettings.json file at the root folder (remember to change its properties Copy to Output Directory to **Copy if newer**)
5. A poco object to hold the configuration
6. Write the poco object as a section in the json file

Just to have an organize project we will add an application class library and an infrastructure class library.

This will make us modify our docker file to add the new project at the restore step.
```
# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/job-host/*.csproj ./src/job-host/
COPY src/application/*.csproj ./src/application/
COPY src/infrastructure/*.csproj ./src/infrastructure/
RUN dotnet restore
```
