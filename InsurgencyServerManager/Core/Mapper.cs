using AutoMapper;
using InsurgencyServerManager.Data;
using InsurgencyServerManager.ViewModels;

namespace InsurgencyServerManager.Core;

public static class Mapper
{
    private static readonly IConfigurationProvider Configuration = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<ModEntry, ModEntryViewModel>().ReverseMap();
        cfg.CreateMap<ModEntry, ModEntryWindowViewModel>().ReverseMap();
    });

    private static readonly IMapper MapperCore = new AutoMapper.Mapper(Mapper.Configuration);

    public static T Map<T>(object? source)
    {
        return Mapper.MapperCore.Map<T>(source);
    }
}
