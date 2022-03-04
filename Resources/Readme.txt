Steps for setting up:

1. Find the certificates in the Resources folder (the password for the certs is 123) and host the web application on local IIS
2. Insert this record in hosts file: 127.0.0.1 smallproject.dev api.smallproject.dev
3. Create new database
4. Find the file database_query.sql in Resources folder and execute it in your new database
5. Change the connection string in all 3 appsettings.json files which are located in SmallProject.Settings, SmallProject.API, SmallProject.UI

Note: The user is hard-coded in repository.service.ts!