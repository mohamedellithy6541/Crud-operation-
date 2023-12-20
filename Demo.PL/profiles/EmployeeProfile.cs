using AutoMapper;
using Demo.Dal.Models;
using Demo.PL.ViewModels;

namespace Demo.PL.profiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();

        }
    }
}
