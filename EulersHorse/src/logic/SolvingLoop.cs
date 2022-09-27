using EulersHorse.src.models;
using EulersHorse.src.constants;

namespace EulersHorse.src.logic {
    class SolvingLoop {
        public CheckerBoard Board { get; set; }
        public Knight Knight { get; set; }

        private bool isLooping = true;
        private int currentValue = 1;

        public SolvingLoop (int size, (int, int) coords)
        {
            Board = new CheckerBoard(size);
            Knight = new Knight(coords);

            Board.MarkSquare(currentValue, Knight.GetCoords, (0, 0));

            Loop();
        }

        public void Loop ()
        {
            do
            {
                if (currentValue == Board.Size * Board.Size)
                {
                    break;
                }

                var nextTranslation = FindNextTranslation(Knight.GetCoords);

                if (nextTranslation == (0, 0))
                {
                    //BackToPreviousSquare(Knight.GetCoords);
                    break;
                }
                else
                {
                    var previousPos = Knight.GetCoords;

                    Knight.Translate(nextTranslation);
                    Board.MarkSquare(++currentValue, Knight.GetCoords, previousPos);
                }
            } while(isLooping);

            Board.DisplayBoard();
        }

        public void ResetLoop ()
        {
            Board = null!;
            Knight = null!;
        }

        public (int, int) FindNextTranslation ((int xCoord, int yCoord) knightCoords)
        {
            int minNumOfMoves = Board.Size + 1;
            (int, int) nextTranslation = (0, 0);

            foreach ((int xCoord, int yCoord) translation in Translations.All())
            {
                int nextX = knightCoords.xCoord + translation.xCoord;
                int nextY = knightCoords.yCoord + translation.yCoord;

                if (Validation.ValidatePos(Board.Size, (nextX, nextY)) &&
                    Board.Squares[nextX, nextY].Value == 0)
                {
                    var onwardMoves = Board.GetOnwardMovesFromSquare((nextX, nextY));

                    if (onwardMoves < minNumOfMoves && onwardMoves > 0)
                    {
                        minNumOfMoves = onwardMoves;
                        nextTranslation = translation;
                    }
                }
            }
            return nextTranslation;
        }

        public void BackToPreviousSquare ((int, int) knightCoords)
        {
            currentValue--;
            Board.UnmarkSquare(knightCoords);
        }
    }
}