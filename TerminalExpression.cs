using System.Collections.Generic;

namespace membooru
{
    public class TerminalExpression : IBinaryExpression
    {
        public TerminalExpression(string Token, bool Negation = false)
        {
            this.Token = Token;
        }
        public string Token { get; set; }
        public bool Search(List<string> Tags)
        {
            if (Tags.Contains(Token)) 
                return true; 
            else 
                return false;

        }
    }
}