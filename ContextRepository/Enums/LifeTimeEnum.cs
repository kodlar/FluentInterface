using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextRepository.Enums
{
    public enum LifeTimeEnum
    {
        /// <summary>
        /// Provides new instance for service between each scope. Scopes can be manually specified or auto generated. 
        /// Meaning of scope may different for each IoC container provider. How a scope starts and ends can change for each application type (Like MVC, WebApi,...).
        /// Some IoC providers can auto starts and auto ends a scope for specific kind of scenarios (Like web request...)
        /// </summary>
        Scoped,

        /// <summary>
        /// Single instance for a service through out the entire lifetime of an IoC container.
        /// </summary>
        Singleton,

        /// <summary>
        /// Everytime an instance for a service requested from container, new instance for this service type will be generated
        /// </summary>
        New
    }
}
