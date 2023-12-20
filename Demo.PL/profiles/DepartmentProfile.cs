using AutoMapper;
using Demo.Dal.Models;
using Demo.PL.ViewModels;

namespace Demo.PL.profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DeparmentViewModel,Department>().ReverseMap();
        }
    }
}
