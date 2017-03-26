using AutoMapper;
using ValueVideo.Dtos;
using ValueVideo.Models;

namespace ValueVideo.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<GenreDto, Genre>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Customer,CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType,MembershipTypeDto>();
            Mapper.CreateMap<MembershipTypeDto, MembershipType>().ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Rental,RentalDto>();
            Mapper.CreateMap<RentalDto, Rental>().ForMember(c => c.Id, opt => opt.Ignore()); 


        }
    }
}