
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
            foreach (string token in temp.SearchExpressionPreparing("rd || soarin && (!pie || kirin)"))
            {
                Console.Write(token+"+");
            }
            Console.WriteLine();

        IBinaryExpression tree = temp.GetBinaryExpressionTree(temp.SearchExpressionPreparing("rd || (soarin && !pie)"));
        List<string> tags = new List<string>();

            tags.Add("rd0");
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
            Console.WriteLine(tree.Search(tags));


            //5144
            FileInfo id5144 = new FileInfo();

            //string json = System.Text.Json.JsonSerializer.Serialize<FileInfo>(id5144);
            //Console.WriteLine(json);
            System.IO.StreamReader jsonreader = new System.IO.StreamReader("E:\\source\\repos\\membooru\\5144.json");
            string json = jsonreader.ReadToEnd();

            FileInfo restoredFileInfo = System.Text.Json.JsonSerializer.Deserialize<FileInfo>(json);
            Console.WriteLine(restoredFileInfo.source_url);
        }
    }

}
