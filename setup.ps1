$serviceName = "MSSQL`$SQLEXPRESS"

If(Get-Service -Name $serviceName -ErrorAction SilentlyContinue) {
    If((Get-Service -Name $serviceName).Status -eq "Stopped") {
        Write-Host "$serviceName found but it's not running."
        Start-Service $serviceName
    } Else {
        Write-Host "$serviceName found and it's running."
    }
} Else {
    Write-Error "$serviceName not found."
    Exit
}

$hostname = hostname
Invoke-Sqlcmd -InputFile ".\estore.schema.setup.sql" -ServerInstance "$hostname\SQLEXPRESS" -Verbose
dotnet restore
cd estore.web
npm install
cd ..
dotnet build