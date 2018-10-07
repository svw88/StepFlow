using System;

namespace StepFlow
{
    public class EntityConfiguration
    {
        public static EntityConfiguration Create<TStep, TFeature>(int orderId, params object[] dependencies)
            where TStep : IStep
            where TFeature : IStep

        {
            var entityConfiguration = new EntityConfiguration();
            entityConfiguration.Step = typeof(TStep);
            entityConfiguration.Feature = typeof(TFeature);
            entityConfiguration.OrderId = orderId;
            entityConfiguration.Dependencies = dependencies;

            return entityConfiguration;
        }

        internal Type Step { get; set; }

        internal Type Feature { get; set; }

        internal int OrderId { get; set; }

        internal object[] Dependencies { get; set; }

    }
}
