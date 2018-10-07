using System.Collections.Generic;
using System.Linq;

namespace StepFlow
{
    public class EngineConfiguration
    {
        internal EngineConfiguration()
        {
            EntityConfigurations = new Dictionary<string, IEnumerable<EntityConfiguration>>();
        }

        internal Dictionary<string, IEnumerable<EntityConfiguration>> EntityConfigurations { get; set; }

        internal IEnumerable<EntityConfiguration> GetConfigurations(string entityId)
        {
            return EntityConfigurations.FirstOrDefault(x => x.Key == entityId).Value;
        }

    }
}
