$scriptPath = Split-Path $.\packages\psake.4.4.1\tools
Import-Module (join-path $scriptPath\psake.psm1)
invoke-psake -.\build.ps1