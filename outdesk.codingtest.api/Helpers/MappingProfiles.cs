using AutoMapper;
using outdesk.codingtest.Core.DTO;
using outdesk.codingtest.Infrastructure.Data.Entities;

namespace outdesk.codingtest.api.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
        }
    }
}
