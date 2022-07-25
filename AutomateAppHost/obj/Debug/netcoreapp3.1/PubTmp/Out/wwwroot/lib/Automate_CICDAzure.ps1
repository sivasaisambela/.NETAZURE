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


Set-ExecutionPolicy -ExecutionPolicy RemoteSigned -Scope CurrentUser

Install-Module -Name Az -Scope CurrentUser -Repository PSGallery -AllowClobber













az login;

az repos create --name $azurerepo --org $azureorgst --project $azureprj;
az repos import create --git-source-url $gitrepo --repository $azurerepo --organization $azureorgst --project $azureprj;
