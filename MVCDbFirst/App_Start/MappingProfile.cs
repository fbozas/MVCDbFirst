using AutoMapper;
using MVCDbFirst.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDbFirst.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Employee, EmployeeDto>();
            Mapper.CreateMap<EmployeeDto, Employee>();
        }
    }
}