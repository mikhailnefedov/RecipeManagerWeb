using AutoMapper;
using RecipeManagerWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManagerWebTest.Utilities
{
    public class AutoMapperUtility
    {
        public static IMapper GetConfiguration()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(typeof(AutoMapperProfile));
            });
            IMapper mapper = mappingConfig.CreateMapper();

            return mapper;
        }
    }
}
