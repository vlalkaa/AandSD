using System;
namespace Obstacle_maps
{
    public class TestCase
    {
        public int N { get; set; }
        public int M { get; set; }
        public int [,]Deny { get; set; }
        public int Expected { get; set; }
        public Exception ExpectedException { get; set; }
    }
}