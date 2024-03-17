$registry = 'https://nexus.kontur.host/repository/kontur-npm-group/'

$version = "0.0.0"
$version = npm --version
$major, $minor, $patch = $version.Split('.')

if (($major -lt 8) -or (($major -eq 8) -and ($minor -lt 19))) {
  'installing new npm version'
  npm -g --registry $registry install npm@8
}

'npm version is ok'

cd src\web
npm i
npm run build-storybook
npm run storybook