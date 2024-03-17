Set-Location (Get-Item -Path $PSScriptRoot).Parent.FullName

$dockerImageName = "pw_react_ui_controls_image"
$dockerContainerName = "pw_react_ui_controls_container"
$tmpDirectory = "/tmp"
$srcDirectory = "$tmpDirectory/src"

function RemoveDockerImage {
	$isImageExists = docker images -q $dockerImageName
	
	if ($isImageExists) {
		$containers = docker ps -a --filter "name=$dockerContainerName" -q
	
		foreach ($container in $containers) {
			Write-Host "Container $container found, removing it..." -ForegroundColor Green		
			docker rm $container -f
		}		
		
		Write-Host "Image $dockerImageName found, removing it..." -ForegroundColor Green
		docker rmi $dockerImageName
	}		
}

function WaitForPortAvailability {
    param (
        [string]$containerName,
        [int]$port = 6006,
        [int]$timeout = 60
    )

    $counter = 0
    while ($counter -lt $timeout) {
        $result = Test-NetConnection -ComputerName localhost -Port $port
        if ($result.TcpTestSucceeded) {
            Write-Host "Port $port is available." -ForegroundColor Green
            return
        }
        else {
            Write-Host "Port $port is not available. Waiting 1 second..." -ForegroundColor Green
            Start-Sleep -Seconds 1
            $counter++
        }
    }

    Write-Host "Timeout exceeded ($timeout seconds). Failed to connect to port $port." -ForegroundColor Red
	exit 1
}

RemoveDockerImage
docker build -t $dockerImageName -f image/Dockerfile . --no-cache
docker run -it --rm -d -p 6006:6006 --name $dockerContainerName $dockerImageName
docker exec $dockerContainerName bash -c "cd $srcDirectory/web && npm i && npm run build-storybook && (npm run storybook &)"
WaitForPortAvailability -containerName $dockerContainerName