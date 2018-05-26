using Myzj.OPC.UI.Assembler.Impl;

namespace Myzj.OPC.UI.Assembler.External
{
    public class AssemblerIoc
    {
        private static IMapper _mapper;
        public static IMapper GetMapper()
        {
            if (null == _mapper)
            {
                _mapper = new MapperImpl();
            }
            return _mapper;
        }
    }
}
