using AutoMapper;
using Entities;
using Entities.DataTransferObjects;

namespace CompanyEmployee.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDto>().ForMember(c => c.FullAddress, opt => opt.MapFrom(x => string.Join(' ', x.Address, x.Country)));
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CompanyForCreationDto, Company>();
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<Employee, EmployeeForUpdateDto>();
            CreateMap<CompanyForUpdateDto, Company>();
        }
    }
}