using Ispit.Todo.Models.ViewModels;
using System.Security.Claims;

namespace Ispit.Todo.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUserViewModel> GetUserProfileAsync(ClaimsPrincipal user);
    }
}