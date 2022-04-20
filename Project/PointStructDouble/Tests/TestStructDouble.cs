using BenchmarkDotNet.Attributes;
using System;

namespace Project
{
    public class TestStructDouble
    {
        PointStructDouble closestPoint = new PointStructDouble{ x = 2.0D, y = 2.0D };

        PointStructDouble furthestPoint = new PointStructDouble { x = 2.0D, y = 2.0D };

        [Benchmark]
        public void TestDoubleStruct()
        {
            CalculateDoubleDistance(closestPoint, furthestPoint);
        }
        public double CalculateDoubleDistance(PointStructDouble closestPoint, PointStructDouble furthestPoint)
        {
            double x = furthestPoint.x - closestPoint.x;

            double y = furthestPoint.y - closestPoint.y;

            return Math.Sqrt((x * x) + (y * y));
        }
    }

}
