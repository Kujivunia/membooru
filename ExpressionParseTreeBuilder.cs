/*
using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{
    class ExpressionParseTreeBuilder : IExpressionParseTreeBuilder
    {
        private List<string> tokens = new List<string>();
        private StringBuilder query;
        
        public void Bracketing()
        {
            throw new NotImplementedException();
        }

        public void BracketingPreparing()
        {
            throw new NotImplementedException();
        }

        public IExpressionParseTree BuildExpressionParseTree(string query)
        {
            this.SetSearchString(query);
            Bracketing();
            BracketingPreparing();
            return MakeExpressionParseTree();
        }

        public IExpressionParseTree MakeExpressionParseTree()
        {
            if (tokens.Count < 1) throw new NotImplementedException();
            IExpressionParseTree root = new NonTerminalExpression(null, null, null, null);
            IExpressionParseTree currentNode = root;
            int i = 1;

            int CountNOT = 0;
            foreach (string token in this.tokens)
            {
                if (token.Contains("!")) CountNOT++;
            }

            int[] nots;
            if (CountNOT>0)
                nots = new int[CountNOT];

            foreach (string token in this.tokens)
            {
                if (token.Equals("("))
                {
                    if (tokens[i].Equals("(") || tokens[i].Equals("||") || tokens[i].Equals("!") || tokens[i].Equals("&&") || tokens[i].Equals(")")) 
                        currentNode.AddLeft(new NonTerminalExpression(null,null,null,currentNode));
                    else
                        currentNode.AddLeft(new TerminalExpression(null, currentNode));

                    currentNode = currentNode.GetLeft();
                }
                if (token.Equals(")"))
                {
                    currentNode = currentNode.GetParent();
                }
                if (token.Equals("&&") || token.Equals("||"))
                {
                    //currentNode.SetToken(token);

                    if (tokens[i].Equals("(") || tokens[i].Equals("||") || tokens[i].Equals("!") || tokens[i].Equals("&&") || tokens[i].Equals(")"))
                        currentNode.AddRight(new NonTerminalExpression(null, null, null, currentNode));
                    else
                        currentNode.AddRight(new TerminalExpression(null, currentNode));

                    currentNode = currentNode.GetRight();
                }
                if (token.Equals("!"))
                {
                    currentNode.SetToken(token);

                    if (tokens[i].Equals("(") || tokens[i].Equals("||") || tokens[i].Equals("!") || tokens[i].Equals("&&") || tokens[i].Equals(")"))
                        currentNode.AddLeft(new NonTerminalExpression(null, null, null, currentNode));
                    else
                        currentNode.AddLeft(new TerminalExpression(null, currentNode));

                    currentNode = currentNode.GetLeft();
                }
                else
                {
                    currentNode.SetToken(token);
                    currentNode = currentNode.GetParent();
                }
            i++;
            }


            return root;
        }

        public void SetSearchString(string query)
        {
            this.query = new StringBuilder(query);
            this.tokens = Tokenizer.Tokenize(query);
        }
    }
}
*/