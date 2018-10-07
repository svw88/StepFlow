using System.Linq;
using System.Reflection;

namespace StepFlow
{
    public static class WorkflowConfigurationExtensions
    {
        public static void AddStep<IStep>(this WorkflowConfiguration workflowConfiguration) where IStep: StepFlow.IStep
        {
            var featureType = Assembly.GetCallingAssembly().GetTypes().Where(x => x.BaseType == typeof(IStep));
            workflowConfiguration.Steps.Add(typeof(IStep), featureType);
        }
    }
}
