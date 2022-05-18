$PlaywrightFileName = Join-Path $PSScriptRoot "bin\debug"
Get-ChildItem -Path $PlaywrightFileName -Name
pwsh $PlaywrightFileName install