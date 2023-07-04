dotnet tool update --global dotnet-ef

dotnet ef migrations add AddRoleIdentity --project "Identity.API"

dotnet ef migrations remove --project "Identity.API"

dotnet ef database update --project "Identity.API"

dotnet ef database drop --project "Identity.API"