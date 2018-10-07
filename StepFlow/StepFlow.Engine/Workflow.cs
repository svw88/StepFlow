using System;
using System.Collections.Generic;
using System.Linq;

namespace StepFlow
{
    public class Workflow
    {
        internal WorkflowConfiguration WorkflowConfiguration { get; set; }

        internal IEnumerable<EntityConfiguration> EntityConfigurations { get; set; }

        internal Guid Identifier { get; set; }

        internal int CurrentStep { get; set; }

        internal Workflow(WorkflowConfiguration workflowConfiguration, IEnumerable<EntityConfiguration> entityConfigurations)
        {
            WorkflowConfiguration = workflowConfiguration;

            EntityConfigurations = entityConfigurations;

            CurrentStep = 0;

            Identifier = Guid.NewGuid();
        }

        public void ExecuteNextStep()
        {
            CurrentStep++;
            var type = EntityConfigurations.FirstOrDefault(x => x.OrderId == CurrentStep);
            var instance = (IStep)Activator.CreateInstance(type.Feature, type.Dependencies);

            instance.Execute();
            instance.Dispose();

        }

        public void ExecuteSameStep()
        {
            var type = EntityConfigurations.FirstOrDefault(x => x.OrderId == CurrentStep);
            var instance = (IStep)Activator.CreateInstance(type.Feature, type.Dependencies);

            instance.Execute();
            instance.Dispose();

        }

        public void ExecutePreviousStep()
        {
            CurrentStep--;
            var type = EntityConfigurations.FirstOrDefault(x => x.OrderId == CurrentStep);
            var instance = (IStep)Activator.CreateInstance(type.Feature, type.Dependencies);

            instance.Execute();
            instance.Dispose();

        }

        public void ExecuteSpecificStep(int orderId)
        {
            CurrentStep = orderId;
            var type = EntityConfigurations.FirstOrDefault(x => x.OrderId == CurrentStep);
            var instance = (IStep)Activator.CreateInstance(type.Feature, type.Dependencies);

            instance.Execute();
            instance.Dispose();



        }

    }
}
