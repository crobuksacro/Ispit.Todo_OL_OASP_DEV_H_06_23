using AutoMapper;
using Ispit.Todo.Models.Dbo;
using Ispit.Todo.Models.ViewModels;

namespace Ispit.Todo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>();
        }
    }
}
