namespace membooru
{
    class opNOT : IExpressionOperator
    {
        public bool Execute(bool a, bool b = false)
        {
            return !a;
        }
    }
}
