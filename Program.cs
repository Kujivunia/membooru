
using System;
using System.Collections.Generic;
using System.Text;
namespace membooru
{
    class Program
    {
        static void Main(string[] args)
        {

        SearchClient temp = new SearchClient();
            /*
            string exp = "";
            //foreach (string token in temp.SearchExpressionPreparing("rd || soarin && (!pie || kirin)"))
            foreach (string token in temp.SearchExpressionPreparing(exp))
            {
                Console.Write(token+"+");
            }
            Console.WriteLine();

            //IBinaryExpression tree = temp.GetBinaryExpressionTree(temp.SearchExpressionPreparing("rd || (soarin && !pie)"));
            IBinaryExpression tree = temp.GetBinaryExpressionTree(temp.SearchExpressionPreparing(exp));
            //List<string> tags = new List<string>();
            List<string> tags1 = new List<string>();
            List<string> tags2 = new List<string>();
            List<string> tags3 = new List<string>();
            tags1.Clear();
            tags1.Add("a");
            tags1.Add("b");
            tags1.Add("c");
            tags2.Clear();
            tags2.Add("c");
            tags2.Add("d");
            tags2.Add("e");
            tags3.Clear();
            tags3.Add("a");
            tags3.Add("e");
            Console.WriteLine(tree.Search(tags1));
            Console.WriteLine(tree.Search(tags2));
            Console.WriteLine(tree.Search(tags3));
            */

            /*tags.Add("rd0");
            tree.Search(tags);
            Console.WriteLine(tree.Search(tags));

            tags.Clear();
            tags.Add("rd");
            tree.Search(tags);
            Console.WriteLine(tree.Search(tags));

            tags.Clear();
            tags.Add("soarin");
            tags.Add("pie");
            tree.Search(tags);
            Console.WriteLine(tree.Search(tags));*/

            /*
            //5144
            FileInfo id5144 = new FileInfo();

            //string json = System.Text.Json.JsonSerializer.Serialize<FileInfo>(id5144);
            //Console.WriteLine(json);
            System.IO.StreamReader jsonreader = new System.IO.StreamReader("E:\\source\\repos\\membooru\\5144.json");
            string json = jsonreader.ReadToEnd();
           
            FileInfo restoredFileInfo = System.Text.Json.JsonSerializer.Deserialize<FileInfo>(json);
            Console.WriteLine(restoredFileInfo.source_url);
            Console.WriteLine(System.DateTime.Now);
            Console.WriteLine("---------------------------------------------");
            */
            
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
