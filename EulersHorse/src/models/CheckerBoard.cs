using EulersHorse.src.logic;
using EulersHorse.src.constants;

namespace EulersHorse.src.models {
    class CheckerBoard {
        public Square[,] Squares { get; private set; }
        public int Size { get; private set; }

        public CheckerBoard (int size = 8)
        {
            Size = size;
            Squares = new Square[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++) 
                {
                    Squares[x, y] = new Square((x, y));
                }
            }
        }

        public void MarkSquare (int value, (int x, int y) squareCoords, (int x, int y) prevCoords)
        {
            Squares[squareCoords.x, squareCoords.y].Value = value;

            if(prevCoords != (0, 0))
            {
                Squares[squareCoords.x, squareCoords.y].Previous = Squares[prevCoords.x, prevCoords.y];
            }
        }

        public void UnmarkSquare ((int x, int y) squareCoords)
        {
            Squares[squareCoords.x, squareCoords.y].Value = 0;
            Squares[squareCoords.x, squareCoords.y].Previous = null!;
        }

        public int GetOnwardMovesFromSquare ((int xCoord, int yCoord) squareCoords)
        {
            int numOfMoves = 0;

            foreach ((int xCoord, int yCoord) translation in Translations.All())
            {
                int nextX = squareCoords.xCoord + translation.xCoord;
                int nextY = squareCoords.yCoord + translation.yCoord;

                if (Validation.ValidatePos(Size, (nextX, nextY)) &&
                    Squares[nextX, nextY].Value == 0)
                {
                    numOfMoves++;
                }
            }
            return numOfMoves;
        }

        public void DisplayBoard ()
        {
            for (int x = 0; x < Size; x++)
            {
                for (int y = 0; y < Size; y++)
                {
                    Console.Write(Squares[y, x].Value + " ");
                }
                Console.WriteLine();
            }
        }
    }
}