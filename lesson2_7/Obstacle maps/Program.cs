using System;

namespace Obstacle_maps
{
    class Program
    {
        static void Print2(int n, int m, int[,] a)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(a[i, j]);
                Console.Write("\r\n");
            }
        }
        static int [,]Maps(int n,int m,int[,]deny)
        {
            if (n < 1 || m < 1)
                throw new AggregateException("n и m долженs быть больше 0");
            if (n != deny.GetLength(0) || m != deny.GetLength(1))
                throw new AggregateException("размеры матрицы nхm не совпадают с матрицей deny");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (deny[i,j] != 0 || deny[i,j] != 1)
                        throw new AggregateException("неверно заданы значения в deny");
                }
            }
            
            int[,] a = new int[n, m];
            for (int j = 0; j < m; j++)
            {
                if (deny[0, j] == 1 && j == 0)
                    a[0, j] = 1; 
                else if (deny[0, j] == 1 && a[0, j - 1] == 1)
                    a[0, j] = 1;
                else if (deny[0, 0] == 0)
                    return a;
            }
            
            for (int i = 1; i < n; i++)
            {
                if(deny[i, 0] == 1 && a[i- 1, 0] == 1)
                {
                    a[i, 0] = 1;
                }
                for (int j = 1; j < m; j++)
                    if (deny[i, j] == 1)
                        a[i, j] = a[i, j - 1] + a[i - 1, j];
                    else
                        a[i, j] = 0;
            }

            return a;
        }

        static void TestMaps(TestCase testCase)
        {
            try
            {
                if (Maps(testCase.N,testCase.M,testCase.Deny)[testCase.N - 1,testCase.M - 1] == testCase.Expected)
                {
                    Console.WriteLine($"При значении N = {testCase.N} M = {testCase.M} результат {testCase.Expected}");
                    Print2(testCase.N,testCase.M,Maps(testCase.N,testCase.M,testCase.Deny));
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
                M = 3,
                Deny = new [,]
                {
                    {1,0,1},
                    {1,1,1},
                    {0,1,1}
                },
                Expected = 2,
                ExpectedException = null
            };
            
            var testCase2 = new TestCase()
            {
                N = 4,
                M = 3,
                Deny = new [,]
                {
                    {0,0,1},
                    {1,1,1},
                    {1,0,1},
                    {0,1,1}
                },
                Expected = 0,
                ExpectedException = null
            };
            
            var testCase3 = new TestCase()
            {
                N = 4,
                M = 5,
                Deny = new [,]
                {
                    {1,0,1,1,1},
                    {1,1,1,1,1},
                    {1,0,1,0,1},
                    {0,1,1,1,1},
                },
                Expected = 2,
                ExpectedException = null
            };
            
            var testCase4 = new TestCase()
            {
                N = 2,
                M = 5,
                Deny = new [,]
                {
                    {1,0,1},
                    {1,1,1},
                    {0,1,1}
                },
                ExpectedException = new ArgumentException()
            };
            
            var testCase5 = new TestCase()
            {
                N = 3,
                M = -3,
                Deny = new [,]
                {
                    {1,0,1},
                    {1,1,1},
                    {0,1,1}
                },
                ExpectedException = new ArgumentException()
            };
            
            var testCase6 = new TestCase()
            {
                N = 3,
                M = 3,
                Deny = new [,]
                {
                    {1,0,1},
                    {1,-1,1},
                    {0,1,1}
                },
                ExpectedException = new ArgumentException()
            };
            
            TestMaps(testCase1);
            TestMaps(testCase2);
            TestMaps(testCase3);
            TestMaps(testCase4);
            TestMaps(testCase4);
            TestMaps(testCase5);
            TestMaps(testCase6);
        }
    }

}