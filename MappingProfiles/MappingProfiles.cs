using AutoMapper;
using Backend_Developer_test.DTOs;
using Backend_Developer_test.Models;

namespace Backend_Developer_test.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
        }
    }
}
