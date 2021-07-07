using System;
using System.Collections.Generic;
using System.Linq;

namespace Bucket_Sort
{
    class Program
    {
        static List<int> BucketSort(int [] arr)
        {
            List<int> sortArr = new List<int>();
            var num = 10;
            
            List<int>[] buckets = new List<int>[num];
            for (int i = 0; i < num; i++)
            {
                buckets[i] = new List<int>();
            }

            foreach (var t in arr)
            {
                int bucket = t / num;
                buckets[bucket].Add(t);
            }

            for (int i = 0; i < num; i++)
            {
                buckets[i].Sort();
                sortArr.AddRange(buckets[i]);
            }
            
            return sortArr;
        }

        static void TestBucketSort(TestCase testCase)
        {
            try
            {
                if (BucketSort(testCase.Array).SequenceEqual(testCase.Expected))
                {
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
                Array = new [] { 43, 17, 0, 24, 31, 6, 96, 13, 66, 62, 4 },
                Expected = new List<int>{0, 4, 6, 13, 17, 24, 31, 43, 62, 66, 96},
                ExpectedException = null
            };
            
            var testCase2 = new TestCase()
            {
                Array = new [] { 4, 1, 7, 2, 3, 6, 9, 13, 8, 4 },
                Expected = new List<int>{1,2,3,4,4,6,7,8,9,13},
                ExpectedException = null
            };
            
            var testCase3 = new TestCase()
            {
                Array = new [] { 0, 6, 8, 0, 8, 6, 0},
                Expected = new List<int>{0,0,0,6,6,8,8},
                ExpectedException = null
            };
            
            var testCase4 = new TestCase()
            {
                Array = new [] { 43, 17, 0, 24, 31, 6, -96, 13, 66, 62, 4 },
                ExpectedException = new IndexOutOfRangeException()
            };
            
            var testCase5 = new TestCase()
            {
                Array = new [] { 6, 296, 13},
                ExpectedException = new IndexOutOfRangeException()
            };
            
            var testCase6 = new TestCase()
            {
                Array = new [] { 10000},
                ExpectedException = new IndexOutOfRangeException()
            };
            
            TestBucketSort(testCase1);
            TestBucketSort(testCase2);
            TestBucketSort(testCase3);
            TestBucketSort(testCase4);
            TestBucketSort(testCase5);
            TestBucketSort(testCase6);
        }
    }
}