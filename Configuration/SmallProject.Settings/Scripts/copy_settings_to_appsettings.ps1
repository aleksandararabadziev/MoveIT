Param(
  [string]$uiConfigPath="..\UI\SmallProject.UI\appsettings.json",
  [string]$apiConfigPath="..\UI\SmallProject.API\appsettings.json",
)

$appConfigPath = "..\appsettings.json";

Clear-Content $uiConfigPath
Clear-Content $apiConfigPath

Get-Content $appConfigPath | Out-File $uiConfigPath
Get-Content $appConfigPath | Out-File $apiConfigPath