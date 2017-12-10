using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;



namespace ToDoList.DAO
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private ToDoDAO dao;

        public ToDoListController(ToDoDAO Dao){
            dao = Dao; 

            if (dao.size() == 0){
                dao.AddItem("Atividade 1");
            }

        }

        [HttpGet]
        public List<ToDoItem> getAll() {
            return dao.listAll();
        }
    }
}