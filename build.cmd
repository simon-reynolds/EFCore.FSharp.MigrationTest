rm -r .\Migrations
rem dotnet nuget locals all --clear
rem rm -r .\packages
rem .paket\paket.exe install
.paket\paket.exe restore
dotnet build
dotnet ef migrations add InitialCreate
