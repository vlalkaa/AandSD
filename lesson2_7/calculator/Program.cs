using System;

namespace calculator
{
    class Program
    {
        static int Calc(int n)
        {
            if (n < 1)
                throw new AggregateException("n должен быть больше 0");
            
            if(n % 2 == 0 && n > 1)
                return Calc(n - 1) + Calc(n / 2);

            if (n % 2 == 1 && n > 1)
                return Calc(n - 1);

            return 1;
        }

        static void TestCalc(TestCase testCase)
        {
            try
            {
                if (Calc(testCase.Number) == testCase.Expected)
                {
                    Console.WriteLine($"При значении {testCase.Number} результат {testCase.Expected}");
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
                Number = 16,
                Expected = 36,
                ExpectedException = null
            };
            
            var testCase2 = new TestCase()
            {
                Number = 4,
                Expected = 4,
                ExpectedException = null
            };
            
            var testCase3 = new TestCase()
            {
                Number = 9,
                Expected = 10,
                ExpectedException = null
            };
            
            var testCase4 = new TestCase()
            {
                Number = -6,
                ExpectedException = new ArgumentException()
            };
            
            var testCase5 = new TestCase()
            {
                Number = -1,
                ExpectedException = new ArgumentException()
            };
            
            var testCase6 = new TestCase()
            {
                Number = 0,
                ExpectedException = new ArgumentException()
            };
            
            TestCalc(testCase1);
            TestCalc(testCase2);
            TestCalc(testCase3);
            TestCalc(testCase4);
            TestCalc(testCase5);
            TestCalc(testCase6);
        }
    }
}