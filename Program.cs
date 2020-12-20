
using System;
using System.Collections.Generic;
using System.Text;
namespace membooru
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            foreach (string file in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory() + "\\jsons\\", "*.json"))
            {
                int a = (System.IO.Directory.GetCurrentDirectory() + "\\jsons\\").Length;
                int b = file.Length - 5;
                if (int.Parse(file.Substring(a, b-a)) > max) 
                    max = int.Parse(file.Substring(a, b - a));
            }
            SingletonGlobalID.SetGlobalID(max);
            foreach (string file in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()+"\\jsons\\", "*.json"))
            {
                    new cmdLoadJson(file).Execute();
            }
            TextToCommand ttc = new TextToCommand();
            while (true)
            {
            Console.Write(">");
            ttc.Interpret(Console.ReadLine()).Execute();
            }
            

        }
    }

}
