using Npgsql; 
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using ToDoList.Models;
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;



namespace ToDoList.DAO
{
    public class ToDoDAO
    {
        private IConfiguration _config;

        public ToDoDAO(IConfiguration config){
            _config = config;
        }

        public List<ToDoItem> listAll() {

            List<ToDoItem> todoList = new List<ToDoItem>();
            using (NpgsqlConnection connection = new NpgsqlConnection (
                _config.GetConnectionString("ToDoDB"))) {
                    var result = connection.Query<ToDoItem>(
                        "SELECT * FROM ToDoItem"
                    );

                    foreach (ToDoItem item in result){
                        todoList.Add(item);
                    }

                    return todoList;

                }

        }

        public void AddItem (string name){

            const string sql = "INSERT INTO ToDoItem (Name, isComplete) VALUES (@Name, @isComplete)"
            using (NpgsqlConnection connection = new NpgsqlConnection (
                _config.GetConnectionString("ToDoDB"))) {
                    connection.Open();
 
                    var RowsAdded = connection.Execute(sql, new {Name = name, isComplete = false});

                    
                }


        }

    }
}