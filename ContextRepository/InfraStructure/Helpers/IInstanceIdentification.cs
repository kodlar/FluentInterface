using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextRepository.Enums;

namespace ContextRepository.InfraStructure.Helpers
{
    public interface IInstanceIdentification
    {
        string GetTypeId();

        InstanceIdenfiticationTypeEnum IdentificationType { get; }
    }
}
