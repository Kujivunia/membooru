using System.Collections.Generic;

namespace membooru
{
    public class BinaryExpressionRoot : IBinaryExpression
    {
        public BinaryExpressionRoot(IBinaryExpression l = null)
        {
            this.l = l;
        }
        public IBinaryExpression l { get; set; }
        public bool Search(List<string> Tags)
        {
            return l.Search(Tags);
        }
    }
}