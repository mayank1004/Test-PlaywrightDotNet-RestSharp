$PlaywrightFileName = Join-Path $PSScriptRoot "bin/Debug"
Get-ChildItem -Path $PlaywrightFileName -Name
pwsh $PlaywrightFileName install