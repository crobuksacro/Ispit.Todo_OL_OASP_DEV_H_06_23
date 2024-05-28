using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Models.ViewModels;
using System.Security.Claims;

namespace Ispit.Todo.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUserViewModel> GetUserProfileAsync(ClaimsPrincipal user);
        System.Threading.Tasks.Task AddTodoList(ToDoList dbo, ClaimsPrincipal user);
        System.Threading.Tasks.Task<List<ToDoList>> GetTodoList(ClaimsPrincipal user);
    }
}