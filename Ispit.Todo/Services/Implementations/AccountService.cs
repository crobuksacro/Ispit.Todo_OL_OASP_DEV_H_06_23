using AutoMapper;
using Ispit.Todo.Data;
using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Models.ViewModels;
using Ispit.Todo.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ispit.Todo.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private UserManager<ApplicationUser> userManager;
        private ApplicationDbContext db;
        private IMapper mapper;
        private SignInManager<ApplicationUser> signInManager;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
            this.mapper = mapper;
        }

        public async System.Threading.Tasks.Task<List<ToDoList>> GetTodoList(ClaimsPrincipal user)
        {
            var userId = userManager.GetUserId(user);
            var response = db.ToDoLists.Where(y => y.ApplicationUserId == userId).ToList();
            return response;


        }


        public async System.Threading.Tasks.Task AddTodoList(ToDoList dbo, ClaimsPrincipal user)
        {
            dbo.ApplicationUserId = userManager.GetUserId(user);
            db.ToDoLists.Add(dbo);
            await db.SaveChangesAsync();
        }

        /// <summary>
        /// Get current user profile
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<ApplicationUserViewModel> GetUserProfileAsync(ClaimsPrincipal user)
        {

            var dbo = await db.Users
                .Include(y => y.ToDoLists)
                .ThenInclude(y => y.Tasks)
                .FirstOrDefaultAsync(y => y.Id == userManager.GetUserId(user));
            return mapper.Map<ApplicationUserViewModel>(dbo);
        }
    }
}
