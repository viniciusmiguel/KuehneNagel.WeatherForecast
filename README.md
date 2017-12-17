# Weather Forecast Web Application

This weather forecast application demonstrates best practices of coding and software architecture using .NET Core.

The application was developed using Domain Driven Design approach.
This methodology helps the software development through isolation of responsibilities on a software application, it's a design pattern that helps code structuration to accomplish the SOLID principles.

It has a Presentation layer that is responsible for user interface, it's possible to have multiples user interfaces, the project itself is agnostic about front-end.

The application layer delivers the Application service that is responsible to interface and encapsulates all application business logic, the data is exposed through a view-model declared in the application layer, this way we avoid coupling to the domain layer.

The domain layer is responsible for all application business logic, it does not care about data access and storage

The infrastructure layer is composed of two projects
Data: implement all repository interfaces from domain layer, 
we have database repositories that are implemented through Entity Framework and Services Repositories that consume data from a third-party API.
IoC: this the project responsible for dependency injection, in this case, it uses  .Net Core Native Injector, the injector method is called by the front-end project in the application initialization.

Improvements

Today the application consider the difference between day/night
from 6:00 to 18:00, statically defined in the project. One possible improvement is to get this data from another API that delivers this information based on location.

The unit tests are the minimum to check the core functionality, it is not considering data inconsistency from the weather API.

The application doesn't have a web job that updates the database with a defined span of time, it only updates when a user accesses the service, it reduces the accuracy of the Current Day Forecast Accuracy calculation.

The application doesn't allow the change of the weather station, one possible update adds a combo box to the user select the desired weather station and store this decision in the user computer browser cookie.


Requirements:

For Run:

.NET Core 2.0 SDK installed

Microsoft SQL Server Express or Microsoft SQL Server

For Debug and Test

Microsoft Visual Studio 2017 with .NET Core SDK installed

Microsoft SQL Server Express or Microsoft SQL Server


Procedure to Debug and Test

First, create a database with name "weather".

Use the script in DatabaseGeneration.sql file to create the tables.

If you are using SQL Server (not express), or using a remote database server, you need to adjust the connection string in the appsettings.json file.

Reference for connection string configuration:
https://msdn.microsoft.com/en-us/library/jj653752(v=vs.110).aspx

After this just load the solution in the visual studio.

If instead of debugging and test you just want to run the application execute in a command terminal these commands in the "KuehneNagel.WeatherForecast.Frontend" directory

dotnet restore

dotnet run