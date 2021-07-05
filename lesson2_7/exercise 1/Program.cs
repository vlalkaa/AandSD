using System;

namespace exercise_1
{
    class Program
    {
        const int N = 5;
        const int M = 3;

        static int Search(int n, int m)
        {
            if (n < 1 || m < 1)
                throw new AggregateException("n и m долженs быть больше 0");

            if (m == 1 || n == 1)
                return 1;
            
            return Search(n - 1, m) + Search(n, m - 1);
        }

        static void TestSearch(TestCase testCase)
        {
            try
            {
                if (Search(testCase.N,testCase.M) == testCase.Expected)
                {
                    Console.WriteLine($"При значении N = {testCase.N} M = {testCase.M} результат {testCase.Expected}");
                    Console.WriteLine("VALID TEST\n");
                }
                else
                {
                    Console.WriteLine("INVALID TEST\n");
                }
            }
            catch (Exception e)
            {
                if(testCase.ExpectedException != null)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("VALID TEST EXCEPTION\n");
                }
                else
                {
                    Console.WriteLine("INVALID TEST EXCEPTION\n");
                }
            }
        }

        static void Main(string[] args)
        {
            var testCase1 = new TestCase()
            {
                N = 3,
                M = 4,
                Expected = 10,
                ExpectedException = null
            };
            
            var testCase2 = new TestCase()
            {
                N = 1,
                M = 1,
                Expected = 1,
                ExpectedException = null
            };
            
            var testCase3 = new TestCase()
            {
                N = 10,
                M = 3,
                Expected = 55,
                ExpectedException = null
            };
            
            var testCase4 = new TestCase()
            {
                N = 0,
                M = 4,
                ExpectedException = new ArgumentException()
            };
            
            var testCase5 = new TestCase()
            {
                N = 3,
                M = -3,
                ExpectedException = new ArgumentException()
            };
            
            var testCase6 = new TestCase()
            {
                N = -10,
                M = -3,
                ExpectedException = new ArgumentException()
            };
            
            TestSearch(testCase1);
            TestSearch(testCase2);
            TestSearch(testCase3);
            TestSearch(testCase4);
            TestSearch(testCase5);
            TestSearch(testCase6);
        }
    }
}