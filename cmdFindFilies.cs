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
            System.Console.WriteLine("Результаты поиска: ");
            foreach (FileInfo info in SingletonFiliesInfo.GetAllFileInfo())
            {
                if (tree.Search(info.tags)) System.Console.WriteLine("id: "+info.id+"| path:\n"+info.view_url+"\n");
            }
            return true;
        }
    }

}
