# ASP.NET Core 2.0 + Dapper Training

## Pre-requesites:
* SDK NET Core 2.0.0+
* Visual Studio Code
* Postgresql 9.5

## Instructions: 

1. Clone this repo; 
2. Open the project in VS; 
3. Create a user and a DB in Postgresql
    in psql terminal: 
    ```
    createdb -h localhost -p 5432 -U aspnet ToDoDB password 12345
    ```
    You must grant permissions for the aspnet user (ToDo: add command)
4. Run project
5. Go to {port}/api/todolist