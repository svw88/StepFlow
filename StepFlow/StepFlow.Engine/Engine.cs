using System;
using System.Collections.Generic;
using System.Linq;

namespace StepFlow
{
    public class Engine
    {
        public Engine()
        {
            WorkflowConfigurations = new Dictionary<string, WorkflowConfiguration>();
            Workflows = new Dictionary<Guid, Workflow>();
        }

        internal Dictionary<string, WorkflowConfiguration> WorkflowConfigurations { get; set; }

        internal Dictionary<Guid, Workflow> Workflows { get; set; }

        internal EngineConfiguration EngineConfiguration { get; set; }

        public Guid CreateWorkflow(string workflowId, string entityId)
        {

            if (WorkflowConfigurations.Any(x => x.Key == workflowId))
            {
                var workflowConfiguration = WorkflowConfigurations.First(x => x.Key == workflowId).Value;

                var workflow = new Workflow
                    (
                        workflowConfiguration,
                        EngineConfiguration.EntityConfigurations.Where(x => x.Key == entityId)
                                                                .SelectMany(x => x.Value)
                                                                .Where(x => workflowConfiguration.Steps.Select(a => a.Key).Contains(x.Step))
                    );

                Workflows.Add(workflow.Identifier, workflow);


                return workflow.Identifier;
            }
            else
            {
                throw new Exception($"Workflow {workflowId} Not Found");
            }

        }

        public Workflow GetWorkflow(Guid identifier)
        {
            return Workflows.FirstOrDefault(x => x.Key == identifier).Value;
        }
    }
}
