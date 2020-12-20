namespace membooru
{
    class cmdLoadJson : ICommand
    {
        string path,json;
        bool error;
        FileInfo info = new FileInfo();
        public cmdLoadJson(string path)
        {
            this.path = path;
        }

        private async void read()
        {
            try
            {
            System.IO.StreamReader jsonreader = new System.IO.StreamReader(path, System.Text.Encoding.Default);
            json = await jsonreader.ReadToEndAsync();
            jsonreader.Close();
            info = System.Text.Json.JsonSerializer.Deserialize<FileInfo>(json);
            SingletonFiliesInfo.AddFileInfo(info);
            }
            catch (System.Exception)
            {
                error = true;
            } 
            
        }
        public bool Execute()
        {
            read();
            
            return true;
        }
    }

}
