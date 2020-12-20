
using System;
using System.Collections.Generic;
using System.Text;
namespace membooru
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string file in System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory()+"\\jsons", "*.json"))
            {
                    new cmdLoadJson(file).Execute();
            }
            TextToCommand ttc = new TextToCommand();
            while (true)
            {
            string cmd = "";
            Console.Write(">");
            cmd = Console.ReadLine();
                ttc.Interpret(cmd).Execute();
            }
            

        }
    }

}
