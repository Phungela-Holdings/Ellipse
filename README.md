## Branching strategy
* Create a feature banch
* Add your changes
* Create a pull request to many branch
* Check for pull request comments

## Add migrations command

After making database changes, run the following command to add migrations for the changes you have made.

```bat
dotnet ef migrations add <your-migrations-name> --project ..\Ellipse.Data\ --startup-project  ..\Ellipse.API\
```

## Update database command

If you want to update the database, you must run the following command

```bat
dotnet ef database update --project ..\Ellipse.Data\ --startup-project  ..\Ellipse.API\
```

## Notes 

To run EF commands use the Terminal

Before you run the EF commands for the first time, please run the following command

```bat
dotnet tool install --global dotnet-ef
```

Make sure you are in the Ellipse.Data directory whenever you run commands for the database. 

```bat
cd .\Ellipse.Data\
```
