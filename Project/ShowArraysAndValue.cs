using System;

public static class Display
{
	public static void ArrayValues(int[] sortedArray)
	{
		Console.WriteLine($"Array values:");
		for(int i = 0; i < sortedArray.Length/2; i++)
			Console.WriteLine($"{sortedArray[i]}{sortedArray[i+(sortedArray.Length/2)].ToString().PadLeft(10)}");
		Console.WriteLine();
	}
	public static void Contains(int? value)
    {
		if (value == null)
			Console.WriteLine($"Array doesn't contain: {value}.");
		else Console.WriteLine($"Array contains: {value}.");
		Console.WriteLine();
	}
}
