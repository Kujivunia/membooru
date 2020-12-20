namespace membooru
{
    class SingletonGlobalID
    {
        private SingletonGlobalID() { }

        private static int globalID;
        public static int GetNewID()
        {
            globalID++;
            return globalID;
        }
        public static int GetCurrentID()
        {
            return globalID;
        }
        public static bool SetGlobalID(int ID)
        {
            globalID = ID;
            return true;
        }
    }
}
