﻿using System;
using System.Linq;
using System.Collections.Generic;
using TestCommon;

namespace A10
{
    public class Contact
    {
        public string Name;
        public int Number;

        public Contact(string name, int number)
        {
            Name = name;
            Number = number;
        }
    }

    public class Q1PhoneBook : Processor
    {
        public Q1PhoneBook(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string[], string[]>)Solve);

        public string[] Solve(string[] commands)
        {
            Contact[] PhoneBookList = new Contact[10000000];
            List<string> result = new List<string>();
            foreach (var cmd in commands)
            {
                var toks = cmd.Split();
                var cmdType = toks[0];
                var args = toks.Skip(1).ToArray();
                int number = int.Parse(args[0]);
                switch (cmdType)
                {
                    case "add":
                        Add(args[1], number, PhoneBookList);
                        break;
                    case "del":
                        Delete(number, PhoneBookList);
                        break;
                    case "find":
                        result.Add(Find(number, PhoneBookList));
                        break;
                }
            }
            return result.ToArray();
        }

        public void Add(string name, int number, Contact[] PhoneBookList)
        {
            PhoneBookList[number] = new Contact(name, number);
        }

        public string Find(int number, Contact[] PhoneBookList)
        {
            string s = "not found";
            if (PhoneBookList[number] != null)
            {
                s = PhoneBookList[number].Name;
            }
            return s;
        }

        public void Delete(int number, Contact[] PhoneBookList)
        {
            PhoneBookList[number] = null;
        }
    }
}
