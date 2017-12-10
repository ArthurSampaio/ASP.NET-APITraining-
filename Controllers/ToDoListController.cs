using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;



namespace ToDoList.DAO
{
    [Route("api/[controller]")]
    public class ToDoListController : Controller
    {
        private ToDoDAO dao;

        public ToDoListController(ToDoDAO Dao)
        {
            dao = Dao;

            if (dao.Size() == 0)
            {
                dao.AddItem("Atividade 1");
            }

        }

        [HttpGet]
        public List<ToDoItem> GetAll()
        {
            return dao.ListAll();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetByID(long id)
        {

            var element = dao.getById(id);

            if (element == null)
            {
                return NotFound();
            }
            return new ObjectResult(element);

        }

        [HttpPost]
        public IActionResult SaveItem([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            dao.SaveTodoItem(item);
            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        public IActionResult UpdateItem([FromBody] ToDoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            dao.UpdateTodoItem(item);

            return new NoContentResult();

        }

    }
}