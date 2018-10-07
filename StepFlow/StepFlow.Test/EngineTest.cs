using Microsoft.VisualStudio.TestTools.UnitTesting;
using StepFlow.Test.Features;
using StepFlow.Test.Steps;
using System.Collections.Generic;

namespace StepFlow.Test
{
    [TestClass]
    public class EngineTest
    {
        public Engine engine;

        public EngineTest()
        {
            engine = new Engine().ConfigureWorkflow("Order", config =>
             {
                 config.AddStep<TestStep1>();
                 config.AddStep<TestStep2>();
             })
            .ConfigureEngine(config =>
            {
                config.AddEntityConfiguration("1",new List<EntityConfiguration>
                {
                    EntityConfiguration.Create<TestStep1, TestStep1Feature2>(2),
                    EntityConfiguration.Create<TestStep2, TestStep2Feature1>(1)
                });
            });
        }

        [TestMethod]
        public void TestMethod1()
        {
           var id = engine.CreateWorkflow("Order", "1");

            engine.GetWorkflow(id).ExecuteNextStep();

            engine.GetWorkflow(id).ExecuteNextStep();
        }
    }
}
