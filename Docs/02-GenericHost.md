# Generic host

Our little hello world application must be turn into a Process that runs to completions, so just for the fun of it let's setup a generic host like the one at [microsoft docs](https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host)

> **Warning** we started callin our application MyBackgroundProcess.Host this creates some name clashing with generic host so we changed the folder name to job-host

## Creating the host

Our up will startup say hello world and end it's live cycle. Get [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting) and you be all set.

Then create a class that extends implement IHostedService for instance **Worker.cs**. Inside said class you only need to register the app live cycle that the dependency injection engine already provides you with and log **hello world!**. Easy right?