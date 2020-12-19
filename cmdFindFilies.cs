using System.Collections.Generic;

namespace membooru
{
    class cmdFindFilies : ICommand
    {
        string path;
        List<string> tags = new List<string>();
        public cmdFindFilies(List<string> tokens)
        {
            path = tokens[0];
            tokens.RemoveAt(0);

        }
        public bool Execute()
        {
            SearchClient temp = new SearchClient();
            IBinaryExpression tree = temp.GetBinaryExpressionTree(temp.SearchExpressionPreparing("tags"));

            return true;
        }
    }

}
