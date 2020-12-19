namespace membooru
{
    interface IExpressionParseTreeBuilder
    {
        void SetSearchString(string query);
        void BracketingPreparing();
        void Bracketing();
        IExpressionParseTree MakeExpressionParseTree();
        IExpressionParseTree BuildExpressionParseTree(string query);
    }
}
