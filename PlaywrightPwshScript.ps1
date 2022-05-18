$PlaywrightFileName = Join-Path $PSScriptRoot "bin/Debug/netcoreapp3.1"
Get-ChildItem -Path $PlaywrightFileName -Name
pwsh bin/Debug/netcoreapp3.1/playwright.ps1 install