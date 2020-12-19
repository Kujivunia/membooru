using System.Collections.Generic;

namespace membooru
{
    public class Negation : IBinaryExpression //НЕ
    {
        public Negation(IBinaryExpression l = null)
        {
            this.l = l;
        }
        public IBinaryExpression l { get; set; }
        public bool Search(List<string> Tags)
        {
           return !(l.Search(Tags));
        }
    }
}