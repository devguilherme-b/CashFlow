using AutoMapper;
using CashFlow.Application.AutoMapper;
using Microsoft.Extensions.Logging;

namespace CommomTestsUtilities.Mapper;
public class MapperBuilder
{
    public static IMapper Build(ILoggerFactory loggerFactory)
    {
        var mapper = new MapperConfiguration(config => 
        {
            config.AddProfile(new AutoMapping()); 
        }, loggerFactory);

        return mapper.CreateMapper();
    }
}
