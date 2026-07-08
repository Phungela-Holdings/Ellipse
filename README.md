To add migrations run the following command

```bat
dotnet ef migrations add <your-migrations-name> --project ..\Ellipse.Data\ --startup-project  ..\Ellipse.API\
```

To update the database run the following code

```bat
dotnet ef database update --project ..\Ellipse.Data\ --startup-project  ..\Ellipse.API\
```
