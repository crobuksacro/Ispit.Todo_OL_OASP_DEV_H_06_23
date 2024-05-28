namespace Ispit.Todo.Models.Dbo
{
    public class Task
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public ToDoList? ToDoList { get; set; }
        public int? ToDoListId { get; set; }
    }
}
