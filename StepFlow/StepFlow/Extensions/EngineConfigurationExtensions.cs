using System;
using System.Collections.Generic;
using System.Linq;

namespace StepFlow
{
    public static class EngineConfigurationExtensions
    {
        public static void AddEntityConfiguration(this EngineConfiguration engineConfiguration, string entityId, IEnumerable<EntityConfiguration> entityConfigurations)
        {
            if (engineConfiguration.EntityConfigurations.Any(x => x.Key == entityId))
            {
                throw new Exception("Duplicate Entity Configurations");
            }
            engineConfiguration.EntityConfigurations.Add(entityId, entityConfigurations);
        }
    }
}
