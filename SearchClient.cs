using System;
using System.Collections.Generic;
using System.Text;

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
        private List<string> ExtractLowBracket(List<string> tokens)
        {
            int lastOpenBracket = 0;
            int closeBracket = 0;
            List<string> subBracket = new List<string>();
            int i = 0;

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
            for (int j = lastOpenBracket; j <= closeBracket; j++)
            {
                subBracket.Add(tokens[j]);
            }
            return subBracket;
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
                //if (currentNode != null) Console.WriteLine("current token: " + token + "; current node: " + currentNode.token);
            }
            return root;

        }

        public IBinaryExpression GetBinaryExpressionTree(List<string> tokens)
        {
            IBinaryExpression root = null; ;
            root = this.PreBuild(tokens).GetExpressionTree();
            return root;
        }

    }
}
