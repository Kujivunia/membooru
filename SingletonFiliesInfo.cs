namespace membooru
{
    class SingletonFiliesInfo
    {
        private SingletonFiliesInfo() { }

        private static System.Collections.Generic.List<FileInfo> FiliesInfo = new System.Collections.Generic.List<FileInfo>();
        public static FileInfo GetFileInfoFromID(int id)
        {
            return FiliesInfo.Find(f => f.id == id);
        }
        public static System.Collections.Generic.List<FileInfo> GetAllFileInfo()
        {
            return FiliesInfo;
        }
        public static bool AddFileInfo(FileInfo info)
        {
            FiliesInfo.Add(info);
            return true;
        }
        public static bool RemoveFileInfo(int id)
        {
            FiliesInfo.Remove(FiliesInfo.Find(f => f.id == id));
            return true;
        }
    }
}
