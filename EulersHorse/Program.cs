using EulersHorse.src.logic;

namespace EulersHorse
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            SolvingLoop loop = new SolvingLoop(size, (x, y));
        }
    }
}