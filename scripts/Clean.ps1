# ------------------------------------------------------------------------------
# Change location to 'root' directory for solution
# ------------------------------------------------------------------------------
Set-Location -Path $PSScriptRoot
Set-Location ..
# ------------------------------------------------------------------------------
# Variables: Root, Logs, MSBuild (VS2017), Nuget (command line), Solution, Project paths/arguments
# ------------------------------------------------------------------------------
$pathLocation = Get-Location
$flagBinaries = $true
$flagPackages = $true
$flagTestResults = $true
$colorBinaries = [System.ConsoleColor]::Green
$colorPackages = [System.ConsoleColor]::Green
$colorTestResults = [System.ConsoleColor]::Green
$directories = 'build', 'bin', 'obj', '.obj', 'packages', 'testresults'
$horizontalLine = "-" * 78
# ------------------------------------------------------------------------------
# Prompt
# ------------------------------------------------------------------------------
Write-Host "+$horizontalLine+" -ForegroundColor Black -BackgroundColor White
Write-Host '| The current script deletes bin/obj/packages/testresults directories          |' -ForegroundColor Black -BackgroundColor White
Write-Host "+$horizontalLine+" -ForegroundColor Black -BackgroundColor White
$titleConfirm = ''
$messageConfirm = "Do you want to continue?"
$optCleanAll = New-Object System.Management.Automation.Host.ChoiceDescription "Delete &All", "Delete bin/obj/packages/testresults directories."
$optCleanBin = New-Object System.Management.Automation.Host.ChoiceDescription "Delete &Binaries", "Delete only binaries directories (bin/obj)."
$optCleanPackages = New-Object System.Management.Automation.Host.ChoiceDescription "Delete &Packages", "Delete only packages directories."
$optCleanTestResults = New-Object System.Management.Automation.Host.ChoiceDescription "Delete &TestResults", "Delete only testresults directories."
$optCleanBinPackages = New-Object System.Management.Automation.Host.ChoiceDescription "Delete B&inaries/Packages", "Delete only binaries and packages directories."
$optCleanBinTestResults = New-Object System.Management.Automation.Host.ChoiceDescription "Delete Bi&naries/TestResults", "Delete only binaries and testresults directories."
$optCleanPackagesTestResults = New-Object System.Management.Automation.Host.ChoiceDescription "Delete Pa&ckages/TestResults", "Delete only packages and testresults directories."
$optExit = New-Object System.Management.Automation.Host.ChoiceDescription "E&xit", "Exit the script."
$options = [System.Management.Automation.Host.ChoiceDescription[]]($optCleanAll, $optCleanBin, $optCleanPackages, $optCleanTestResults, $optCleanBinPackages, $optCleanBinTestResults, $optCleanPackagesTestResults, $optExit)
$result = $Host.UI.PromptForChoice($titleConfirm, $messageConfirm, $options, 0)
# ------------------------------------------------------------------------------
# Evaluate choosen options
# ------------------------------------------------------------------------------
if ($result -eq 7) {
    exit
}
$flagBinaries = ($result -eq 0) -or ($result -eq 1) -or ($result -eq 4) -or ($result -eq 5)
$flagPackages = ($result -eq 0) -or ($result -eq 2) -or ($result -eq 4) -or ($result -eq 6)
$flagTestResults = ($result -eq 0) -or ($result -eq 3) -or ($result -eq 5) -or ($result -eq 6)
$colorBinaries = @{$true = [System.ConsoleColor]::Green; $false = [System.ConsoleColor]::Red}[$flagBinaries]
$colorPackages = @{$true = [System.ConsoleColor]::Green; $false = [System.ConsoleColor]::Red}[$flagPackages]
$colorTestResults = @{$true = [System.ConsoleColor]::Green; $false = [System.ConsoleColor]::Red}[$flagTestResults]
if (!$flagBinaries) {
	$directories = $directories -ne 'build'
    $directories = $directories -ne 'bin'
    $directories = $directories -ne 'obj'
    $directories = $directories -ne '.obj'    
}
if (!$flagPackages) {
    $directories = $directories -ne 'packages'
}
if (!$flagTestResults) {
    $directories = $directories -ne 'testresults'
}
# ------------------------------------------------------------------------------
# Display choosen options
# ------------------------------------------------------------------------------
Write-Host "-$horizontalLine-" -ForegroundColor White
Write-Host "- Delete binaries: " -ForegroundColor Cyan -NoNewline; Write-Host "$flagBinaries" -ForegroundColor $colorBinaries -NoNewline; Write-Host
Write-Host "- Delete packages: " -ForegroundColor Cyan -NoNewline; Write-Host "$flagPackages" -ForegroundColor $colorPackages -NoNewline; Write-Host
Write-Host "- Delete testresults: " -ForegroundColor Cyan -NoNewline; Write-Host "$flagTestResults" -ForegroundColor $colorTestResults -NoNewline; Write-Host
# ------------------------------------------------------------------------------
# Execute
# ------------------------------------------------------------------------------
Write-Host "-$horizontalLine-" -ForegroundColor White
Get-ChildItem -Directory -Recurse -Path $pathLocation -Include $directories | ForEach-Object -Process { Write-Host "$($_.fullname) " -ForegroundColor Yellow -NoNewline; Remove-Item "$($_.fullname)" -Force -Recurse; Write-Host "(removed)" -ForegroundColor Red -NoNewline; Write-Host; }
# ------------------------------------------------------------------------------
# Exit
# ------------------------------------------------------------------------------
Write-Host "-$horizontalLine-" -ForegroundColor White
Write-Host "Press <enter> key to exit..." -ForegroundColor DarkGray -NoNewline
Read-Host
