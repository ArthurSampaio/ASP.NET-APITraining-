using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ToDoList.Models;
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;


/*
TODO: how to get info fro appsettings.json?? 
 */

namespace ToDoList.DAO
{
    public class ToDoDAO
    {
        private IConfiguration _config;

        //unnecessary
        const string SQL = "Server=localhost;Database=ToDoDB;Port=5432;User Id=aspnet;Password=12345;Timeout=10;";

        public ToDoDAO(IConfiguration config)
        {
            _config = config;
        }

        public List<ToDoItem> ListAll()
        {

            List<ToDoItem> todoList = new List<ToDoItem>();
            using (NpgsqlConnection connection = new NpgsqlConnection(SQL))
            {

                connection.Open();
                var result = connection.Query<ToDoItem>(
                    "SELECT * FROM ToDoItem"
                );

                foreach (ToDoItem item in result)
                {
                    todoList.Add(item);
                }

                return todoList;

            }

        }

        public int Size()
        {
            List<ToDoItem> list = ListAll();
            return list.Count;
        }

        public void AddItem(string name)
        {

            const string sqlOperation = "INSERT INTO ToDoItem (Name, isComplete) VALUES (@Name, @isComplete)";
            using (NpgsqlConnection connection = new NpgsqlConnection(SQL))
            {
                connection.Open();
                var RowsAdded = connection.Execute(sqlOperation, new { Name = name, isComplete = false });
            }
        }

        public ToDoItem getById(long id)
        {
            const string sqlOperation = "SELECT * FROM ToDoItem WHERE Id = @Id;";

            using (NpgsqlConnection connection = new NpgsqlConnection(SQL))
            {
                connection.Open();

                var result = connection.QueryFirstOrDefault<ToDoItem>(sqlOperation, new { Id = id });

                return result;

            }

        }

        public void SaveTodoItem(ToDoItem item)
        {

            const string sqlOperation = "INSERT INTO ToDoItem (Name, isComplete) VALUES (@Name, @isComplete)";
            using (NpgsqlConnection connection = new NpgsqlConnection(SQL))
            {
                connection.Open();

                var RowsAdded = connection.Execute(sqlOperation, new { Name = item.Name, isComplete = item.isComplete });


            }

        }

        public void UpdateTodoItem(ToDoItem item)
        {

            const string sqlOperation = "UPDATE ToDoItem SET isComplete = @isComplete, Name = @Name WHERE Id = @Id";

            using (NpgsqlConnection connection = new NpgsqlConnection(SQL))
            {
                connection.Open();

                var RowsAdded = connection.Execute(sqlOperation, new { Id = item.Id, Name = item.Name, isComplete = item.isComplete });


            }

        }


    }
}