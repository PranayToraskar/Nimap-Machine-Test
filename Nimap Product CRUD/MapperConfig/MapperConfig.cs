using AutoMapper;

using System.Runtime;

namespace Nimap_Product_CRUD.MapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Contarcts.Product, Models.Product>().ReverseMap();
            CreateMap<Contarcts.Category, Models.Category>().ReverseMap();
            CreateMap<Contarcts.DataParameterList, Models.DataParameterList>().ReverseMap();
            CreateMap<Contarcts.DropDownSource, Models.DropDownSource>().ReverseMap();
        }
    }
}
