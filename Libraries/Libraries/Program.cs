namespace Libraries
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var com = new Combination(1000000000);
            com.Solve(1000000000, 100000);
        }
    }
}