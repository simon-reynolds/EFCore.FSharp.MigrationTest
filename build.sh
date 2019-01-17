rm -r ./Domain
mono ./.paket/paket.exe install
mono ./.paket/paket.exe restore
dotnet build
dotnet ef dbcontext scaffold "CONNECTION_STRING" Npgsql.EntityFrameworkCore.PostgreSQL -o Domain
