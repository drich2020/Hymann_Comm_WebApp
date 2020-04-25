using AutoMapper;
using Hyman_Communication.Data;
using Hyman_Communication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Hyman_Communication.Mappings
{
    public class Maps : Profile
    {
       public Maps()
        {
            CreateMap<Data.Document, DocumentVM>().ReverseMap();
            CreateMap<DocumentCategory, DocumentCategoryVM>().ReverseMap();
            CreateMap<Market, MarketVM>().ReverseMap();
            CreateMap<Product, ProductVM>().ReverseMap();
            CreateMap<Promotion, PromotionVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
        }
    }
}
