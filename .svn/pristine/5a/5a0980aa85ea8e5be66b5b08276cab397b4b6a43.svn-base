using System.Collections.Generic;

namespace Myzj.OPC.UI.Assembler
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource tSource)
            where TSource : class
            where TDestination : class;

        List<TDestination> MappGereric<TSource, TDestination>(IEnumerable<TSource> tSources)
            where TSource : class
            where TDestination : class;
    }
}
