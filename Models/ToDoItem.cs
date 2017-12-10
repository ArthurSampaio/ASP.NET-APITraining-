using System;
using System.ComponentModel.DataAnnotations;


namespace ToDoList.Models
{
    public class ToDoItem
    {
        public long Id {get; set;}

        [Required]
        [StringLength(160)]
        public string Name { get; set; }
        public bool isComplete {get; set;}
    }
}

