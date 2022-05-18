$PlaywrightFileName = Join-Path $PSScriptRoot "bin\debug\netcore3.1\RestSharp.dll"
Get-ChildItem -Path $PSScriptRoot -Name
pwsh $PlaywrightFileName install