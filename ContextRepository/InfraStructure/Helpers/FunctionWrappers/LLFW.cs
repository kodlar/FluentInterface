using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextRepository.InfraStructure.Helpers.FunctionWrappers
{
    public class LLFW<TResult, TItem> : ILLFW<TResult, TItem>
    {
        private readonly Func<TResult> _factory;

        public LLFW(Func<TResult> factory)
        {
            this._factory = factory;
        }

        public TResult Invoke()
        {
            return _factory();
        }
    }
}
