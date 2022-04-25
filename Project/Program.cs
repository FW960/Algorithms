namespace Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowStrangeNum.Result(Calculate.StrangeSum(ArrayGenerator.GenerateIntArray()));
        }
    }
}
