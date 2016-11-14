using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextRepository.InfraStructure.Helpers.FunctionWrappers
{

    public class LFW<TResult> : ILFW<TResult>
    {
        private readonly Func<TResult> _factory;

        private readonly IInstanceIdentification _instanceIdentifier;

        public LFW(Func<TResult> factory, IInstanceIdentification instanceIdentifier)
        {
            this._factory = factory;
            this._instanceIdentifier = instanceIdentifier;
        }

        public TResult Invoke()
        {
            return _factory();
        }

        public IInstanceIdentification GetInstanceIdentifier()
        {
            return _instanceIdentifier;
        }
    }

}
