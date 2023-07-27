using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q1CheckBrackets : Processor
    {
        public Q1CheckBrackets(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, long>)Solve);

        public long Solve(string str)
        {
            Stack<Tuple<int, char>> brackets = new Stack<Tuple<int, char>>();
            for (int i = 0 ; i < str.Length ; i++ )
            {
                if ("[{(".Contains(str[i]))
                {
                    brackets.Push(Tuple.Create(i, str[(int)i]));
                }
                if ("}])".Contains(str[(int)i]))
                {
                    if (brackets.Count == 0)
                    {
                        return (long)i + 1;
                    }
                    var top = brackets.Pop();
                    if ((top.Item2 == '(' && str[(int)i] != ')') || (top.Item2 == '[' && str[(int)i] != ']') || (top.Item2 == '{' && str[(int)i] != '}'))
                    {
                        return (long)i + 1;
                    }
                }
            }
            if (brackets.Count != 0)
            {
                return brackets.Peek().Item1 + 1;
            }
            return -1;
        }
    }
}
