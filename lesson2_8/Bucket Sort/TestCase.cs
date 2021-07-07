using System;
using System.Collections.Generic;

namespace Bucket_Sort
{
    public class TestCase
    {
        public int[] Array { get; set; }
        public List<int> Expected { get; set; }
        public Exception ExpectedException { get; set; }
    }
}