using AutoMapper;
using backend_server.Core.Dtos.Company;
using backend_server.Core.Entities;

namespace backend_server.Core.AutoMapperConfig
{
    public class AutoMapperConfigProfile: Profile
    {
        public AutoMapperConfigProfile()
        {
            //Company
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<Company, CompanyGetDto>();
            //Job

            //Candidate
        }
    }
}
