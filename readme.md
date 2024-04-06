## Comandos usados

## cambiar la cadena de conexion en appsettings.json
    "PostgreSQLConnection":"Host=<host_render>.oregon-postgres.render.com;Database=<bd_render>;Username=<user_render>;Password=<Password Render>;Port=5432;SSL Mode=Require;Trust Server Certificate=true"

## cambiar en la clase Program.cs
'''var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));'''


## Crear el proyecto
dotnet new mvc --auth Individual -o <movieappauth>

## Instalar el dotnet ef
dotnet tool install --global dotnet-ef

## instalar postgresSQL
https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/8.0.2

## crear la migracion "Cambiar la ruta"
dotnet ef migrations add <CambiarAqui> --context movieappauth.Data.ApplicationDbContext -o "C:\Users\fduarte\OneDrive - Inteligo Group\Code\netcore\usmp\20241\movieappauth\Data\Migrations" 

## crear objetos en la base datos
dotnet ef database update

