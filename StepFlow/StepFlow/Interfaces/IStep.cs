using System;

namespace StepFlow
{
    public interface IStep : IDisposable
    {
        void Execute();
    }
}
