using AutoMapper;
using Bootcamp.Workshop.Business.Engines.Models;
using Bootcamp.Workshop.Data.Entities;

namespace Bootcamp.Workshop.Business.Engines.Infrastructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
        }
    }
}
