If you are an owner of the NuGet package, you can deploy to NuGet with a command that looks like this:

```text
nuget push Rhythm.Umbraco.Ditto.Archetype.1.2.0.nupkg your-nuget-key-here -Source https://api.nuget.org/v3/index.json
```

Just replace the version number in the filename and the API key (it's your API key you see when you log into your NuGet.org account).

Note that the file gets generated in the "dist" folder when you build the solution.
I find it's easiest to simply move the `nupkg` file to the `"src/packages/NuGet.CommandLine.4.7.0/tools"` folder and run the command line from there.

Also, be sure to increment the version number before creating new releases.