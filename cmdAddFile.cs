using System.Collections.Generic;

namespace membooru
{
    class cmdAddFile : ICommand
    {
        string path,json;
        List<string> tags = new List<string>();
        FileInfo info = new FileInfo();
        public cmdAddFile(List<string> tokens)
        {
            path = tokens[0];
            tokens.RemoveAt(0);
            info.tags = new List<string>();
            tokens.ForEach(token => info.tags.Add(token));
            info.view_url = path;
            
            info.id = SingletonGlobalID.GetNewID();
        }
        private async void write()
        {
            info.created_at = System.DateTime.Now;
            SingletonFiliesInfo.AddFileInfo(info);
            json = System.Text.Json.JsonSerializer.Serialize<FileInfo>(info);
            System.IO.StreamWriter jsonwriter = new System.IO.StreamWriter(System.IO.Directory.GetCurrentDirectory() + "\\jsons\\" + info.id + ".json", false, System.Text.Encoding.Default);
            await jsonwriter.WriteLineAsync(json);
            jsonwriter.Close();
        }
        public bool Execute()
        {
            write();
            return true;
        }
    }

}
