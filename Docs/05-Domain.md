# Domain
Now we will create a new class lib named domain that will hold our domain classes. Since now mapping is mandatory we will add [Automapper](https://www.nuget.org/packages/AutoMapper/) as a dependency.
## Single responsibility
Just for the sake of single responsablity we will create:
* Logging  decorator for Post service
* Deserialization service for infrastructure
* Mapper service 
* Profiles and converters for Automapper

## Dockerfile
This new project will make us add another line for package restoring phase.
```
# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/job-host/*.csproj ./src/job-host/
COPY src/application/*.csproj ./src/application/
COPY src/domain/*.csproj ./src/domain/
COPY src/infrastructure/*.csproj ./src/infrastructure/
RUN dotnet restore
```