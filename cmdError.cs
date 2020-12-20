using System.Collections.Generic;

namespace membooru
{
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
}
