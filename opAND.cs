using System;

namespace membooru
{
    class opAND : IExpressionOperator
    {
        public bool Execute(bool a, bool b = false)
        {
            return a && b;
        }
    }
}
