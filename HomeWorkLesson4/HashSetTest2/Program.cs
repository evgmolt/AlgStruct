using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace HashSetTest2
{
    public class BechmarkClass
    {
        public static int SizeOfData = 10000;
        public static int SingleStringSize = 20;
        public string[] StringArray;
        public HashSet<string> hashSet;
        public BechmarkClass()
        {
            StringArray = new string[SizeOfData];
            hashSet = new HashSet<string>();

            Random rand = new Random();
            for (int i = 0; i < StringArray.Length; i++)
            {
                byte[] bArr = new byte[SingleStringSize];
                rand.NextBytes(bArr);
                string s = Encoding.UTF8.GetString(bArr);
                StringArray[i] = s;
                hashSet.Add(s);
            }
        }

        [Benchmark]
        public void SearchString()
        {
            string s = "bbvb";
            for (int i = 0; i < StringArray.Length; i++)
            {
                if (s == StringArray[i])
                    s = "";
            }
        }

        [Benchmark]
        public void SearchHash()
        {
            string s = "mbvbvf,faf";
            hashSet.Contains(s);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }

    }
}
