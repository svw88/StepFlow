using System;

namespace StepFlow.Test.Steps
{
    public abstract class TestStep1 : IStep
    {
        public void Dispose()
        {
           
        }

        public virtual void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
