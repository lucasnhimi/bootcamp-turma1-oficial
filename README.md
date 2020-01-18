Backend	

>>Step 1 - Instalando Editor de código fonte
VS Code: https://code.visualstudio.com/download
SDK .NET Core: https://dotnet.microsoft.com/download

>>Step 2 - Plugins VsCode:
1. C#
2. ESLint
3. Live Server
4. vscode-icons
5. vscode-styled-components
6. Color Highlight

>>Step 3 - Instalando banco de dados Postgresql
Postgresql: https://www.postgresql.org/download
PGAdmin: https://www.pgadmin.org/download/

>>Step 4 - Criar diretórioo
Selecionar um diretório em seu ambiente e criar uma pasta chamada “backend”

>>Step 5 - Montando ambiente WebApi
Abrir o prompt de comando na pasta criada no step anterior e executar os seguintes comandos:
- [ ] dotnet new sln -n InstagramApi
- [ ] dotnet new webapi -n InstagramApi
- [ ] dotnet sln add InstagramApi/InstagramApi.csproj

Navegar até a pasta do projeto: cd InstagramApi e executar os seguintes comandos:
- [ ] dotnet add InstagramApi.csproj package Swashbuckle.AspNetCore -v 5.0.0-rc2
- [ ] dotnet add InstagramApi.csproj package Microsoft.EntityFrameworkCore -v 3.1.0
- [ ] dotnet add InstagramApi.csproj package Microsoft.EntityFrameworkCore.Tools -v 3.1.0
- [ ] dotnet add InstagramApi.csproj package Npgsql.EntityFrameworkCore.PostgreSQL -v 3.1.0
- [ ] dotnet add InstagramApi.csproj package Autofac -v 4.9.4
- [ ] dotnet add InstagramApi.csproj package Autofac.Extensions.DependencyInjection -v 5.0.1

Dica:
Comandos auxiliares
dotnet restore;
dotnet build;
dotnet run;


Dica: 
Configurando VS Code para abrir pelo prompt
Instalar shell command : https://code.visualstudio.com/docs/setup/mac

>>Step 6 - Preparando Api
Abrir a pasta backend no VS Code
Acessar o projeto InstagramApi
Excluir os arquivos:
- [ ] WeatherForecast.cs
- [ ] WeatherForecastController.cs
Criar as seguintes pastas:
- [ ] Context
- [ ] Entities
- [ ] Models
- [ ] Repositories
- [ ] Services
- [ ] Utils
Vamos criar as classes dentro de cada pasta
Entities:
- [ ] User.cs
Context:
- [ ] InstagramContext.cs
Utils:
- [ ] IRepository.cs
- [ ] Repository.cs
Repositories:
- [ ] IUserRepository.cs
- [ ] UserRepository.cs
Services:
- [ ] IUserService.cs
- [ ] UserService.cs
Models:
- [ ] LoginModel.cs
Controllers:
- [ ] UserController.cs
Ajustar classe de configurações do projeto
- [ ] Startup.cs
- [ ] Program.cs


>> Step 7 - Migrations EF
Instalar o doente-ef global caso ainda não tenha instalado, este comando só executamos uma única vez em nosso pc
dotnet tool install --global dotnet-ef —version 3.0.0

Executar os comandos abaixo para criar nosso banco de dados
dotnet ef migrations add Initial
dotnet ef database update

>>Step 8 - Criar arquivo gitignore
https://raw.githubusercontent.com/github/gitignore/master/VisualStudio.gitignore

