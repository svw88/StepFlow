using System;

namespace StepFlow.Test.Steps
{
    public abstract class TestStep2 : IStep
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }

        public virtual void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
