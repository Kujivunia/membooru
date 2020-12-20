using System.Collections.Generic;

namespace membooru
{
    class cmdAddTags : ICommand
    {
        string path, json;
        int id;
        List<string> tags = new List<string>();
        List<string> tokens = new List<string>();
        FileInfo info = new FileInfo();
        public cmdAddTags(List<string> tokens)
        {
            tokens.ForEach(token => tags.Add(token));
            id = int.Parse(tokens[0]);
            tokens.RemoveAt(0);
            info = SingletonFiliesInfo.GetFileInfoFromID(id);
            foreach (string token in tags)
            {
                if (!info.tags.Contains(token)) info.tags.Add(token);
            }
        }
        public bool Execute()
        {
            SingletonFiliesInfo.RemoveFileInfo(id);
            SingletonFiliesInfo.AddFileInfo(info);
            new cmdAddFile(tags);
            return true;
        }
    }

}
