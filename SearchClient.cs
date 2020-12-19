using System;
using System.Collections.Generic;

namespace membooru
{
    class Node
    {
        public Node(Node p = null)
        {
            this.p = p;
        }
        public Node p;
        public Node l, r;
        public string token = "";
        public IBinaryExpression GetExpressionTree()
        {
            if (token.Equals("&&")) return new Conjunction(l.GetExpressionTree(),r.GetExpressionTree());
            if (token.Equals("||")) return new Disjunction(l.GetExpressionTree(), r.GetExpressionTree());
            if (token.Equals("!")) return new Negation(l.GetExpressionTree());
            else return new TerminalExpression(token);
        }
    }
    class SearchClient
    {
        public List<string> ExtractLowBracket(List<string> tokens)
        {
            int lastOpenBracket = 0;
            int closeBracket = 0;
            List<string> subBracket = new List<string>();
            int i = 0;
            /*
            foreach (string token in tokens)
            {
                if (token.Equals("("))
                {
                    lastOpenBracket = i;
                }
                i++;
            }

            for (int j = lastOpenBracket; j < tokens.Count - 1; j++)
            {
                if (tokens[j].Equals(")"))
                {
                    closeBracket = j;
                    break;
                }

            }
            */
            lastOpenBracket = ExtractLowBracketIndexs(tokens)[0];
            closeBracket = ExtractLowBracketIndexs(tokens)[1];

            for (int j = lastOpenBracket + 1; j < closeBracket; j++)
            {
                subBracket.Add(tokens[j]);
            }
            
            if (lastOpenBracket == closeBracket) return new List<string>();
            else
                return subBracket;
        }
        public int[] ExtractLowBracketIndexs(List<string> tokens)
        {
            int[] result = new int[2];
            List<string> subBracket = new List<string>();
            int i = 0;

            foreach (string token in tokens)
            {
                if (token.Equals("("))
                {
                    result[0] = i;
                }
                i++;
            }

            for (int j = result[0]; j < tokens.Count - 1; j++)
            {
                if (tokens[j].Equals(")"))
                {
                    result[1] = j;
                    break;
                }
            }

            return result;
        }
            public List<string> Bracketing(List<string> tokens)
        {
            string[] opPriority = new string[2];
            List<string> operators = new List<string>();
            List<string> operands = new List<string>();
            opPriority[0] = "&&";
            opPriority[1] = "||";
            while (tokens.Contains("!"))
                for (int i = 0; i < tokens.Count; i++)
                {
                    if (tokens[i].Equals("!"))
                    {
                        tokens[i + 1] = "!" + tokens[i + 1];
                        tokens.RemoveAt(i);
                    }
                }
            foreach (string token in tokens)
            {
                if (token.Equals("&&") || token.Equals("||"))
                {
                    operators.Add(token);
                }
                else
                {
                    operands.Add(token);
                }
            }
            string temp = "";
            for (int priority = 0; priority < opPriority.Length; priority++)
            { 
                for (int i = operators.Count-1; i >=0; i--)
                {
                    if (operators[i].Equals(opPriority[priority]))
                    {
                        temp = "(" + " " + operands[i] + " " + operators[i] + " " + operands[i+1] + " " + ")";
                        operands[i] = temp;
                        operators.RemoveAt(i);
                        operands.RemoveAt(i+1);
                    }
                }
            }

            return operands;
        }
        public List<string> FullBracketing(List<string> tokens)
        {
            /*
            List<string> temp = new List<string>();
            while (tokens.Count > 3)
            {
                temp.Clear();
                temp.Add("(");
                if (this.ExtractLowBracket(tokens).Count>0)
                {
                    temp.AddRange(this.Bracketing(this.ExtractLowBracket(tokens)));
                    foreach (string s in tokens)
                        Console.Write(s + "+");
                    Console.WriteLine("end low");
                }
                else
                {
                    temp.AddRange(this.Bracketing(tokens));
                    foreach (string s in tokens)
                        Console.Write(s + "+");
                    Console.WriteLine("end just");
                }
                temp.Add(")");
                tokens = temp;
                foreach (string s in tokens)
                    Console.Write(s + "+");
                Console.WriteLine("end iteration");
            }
            */
            List<string> temp = new List<string>();
            int[] brix = new int[2];
            while (tokens.Count > 1)
            {
                temp.Clear();
                if (this.ExtractLowBracket(tokens).Count > 0)
                {
                    brix = this.ExtractLowBracketIndexs(tokens);
                    temp.AddRange(this.Bracketing(this.ExtractLowBracket(tokens)));
                    tokens[brix[0]] = temp[0];
                    tokens.RemoveRange(brix[0]+1,brix[1]-brix[0]);
                }
                else
                {
                    temp.AddRange(this.Bracketing(tokens));
                    tokens = temp;
                }
            }
                return tokens;
        }
            private Node PreBuild(List<string> tokens)
        {
            Node root = new Node();
            Node currentNode = root;
            foreach (string token in tokens)
            {
                switch (token)
                {
                    case "(":
                        {
                            currentNode.l = new Node(currentNode);
                            currentNode = currentNode.l;
                            break;
                        }
                    case ")":
                        {
                            currentNode = currentNode.p;
                            break;
                        }
                    case "&&":
                        {
                            currentNode.token = token;
                            currentNode.r = new Node(currentNode);
                            currentNode = currentNode.r;
                            break;
                        }
                    case "||":
                        {
                            currentNode.token = token;
                            currentNode.r = new Node(currentNode);
                            currentNode = currentNode.r;
                            break;
                        }
                    case "!":
                        {
                            currentNode.token = token;
                            currentNode.l = new Node(currentNode);
                            currentNode = currentNode.l;
                            break;
                        }
                    default:
                        {
                            currentNode.token = token;
                            currentNode = currentNode.p;
                            break;
                        }
                }

                if (currentNode != null && currentNode.token.Equals("!") ) currentNode = currentNode.p;
            }
            return root;

        }

        public IBinaryExpression GetBinaryExpressionTree(List<string> tokens)
        {
           /* while (tokens.Contains("("))
            {
                tokens = this.Bracketing(this.ExtractLowBracket(tokens));
            }
            tokens = Bracketing(tokens);*/
            IBinaryExpression root = null; ;
            root = this.PreBuild(tokens).GetExpressionTree();
            return root;
        }

    }
}
