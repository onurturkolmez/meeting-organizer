### Summary
You can add,list,update,delete your meetings with this sample web project.
In additon it shows all API infos.
A simple ASP.NET 5 Project that assigned me by one company in Istanbul for interview follow up.

### Infos and Implementation of Project 

The project was created with ASP.NET 5 (vNext).
The ORM Entity Framework was used for the database and
Coding was done with Code First approach.
The front-end part is currently provided by Microsoft
written in bootstrap and jquery.

Code First approach to run the project on your own computer
you need to make some settings for it.

* Connection information and table classes are located under the Models folder
Models-> Context-> MeetingOrganizerContext.cs
The connection string on the computer to run
sql server needs to be changed according to the settings.

* It also processes requests sent by the project client with Web API 2.
However, this is a local server. It has own port number, so that should change it as your local server port number.
At this point, There is a static variable named "portNumber". It must be changed to the computer server port to be used.

- After 2 important changes, the project will run smoothly.
After the project has been built, the database will be created;

You may need run this command as well.
Visual Studio-> Tools-> Nuget Package Manager-> Package Manager Console
in the order;
"Add-migration"
"Update-database"
commands should be written.

You can then view it in the browser.

-I added dummy content in HomeController to get faster results.Use it if you wish.
