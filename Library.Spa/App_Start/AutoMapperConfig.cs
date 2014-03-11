using AutoMapper;
using Library.Model.Models;
using Library.Spa.ViewModels;

namespace Library.Spa
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(dest=>dest.PublishDate,opt=>opt.MapFrom(src=>src.PublishDate.ToShortDateString()));

            Mapper.CreateMap<BookViewModel,Book>()
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate));
        }
    }
}