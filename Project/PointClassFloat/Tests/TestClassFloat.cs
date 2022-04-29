using BenchmarkDotNet.Attributes;
using System;

namespace Project
{
    public class TestClassFloat
    {
        PointClassFloat closestPoint = new PointClassFloat { x = 2.0F, y = 2.0F };

        PointClassFloat furthestPoint = new PointClassFloat { x = 2.0F, y = 2.0F };

        [Benchmark]
        public void TestFloatClass()
        {
            CalculateDistance(closestPoint, furthestPoint);
        }
        public float CalculateDistance(PointClassFloat closestPoint, PointClassFloat furthestPoint)
        {
            float x = furthestPoint.x - closestPoint.x;

            float y = furthestPoint.y - closestPoint.y;

            return (float)Math.Sqrt((x * x) + (y * y));
        }
    }

}
