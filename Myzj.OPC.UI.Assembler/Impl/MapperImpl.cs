using System.Collections.Generic;
using System.Linq;
using EmitMapper;

namespace Myzj.OPC.UI.Assembler.Impl
{
    public class MapperImpl : IMapper
    {
        public TDestination Map<TSource, TDestination>(TSource tSource)
            where TSource : class
            where TDestination : class
        {
            TDestination tDestination = null;
            if (null != tSource)
            {
                var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TSource, TDestination>();
                tDestination = mapper.Map(tSource);
            }
            return tDestination;
        }

        public List<TDestination> MappGereric<TSource, TDestination>(IEnumerable<TSource> tSources)
            where TSource : class
            where TDestination : class
        {
            List<TDestination> tDestinations = null;
            if (tSources != null && tSources.Any())
            {
                tDestinations = new List<TDestination>();
                foreach (TSource tSource in tSources)
                {
                    tDestinations.Add(Map<TSource, TDestination>(tSource));
                }
            }
            return tDestinations;
        }
    }
}
