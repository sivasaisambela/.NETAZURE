# Replace the following URL with a public GitHub repo URL
$gitrepo="stry"
$gittoken="isat"
$webappname="svcname$(Get-Random)"
$location="West Europe" 
$rgName="resgroup"
$branch="sourcebrnch"
$azureorgst="org"
$azuretoken="token"
$azurerepo="repon"
$azureprjc="prjc"

set-ExecutionPolicy RemoteSigned -Scope CurrentUser

Start-Process powershell -Verb runAs



$ProgressPreference = 'SilentlyContinue'; 
Invoke-WebRequest -Uri https://aka.ms/installazurecliwindows -OutFile .\AzureCLI.msi;
Start-Process msiexec.exe -Wait -ArgumentList '/I AzureCLI.msi /quiet'; rm .\AzureCLI.msi




Connect-AzAccount



# Create an App Service plan in Free tier.
New-AzAppServicePlan -ResourceGroupName $rgName -Name $webappname -Location $location -Tier "Free" -NumberofWorkers 2 -WorkerSize "Small"

# Create a web app.
New-AzWebApp -Name $webappname -Location $location -AppServicePlan $webappname -ResourceGroupName $rgName 

# Configure GitHub deployment from your GitHub repo and deploy once.
$PropertiesObject = @{
    repoUrl = "$gitrepo";
    branch = "$branch";    
    isManualIntegration = "true";
}
Set-AzResource -Properties $PropertiesObject -ResourceGroupName $rgName -ResourceType Microsoft.Web/sites/sourcecontrols -ResourceName $webappname/web -ApiVersion 2015-08-01 -Force



