
using System;
using System.Collections.Generic;
using System.Text;

namespace membooru
{

    class TextToCommand 
    {
        private List<string> TextCommandTokenizer(string commandText)
        {
            List<string> tokens = new List<string>();
            bool TokenWithSpace = false;
            tokens.Clear();
            commandText = commandText.ToLower();
            commandText = commandText.Trim();
            commandText = commandText + " ";
            StringBuilder currentToken = new StringBuilder();
            foreach (char ch in commandText)
            {
                if (ch.Equals('"'))
                {
                     if (!TokenWithSpace)
                     {
                        TokenWithSpace = true;
                    }
                    else
                    {
                        TokenWithSpace = false;
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                }

                if (!TokenWithSpace)
                {
                    if (ch.Equals(' ') == false) 
                    {
                        if (!ch.Equals('"'))
                            currentToken.Append(ch); 
                    }
                    else
                    {
                        tokens.Add(currentToken.ToString());
                        currentToken.Clear();
                    }
                }

                if (TokenWithSpace)
                {
                    if (!ch.Equals('"'))
                        currentToken.Append(ch);
                }
            }
            tokens.RemoveAll(item => item.Equals(""));
            return tokens;
        }
        public ICommand Interpret(string commandText)
        {
            List<string> tokens = this.TextCommandTokenizer(commandText);
            if (tokens.Count < 1) return new cmdError();
            if (tokens[0].ToLower().Equals("addfile"))
            {
                return new cmdAddFile(tokens.GetRange(1,tokens.Count-1));
            }
            if (tokens[0].ToLower().Equals("addtags"))
            {
                return new cmdAddTags(tokens.GetRange(1, tokens.Count - 1));
            }
            if (tokens[0].ToLower().Equals("removefile"))
            {
                return new cmdRemoveFile(tokens.GetRange(1, tokens.Count - 1));
            }
            if (tokens[0].ToLower().Equals("find"))
            {
                return new cmdFindFilies(tokens.GetRange(1, tokens.Count - 1));
            }
            if (tokens[0].ToLower().Equals("help"))
            {
                return new cmdHelp();
            }
            if (tokens[0].ToLower().Equals("exit"))
            {
                return new cmdExit();
            }
            else
                return new cmdError();

            throw new NotImplementedException();
        }
    }

}
