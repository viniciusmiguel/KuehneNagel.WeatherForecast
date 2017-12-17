# Weather Forecast Web Application

This weather forecast application demonstrate best pratices of coding and software architecture using .NET Core 

Requirements:

For Run:

.NET Core 2.0 SDK installed

Microsoft SQL Server Express or Microsoft SQL Server

For Debug and Test

Microsoft Visual Studio 2017 with .NET Core SDK installed

Procedure to Debug and Test

First create a database with name "weather".

Use the script in DatabaseGeneration.sql file to create the tables.

If you are using SQL Server (not express), or using a remote database server, you need to adjust the connection string in the appsettings.json file.

Reference for connection string configuration:
https://msdn.microsoft.com/en-us/library/jj653752(v=vs.110).aspx

After this just load the solution in the visual studio.

If instead of debug and test you just want to run the application execute in a command terminal these comands in the "KuehneNagel.WeatherForecast.Frontend" directory

dotnet restore

dotnet run

