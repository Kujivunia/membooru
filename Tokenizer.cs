using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{
    class Tokenizer
    {
        public static List<string> Tokenize(string query)
        {
            List<string> tokens = new List<string>();
            tokens.Clear();
            query = query.ToLower();
            query = query.Trim();
            query = query + " ";
            tokens.Add("(");
            StringBuilder currentToken = new StringBuilder();
            foreach (char ch in query) 
            {                
                if (ch.Equals('!') == true || ch.Equals('(') == true || ch.Equals(')') == true)
                { tokens.Add(currentToken.ToString()); currentToken.Clear(); }

                if (ch.Equals(' ') == false) currentToken.Append(ch);
                else
                { tokens.Add(currentToken.ToString()); currentToken.Clear(); }

                if (ch.Equals('!') == true || ch.Equals('(') == true || ch.Equals(')') == true)
                { tokens.Add(currentToken.ToString()); currentToken.Clear(); }

            }
            
            tokens.RemoveAll(item => item.Equals(""));
            tokens.Add(")");
            return tokens;
        }
    }
}
