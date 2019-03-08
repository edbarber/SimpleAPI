# SimpleAPI

To use this project you need to have the database created by executing CreateEmployeeDb. Make sure the connection string for EmployeeConnection in appsettings.json inside the SimpleAPI project matches the database that was just created locally. 

You will need to run the SimpleAPI project once every time you make changes to its code or restart visual studio otherwise it will refuse any incoming connection. Also, inside the EmployeeWebApp project you will need to make sure APIHost inside appsettings.json is set correctly before running the EmployeeWebApp project otherwise the app will deadlock.
