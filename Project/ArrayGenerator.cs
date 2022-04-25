using System;

public static class ArrayGenerator
{
	public static long[] GenerateIntArray()
	{
		Random random = new Random(); long[] array = new long[random.Next(0, 92)];
		return array;
	}
}
