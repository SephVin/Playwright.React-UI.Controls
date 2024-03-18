Set-Location (Get-Item -Path $PSScriptRoot).Parent.FullName
$version = "0.0.0"
$version = npm --version
[int]$major, [int]$minor, [int]$patch = $version.Split('.')

if (($major -lt 10) -or (($major -eq 10) -and ($minor -lt 5))) {
  Write-Host "Installing new npm version" -ForegroundColor Green
  npm -g install npm@10
}

Write-Host "npm version is ok" -ForegroundColor Green

cd src\web
npm i
npm run build-storybook
npm run storybook