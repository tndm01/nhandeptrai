using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NNShop.Model.Models;
using NNShop.Web.Models;

namespace NNShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();
            Mapper.CreateMap<ProductTag, ProductTagViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}