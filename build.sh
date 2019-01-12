rm -r ./Migrations
mono ./.paket/paket.exe install
mono ./.paket/paket.exe restore
dotnet build
dotnet ef migrations add InitialCreate
