# krakent-cryptus-user

#comando para ejecuatar migraciones
dotnet ef migrations add InitialCreate --startup-project ../krakent-cryptus-user.api
dotnet ef database update --startup-project ../krakent-cryptus-user.api
