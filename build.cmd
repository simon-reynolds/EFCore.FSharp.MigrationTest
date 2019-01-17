rm -r .\Domain
rem dotnet nuget locals all --clear
rem rm -r .\packages
rem .paket\paket.exe install
.paket\paket.exe restore
dotnet build
dotnet ef dbcontext scaffold "CONNECTION_STRING" Npgsql.EntityFrameworkCore.PostgreSQL -o Domain
