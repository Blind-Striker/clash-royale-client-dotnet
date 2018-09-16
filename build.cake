var target = Argument("target", "Default");

using System;
using System.Diagnostics;

// Variables
var configuration = "Release";
var fullFrameworkTarget = "net461";
var netCoreTarget = "netcoreapp2.0";

Task("Default")
    .IsDependentOn("Compile");

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

Task("Nuget")
    .Description("Publish to nuget")
    .Does(() =>
    {

    });

RunTarget(target);