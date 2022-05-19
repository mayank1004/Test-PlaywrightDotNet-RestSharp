# Test Automation Project using .Net

## Status
![Build](https://github.com/mayank1004/PlaywrightDotNet/actions/workflows/maven.yml/badge.svg)

---

## Testing app:

[Conduit App](https://superlative-fox-61a6f8.netlify.app)

----

## Description:

- This is skeleton work E2E Test automation project built using [Playwright for .Net](https://playwright.dev/dotnet/)
- This also has skeleton work for the API testing using [RestSharp](https://restsharp.dev/)

---
[Test case folder](./Tests/ConduitTests)

---

## Installation Guide:

### Pre-requisite:
- It required [.Net core 3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1) installed

Once you have .Net Core 3.1 installed, and cloned the repo, follow the below instruction to run tests thru CLI:

### Steps to execute tests:
1. Run `dotnet build` from the root of the repo

2. Run `pwsh bin\Debug\netcoreapp3.1\playwright.ps1 install` 
- *NOTE: This command Installs required browsers - replace netcoreapp3.1 with actual output folder name, f.ex. net6.0. 
- **If the pwsh command does not work (throws TypeNotFound), make sure to use an up-to-date version of PowerShell.*
`dotnet tool update --global PowerShell`
- [Reference link](https://playwright.dev/dotnet/docs/intro#first-project)

3. Run `dotnet test`

## IDE Setup:


