using System;

public static class ArrayGenerator
{
	public static int[] GenerateIntArray()
	{
		Random random = new Random(); int[] array = new int[random.Next(0, 100)];

		for (int i = 0; i < array.Length; i++)
			array[i] = random.Next(0, 100);
		return array;


	}
}
