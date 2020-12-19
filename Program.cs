
using System;
using System.Collections.Generic;
using System.Text;
namespace membooru
{ 
    class Program
    {
        static void Main(string[] args)
        {

        List<string> tokenss = Tokenizer.Tokenize(" Spitfire && safe || (Spitfire && (Soarin || !rd!) || Spitfire && airplane)");
        tokenss = Tokenizer.Tokenize(" ( (Spitfire&&safe)||(Spitfire && (Soarin || rd) ) ) || (Spitfire && airplane)");
        //foreach (string s in tokenss)
        //        Console.WriteLine("|" + s + "|");
        foreach (string s in tokenss)
                Console.Write(s+" ");

        SearchClient temp = new SearchClient();

        IBinaryExpression tree = temp.GetBinaryExpressionTree(tokenss);
            List<string> queu = new List<string>();
            queu.Add("spitfire");
            queu.Add("rdo");
            Console.WriteLine();
            foreach (string s in queu)
                Console.Write(s + " ");
            Console.WriteLine();
            Console.WriteLine(tree.Search(queu));


            tokenss.Clear();
            tokenss.Add("(");
            tokenss.Add("spitfire");
            tokenss.Add("||");
            tokenss.Add("rd");
            tokenss.Add(")");
            tokenss.Add("&&");
            tokenss.Add("soarin");
            foreach (string s in temp.FullBracketing(tokenss))
                   Console.Write(s + "+");

        }
    }
}
