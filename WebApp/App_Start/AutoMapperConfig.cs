using AutoMapper;
using Library.Model.Models;
using Library.Web.ViewModels;
using Library.WebPr.ViewModels;

namespace Library.WebPr.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.ToString("f")))
                .ForMember(dest => dest.BookShelfId, opt => opt.MapFrom(src => src.BookShelf.Id));

            Mapper.CreateMap<BookViewModel,Book>()
                .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate));

            Mapper.CreateMap<Storage, StorageViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StorageName))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.StrorageNumber));

            Mapper.CreateMap<StorageViewModel, Storage>()
                .ForMember(dest => dest.StorageName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StrorageNumber, opt => opt.MapFrom(src => src.Number));

            Mapper.CreateMap<BookShelf, BookShelfViewModel>()
                .ForMember(dest => dest.StorageId, opt => opt.MapFrom(src => src.Storage.Id));

            Mapper.CreateMap<BookShelfViewModel, BookShelf>();
        }
    }
}