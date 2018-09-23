var target = Argument("target", "Default");

using System;
using System.Diagnostics;

// Variables
var configuration = "Release";
var fullFrameworkTarget = "net461";
var netCoreTarget = "netcoreapp2.0";

var royaleNugetOutput = "./artifacts/Pekka.RoyaleApi.Client";
var clashRoyaleNugetOutput = "./artifacts/Pekka.ClashRoyaleApi.Client";

string royaleApiPath = "src/Pekka.RoyaleApi.Client";
string clashRoyaleApiPath = "src/Pekka.ClashRoyaleApi.Client";
string royaleApiProj = $"Pekka.RoyaleApi.Client.csproj";
string clashRoyaleApiProj = $"Pekka.ClashRoyaleApi.Client.csproj";

Task("Default")
    .IsDependentOn("Test");

Task("Compile")
    .Description("Builds all the projects in the solution")
    .Does(() =>
    {
        StartProcess("dotnet", new ProcessSettings {
            Arguments = "--info"
        });

        DotNetCoreBuildSettings settings = new DotNetCoreBuildSettings();
        settings.NoRestore = true;
        settings.Configuration = configuration;

        var projects = GetFiles("src/**/*.csproj");

        Information($"Restoring projects");
        foreach(var project in projects)
        {
            DotNetCoreRestore(project.ToString());
        }

        Information($"Building projects");
        foreach(var project in projects)
        {
            DotNetCoreBuild(project.ToString(), settings);
        } 
    });

Task("Test")
    .Description("Run Tests")
    .IsDependentOn("Compile")
    .Does(() =>
    {

    });

Task("Nuget-Pack")
    .Description("Publish to nuget")
    .Does(() =>
    {
        var settings = new DotNetCorePackSettings();
        settings.Configuration = configuration;

        settings.OutputDirectory = royaleNugetOutput;
        settings.WorkingDirectory = royaleApiPath;
        DotNetCorePack(royaleApiProj, settings);

        settings.OutputDirectory = clashRoyaleNugetOutput;
        settings.WorkingDirectory = clashRoyaleApiPath;
        DotNetCorePack(clashRoyaleApiProj, settings);
    });

RunTarget(target);