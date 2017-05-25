using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaunchPad.Mappings
{
    public class AutoMapperConfiguration
    {
        public class NullStringConverter : ITypeConverter<string, string>
        {
            public string Convert(string source)
            {
                return source =="" ? null: source;
            }

            public string Convert(string source, string destination, ResolutionContext context)
            {
                return source == "" ? null : source;
            }
        }
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AllowNullDestinationValues = true;
                x.CreateMap<string, string>().ConvertUsing<NullStringConverter>();
            });
        }
    }
}