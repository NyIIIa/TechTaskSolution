# Notes

I successfully completed the technical task, but I would like to clarify some points. I implemented the technical requirements without validating any data, both on the server side and the client side. So whenever possible, please fill in the forms with valid data. I have experience with data validation only on the server side (you can check my repositories, such as GasStation, for example). On the client side, I have also worked with data validation, but only with the Angular framework. I recently started working with Blazor, so I haven't fully grasped it yet.

I also didn't use Identity, as I didn't fully understand why we need IdentityUser. Simply based on the context of the technical task, there was no mention of using authentication/authorization.


# How to install and run project

 - Clone this repository on your computer.
 - Open repository with the following IDE/Code-editor: Rider, Visual Studio, Visual Studio Code etc.
 - Build solution
 - Clone mcr.microsoft.com/azure-sql-edge image from the docker hub to run MSSQL server.
 - Run the image using fallowing comand: docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Password123" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge
 - Open a terminal in the TechTask.WebApi folder and write the fallowing command: dotnet ef database update
 - Run both applications(TechTask.WebApi and Tech.Task.Client)



