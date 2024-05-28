using Microsoft.AspNetCore.Identity;

namespace Ispit.Todo.Models.Dbo
{
    public class ApplicationUser: IdentityUser
    {
        public ICollection<ToDoList> ToDoLists { get; set; }
    }
}
