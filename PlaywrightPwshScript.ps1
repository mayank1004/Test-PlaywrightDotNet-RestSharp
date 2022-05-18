$PlaywrightFileName = Join-Path $PSScriptRoot "bin"
Get-ChildItem -Path $PlaywrightFileName -Name
pwsh $PlaywrightFileName install