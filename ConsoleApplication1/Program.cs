﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 )
            {
                Console.WriteLine("사용법 : Hello.exe");
                return;
            }

            WriteLine("Hello, {0}", args[0]);
        }
    }
}
