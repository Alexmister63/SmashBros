using System;
using System.IO;
using Modele;
using Data;
using static System.Console;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            ListPerso pTest = Stub.CreationDePersonnages();
            pTest.ToString();
        }
    }
}
