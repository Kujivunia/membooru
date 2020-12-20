using System.Collections.Generic;

namespace membooru
{
    class cmdRemoveFile : ICommand
    {
        int id;
        List<string> tags = new List<string>();
        public cmdRemoveFile(List<string> tokens)
        {
            id = int.Parse(tokens[0]);
            
        }

        public bool Execute()
        {
            System.IO.File.Delete(System.IO.Directory.GetCurrentDirectory()+"\\jsons\\"+id +".json");
            SingletonFiliesInfo.RemoveFileInfo(id);
            return true;
        }
    }

}
