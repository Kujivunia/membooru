using System.Collections.Generic;

namespace membooru
{
    class cmdAddTags : ICommand
    {
        string path;
        List<string> tags = new List<string>();
        public cmdAddTags(List<string> tokens)
        {
            path = tokens[0];
            tokens.RemoveAt(0);

        }
        public bool Execute()
        {

            return true;
        }
    }

}
