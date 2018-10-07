using System;
using System.Collections.Generic;

namespace StepFlow
{
    public class WorkflowConfiguration
    {
        internal WorkflowConfiguration()
        {
            Steps = new Dictionary<Type, IEnumerable<Type>>();
        }
        internal Dictionary<Type, IEnumerable<Type>> Steps { get; set; }


    }
}
