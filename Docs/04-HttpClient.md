# Adding httpclient to our host

To make calls through the internet netcore has a standard class called HttpClient, we will add such class to through our dependency injection.

For this very purpose we need the [Microsoft.Extensions.Http](https://www.nuget.org/packages/Microsoft.Extensions.Http)

We will get rid of greeting an use an [jsonplaceholder api](https://jsonplaceholder.typicode.com/) to test our httpClient.

# Noisy logs
Right now we have a pretty cumbersome log to read, so let's add a logging node to our settings.json to supress life time events.
```
"Logging": {
  "LogLevel": {
    "Default": "Information",
    // Avoid logging lifetime events
    "Microsoft.Hosting.Lifetime": "Warning"
  }
},
```