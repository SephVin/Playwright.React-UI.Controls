dotnet build src\Playwright.ReactUI.sln --configuration Release
dotnet pack src\Controls\Controls.csproj --configuration Release --no-build --include-symbols --nologo --output nuget
dotnet pack src\Controls.Extensions\Controls.Extensions.csproj --configuration Release --no-build --include-symbols --nologo --output nuget