using System;

namespace StepFlow
{
    public static class EngineExtensions
    {
        public static Engine ConfigureWorkflow(this Engine engine, string workflowId, Action<WorkflowConfiguration> configuration)
        {
            var config = new WorkflowConfiguration();

            configuration.Invoke(config);

            engine.WorkflowConfigurations.Add(workflowId, config);

            return engine;
        }

        public static Engine ConfigureEngine(this Engine engine, Action<EngineConfiguration> configuration)
        {
            var config = new EngineConfiguration();

            configuration.Invoke(config);

            engine.EngineConfiguration = config;

            return engine;
        }
    }
}
