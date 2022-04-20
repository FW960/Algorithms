using BenchmarkDotNet.Attributes;

namespace Project
{
    public class TestStructFloatWithoutSqrt
    {
        PointStructFloat closestPoint = new PointStructFloat { x = 2.0F, y = 2.0F };

        PointStructFloat furthestPoint = new PointStructFloat { x = 2.0F, y = 2.0F };

        [Benchmark]
        public void TestFloatWithoutSqrtStruct()
        {
            CalculateFloatDistanceWithoutSqrt(closestPoint, furthestPoint);;
        }
        public float CalculateFloatDistanceWithoutSqrt(PointStructFloat closestPoint, PointStructFloat furthestPoint)
        {
            float x = furthestPoint.x - closestPoint.x;

            float y = furthestPoint.y - closestPoint.y;

            return ((x * x) + (y * y));
        }
    }

}
