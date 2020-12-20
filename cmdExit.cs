namespace membooru
{
    class cmdExit : ICommand
    {
        public bool Execute()
        {
            System.Environment.Exit(0);
            return true;
        }
    }

    class cmdCls : ICommand
    {
        public bool Execute()
        {
            System.Console.Clear();
            return true;
        }
    }
}
