# Replace the following URL with a public GitHub repo URL
$gitrepo="stry"
$gittoken="isat"
$webappname="svcname$(Get-Random)"
$location="West Europe" 
$rgName="resgroup"
$branch="sourcebrnch"
$azureorgst="azorg"
$azuretoken="aztoken"
$azurerepo="azrepon"
$azureprj="azprjc"





Set-ExecutionPolicy -ExecutionPolicy unrestricted -Scope CurrentUser

[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12

Install-Module -Name Az -AllowClobber -Scope CurrentUser
Install-Module -Name Az -AllowClobber -Scope CurrentUser




Connect-AzAccount

az login;

az repos create --name $azurerepo --org $azureorgst --project $azureprj;
az repos import create --git-source-url $gitrepo --repository $azurerepo --organization $azureorgst --project $azureprj;
