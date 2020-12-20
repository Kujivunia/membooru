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
                if (tree.Search(info.tags)) System.Console.WriteLine(info.id+" "+info.view_url);
            }
            return true;
        }
    }
    class cmdHelp : ICommand
    {
        string expression;
        List<string> tags = new List<string>();
        public bool Execute()
        {
            System.Console.WriteLine("Команды: \naddfile[путь][-метка 1]... [-метка 100500]\nДобавит в систему мембуры(далее \"систему\") файл, находящийся по пути(если в пути файла есть пробелы, путь следует указать в \"\" кавычках).Если после пути написать какие-то слова, разделяя их пробелами, то все эти слова добавятся как первые метки файла в системе.\n\naddtags[id][-метка 1]... [-метка 100500]\nДобавит к находящемуся в системе файлу с номером ID все перечисленные далее метки.\n\nremovefile[id]\nУдалит из системы файл с номером ID.\n\nfind[запрос]\nЗапрос должен соответствовать синтаксису поискового запроса. Команда выведет список всех файлов, которые соответствуют поисковому запросу. ");
            return true;
        }
    }
    class cmdError : ICommand
    {
        string expression;
        List<string> tags = new List<string>();
        public bool Execute()
        {
            System.Console.WriteLine( "Команда не распознана."  ); 
            return true;
        }
    }
    class cmdExit : ICommand
    {
        public bool Execute()
        {
            System.Environment.Exit(0);
            return true;
        }
    }
}
