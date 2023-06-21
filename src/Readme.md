dotnet tool update --global dotnet-ef

dotnet ef migrations add AddIdentityMS --project "Identity.API"

dotnet ef database update --project "Identity.API"
