using AutoMapper;
using backend_server.Core.Dtos.Company;
using backend_server.Core.Dtos.Job;
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
            CreateMap<JobCreateDto, Job>();
            CreateMap<Job, JobGetDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name));

            //Candidate
        }
    }
}
