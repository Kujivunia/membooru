using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{
    public class Disjunction : IBinaryExpression //ИЛИ
    {
        public Disjunction(IBinaryExpression l = null, IBinaryExpression r = null)
        {
            this.l = l;
            this.r = r;
        }
        public IBinaryExpression l { get; set; }
        public IBinaryExpression r { get; set; }
        public bool Search(List<string> Tags)
        {
            return l.Search(Tags) || r.Search(Tags);
        }
    }
}