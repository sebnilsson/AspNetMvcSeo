$ScriptDirectory = (Split-Path -Path $MyInvocation.MyCommand.Path) # resolve-path ..
$RootDirectory = (Split-Path -Path $ScriptDirectory -Parent)

$OutputDirectory = "$RootDirectory\.build-artifacts"
$NuspecPath = "$RootDirectory\src\AspNetMvcSeo\AspNetMvcSeo.csproj"

Write-Host "RootDirectory: '$RootDirectory'"
Write-Host "OutputDirectory: '$OutputDirectory'"
Write-Host "NuspecPath: '$NuspecPath'"

if (-not(Test-Path $OutputDirectory)) {
	New-Item -Path $OutputDirectory -ItemType Directory | Out-Null
}

Write-Host 

nuget pack $NuspecPath -build -properties Configuration=Release -outputdirectory $OutputDirectory `
	 -excludeemptydirectories -msbuildversion 14 # -symbols