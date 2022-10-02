using EulersHorse.src.logic;

namespace EulersHorse
{
    class Program
    {
        static void Main(string[] args)
        {
            SolvingLoop loop;
            int size, x, y;
            do {
                Console.Write("Rozmer sachovnice: ");
                size = Convert.ToInt32(Console.ReadLine());

                if (size <= 4) {
                    break;
                }

                Console.Write("X: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y: ");
                y = Convert.ToInt32(Console.ReadLine());

                loop = new SolvingLoop(size, (x - 1, y - 1));
            } while(size > 0);
        }
    }
}