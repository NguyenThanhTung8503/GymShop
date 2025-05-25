# ASP.NET Core 8.0 project 
## Technologies
- ASP.NET Core 8.0
- Entity Framework Core 8.0
## Install Tools
- .NET Core SDK 8.0
- Visual Studio 2022
- SQL Server 2019
## How to configure and run
- Clone code from Github: git clone https://github.com/NguyenThanhTung8503/GymShop
- Open solution ShopGYM.sln in Visual Studio 2019
- Set startup project is ShopGYM.Data
- Change connection string in Appsetting.json in ShopGYM.Data project
- Open Tools --> Nuget Package Manager -->  Package Manager Console in Visual Studio
- Run Update-database and Enter.
- After migrate database successful, set Startup Project is ShopGYM.WebApp
- Change database connection in appsettings.Development.json in ShopGYM.WebApp project.
- You need to change 3 projects to self-host profile.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 3 Projects: BackendApi, WebApp and AdminApp.
- Choose profile to run or press F5
