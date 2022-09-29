using EulersHorse.src.logic;

namespace EulersHorse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Rozmer sachovnice: ");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.Write("X: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Y: ");
            int y = Convert.ToInt32(Console.ReadLine());

            SolvingLoop loop = new SolvingLoop(size, (x - 1, y - 1));
        }
    }
}