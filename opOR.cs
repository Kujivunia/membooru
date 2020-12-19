using System;

namespace membooru
{
    class opOR : IExpressionOperator
    {   
        public bool Execute(bool a, bool b = false)
        {
            return a || b;
        }
    }
}
