using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{
    public interface IBinaryExpression
    {
        public bool Search(List<string> Tags);
    }
}
