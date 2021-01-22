using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    public class PointClass
    {
        public float X;
        public float Y;
        public PointClass(float x, float y)
        {
            X = x;
            Y = y;
        }
    }

    public struct PointStructF
    {
        public float X;
        public float Y;
    }

    public struct PointStructD
    {
        public double X;
        public double Y;
    }


    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class BechmarkClass
    {
        static readonly int ArrSize = 0x1000;
        static readonly int NumOfSteps = 10;
        double[] PFArr;
        Random rand;
        int MainIndex = 0;
        public BechmarkClass()
        {
            rand = new Random();
            PFArr = new double[ArrSize];
            for (int i = 0; i < PFArr.Length; i++)
            {
                PFArr[i] = rand.NextDouble();
            }
        }

        public PointStructD GetPoint()
        {
            PointStructD p = new PointStructD
            {
                X = PFArr[MainIndex],
                Y = PFArr[PFArr.Length - MainIndex - 1]
            };
            MainIndex++;
            MainIndex &= (ArrSize - 1);
            return p;
        }
        public static float test1distanceClasse(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public static float test2distanceStruct(PointStructF pointOne, PointStructF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public static double test3distanceStructDouble(PointStructD pointOne, PointStructD pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float test4distanceShort(PointStructF pointOne, PointStructF pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }


        [Benchmark]
        public void Test1()
        {
            for (int i = 0; i < NumOfSteps; i++)
            {
                PointStructD p1 = GetPoint();
                PointStructD p2 = GetPoint();
                test1distanceClasse(new PointClass((float)p1.X, (float)p1.Y),
                                    new PointClass((float)p2.X, (float)p2.Y));
            }
        }

        [Benchmark]
        public void Test2()
        {
            for (int i = 0; i < NumOfSteps; i++)
            {
                PointStructD p1 = GetPoint();
                PointStructD p2 = GetPoint();
                test2distanceStruct(new PointStructF { X = (float)p1.X, Y = (float)p1.Y },
                                    new PointStructF { X = (float)p2.X, Y = (float)p2.Y });
            }
        }

        [Benchmark]
        public void Test3()
        {
            for (int i = 0; i < NumOfSteps; i++)
            {

                PointStructD p1 = GetPoint();
                PointStructD p2 = GetPoint();
                test3distanceStructDouble(new PointStructD { X = p1.X, Y = p1.Y },
                                          new PointStructD { X = p2.X, Y = p2.Y });
            }
        }

        [Benchmark]
        public void Test4()
        {
            for (int i = 0; i < NumOfSteps; i++)
            {

                PointStructD p1 = GetPoint();
                PointStructD p2 = GetPoint();
                test4distanceShort(new PointStructF { X = (float)p1.X, Y = (float)p1.Y },
                                   new PointStructF { X = (float)p2.X, Y = (float)p2.Y });
            }

        }


    }
}
