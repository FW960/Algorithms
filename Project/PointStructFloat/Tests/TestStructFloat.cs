using BenchmarkDotNet.Attributes;
using System;

namespace Project
{
    public class TestStructFloat
    {
        PointStructFloat closestPoint = new PointStructFloat { x = 2.0F, y = 2.0F };

        PointStructFloat furthestPoint = new PointStructFloat { x = 2.0F, y = 2.0F };

        [Benchmark]
        public void TestFloatStruct()
        {
            CalculateFloatDistance(closestPoint, furthestPoint);
        }
        public float CalculateFloatDistance(PointStructFloat closestPoint, PointStructFloat furthestPoint)
        {
            float x = furthestPoint.x - closestPoint.x;

            float y = furthestPoint.y - closestPoint.y;

            return MathF.Sqrt((x * x) + (y * y));
        }
    }

}
