using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{
    class NonTerminalExpression : IExpressionParseTree
    {
        public IExpressionParseTree a, b;

        IExpressionParseTree parent = null;
        public IExpressionOperator Sign { get; set; }
        private string token;
        public NonTerminalExpression(IExpressionOperator sign = null, IExpressionParseTree a = null, IExpressionParseTree b = null, IExpressionParseTree p = null)
        {
            this.Sign = sign;
            this.a = a;
            this.b = b;
            this.parent = p;
        }

        public void AddLeft(IExpressionParseTree element)
        {
            this.a = element;
        }

        public void AddRight(IExpressionParseTree element)
        {
            this.b = element;
        }

        public IExpressionParseTree GetParent()
        {
            return this.parent;
        }

        public IExpressionParseTree GetLeft()
        {
            return this.a;
        }
        public IExpressionParseTree GetRight()
        {
            return this.b;
        }
        public bool Search(List<string> Tags)
        {
            if (b == null)
                return Sign.Execute(a.Search(Tags));
            else
                return Sign.Execute(a.Search(Tags), b.Search(Tags));
        }

        public void SetToken(string token)
        {
            this.token = token;
        }

        public void SetSign(IExpressionOperator Sign)
        {
            this.Sign = Sign;
        }
    }

}
