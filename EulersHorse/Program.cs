using EulersHorse.src.logic;

namespace EulersHorse
{
    class Program
    {
        static void Main(string[] args)
        {
            SolvingLoop loop;
            int size, x, y, limit;
            do {
                Console.Write("Checkerboard size: ");           // enter 0 to exit the program
                size = Convert.ToInt32(Console.ReadLine());
                
                if (size == 0) {
                    break;
                }
                else if(size <= 4) {
                    continue;
                }

                Console.Write("X: ");
                x = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y: ");
                y = Convert.ToInt32(Console.ReadLine());
                Console.Write("Timer limit (sec): ");
                limit = Convert.ToInt32(Console.ReadLine());

                Counter.Get().TimerLimit = limit;
                loop = new SolvingLoop(size, (x - 1, y - 1));
            } while(size > 0);
        }
    }
}