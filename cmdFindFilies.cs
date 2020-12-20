using System.Collections.Generic;

namespace membooru
{
    class cmdFindFilies : ICommand
    {
        string expression;
        List<string> tags = new List<string>();
        public cmdFindFilies(List<string> tokens)
        {
            tokens.ForEach(token => expression += (token+" ")) ;
        }
        public bool Execute()
        {
            SearchClient temp = new SearchClient();
            IBinaryExpression tree = temp.GetBinaryExpressionTree(temp.SearchExpressionPreparing(expression));
            foreach (FileInfo info in SingletonFiliesInfo.GetAllFileInfo())
            {
                if (tree.Search(info.tags)) System.Console.WriteLine(info.id+" "+info.view_url);
            }
            return true;
        }
    }

}
