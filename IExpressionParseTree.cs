using System.Collections.Generic;
using System.Text;

namespace membooru
{
    interface IExpressionParseTree
    {
        bool Search(List<string> Tags);
        void AddLeft(IExpressionParseTree element);
        void AddRight(IExpressionParseTree element);
        void SetToken(string token);
        void SetSign(IExpressionOperator Sign);
        IExpressionParseTree GetParent();
        IExpressionParseTree GetLeft();
        IExpressionParseTree GetRight();
    }
}
