using AutoMapper;
using Wellness_Score_API.DataContext;
using Wellness_Score_API.Models;

namespace Wellness_Score_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
        }
    }
}
