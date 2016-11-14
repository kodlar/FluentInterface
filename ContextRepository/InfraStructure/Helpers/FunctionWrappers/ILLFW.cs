using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextRepository.InfraStructure.Helpers.FunctionWrappers
{
    public interface ILLFW<out TResult, out TItem>
    {
        TResult Invoke();
    }
}
