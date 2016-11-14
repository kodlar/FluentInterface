using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextRepository.InfraStructure.Helpers.FunctionWrappers
{
    public interface ILFW<out TResult>
    {
        TResult Invoke();

        IInstanceIdentification GetInstanceIdentifier();
    }
}
