namespace membooru
{
    interface IExpressionOperator
    {
        bool Execute(bool a, bool b = false);
    }
}
