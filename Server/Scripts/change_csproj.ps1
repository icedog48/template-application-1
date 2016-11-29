Get-ChildItem -Filter *.csproj -Recurse | 
Foreach-Object {
    $content = Get-Content $_.FullName
	
	#Core
	$content = $content.replace('..\Core\Core.csproj', '..\$ext_projectname$.Core\$ext_projectname$.Core.csproj') 
	$content = $content.replace('<Name>Core</Name>'  , '<Name>$ext_projectname$.Core</Name>') 
	
	#Migrations
	$content = $content.replace('..\Migrations\Migrations.csproj', '..\$ext_projectname$.Migrations\$ext_projectname$.Migrations.csproj') 
	$content = $content.replace('<Name>Migrations</Name>'  , '<Name>$ext_projectname$.Migrations</Name>') 
		
	#NhibernateRepositories
	$content = $content.replace('..\NhibernateRepositories\NhibernateRepositories.csproj', '..\$ext_projectname$.NhibernateRepositories\$ext_projectname$.NhibernateRepositories.csproj') 
	$content = $content.replace('<Name>NhibernateRepositories</Name>'  , '<Name>$ext_projectname$.NhibernateRepositories</Name>') 
	
	$content = $content.replace('..\packages\Microsoft.Net.Compilers' , '..\..\packages\Microsoft.Net.Compilers') 
	$content = $content.replace('..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform' , '..\..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform') 
	
	$content = $content.replace('<HintPath>..\packages\'  , '<HintPath>..\..\packages\') 
	
	Set-Content -Value $content -Path $_.FullName
}

Get-ChildItem -Filter *.cs -Recurse | 
Foreach-Object {
	
	$content = Get-Content $_.FullName
	$content = $content.replace('using Core.'  , 'using $ext_projectname$.Core.') 
	$content = $content.replace('using NhibernateRepositories.'  , 'using $ext_projectname$.NhibernateRepositories.') 
	
	Set-Content -Value $content -Path $_.FullName
}