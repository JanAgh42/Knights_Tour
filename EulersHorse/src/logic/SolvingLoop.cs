using EulersHorse.src.models;
using EulersHorse.src.constants;
using System.Diagnostics;

namespace EulersHorse.src.logic {
    class SolvingLoop {
        public CheckerBoard Board { get; set; }
        public Knight Knight { get; set; }

        private int currentValue = 1;

        public SolvingLoop (int size, (int, int) coords) {
            Board = new CheckerBoard(size);
            Knight = new Knight(coords);

            Board.MarkSquare(currentValue, Knight.GetCoords, (0, 0));

            Counter.Get().Start();

            if (SecondLoop()) {
                Counter.Get().Stop();
                Board.DisplayBoard();
            }
            else {
                Console.WriteLine(Counter.Get().IsOverLimit ? "Elapsed time" : $"No solution: {Counter.Get().GetMilliseconds()}ms");
            }
        }

        public bool SecondLoop()
        {
                if (currentValue == Board.Size * Board.Size) {
                    return true;
                }

                if (Counter.Get().IsOverLimit) {
                    return false;
                }

                var orderedTranslations = RankTranslations(Knight.GetCoords);

                foreach (var tr in orderedTranslations)
                {
                    var newTranslation = tr.Item2;
                    var previousPos = Knight.GetCoords;
                    
                    Knight.TranslateForward(newTranslation);
                    Board.MarkSquare(++currentValue, Knight.GetCoords, previousPos);

                    if (SecondLoop()) {
                        return true;
                    }
                    else {
                        BackToPreviousSquare(Knight.GetCoords);
                        Knight.TranslateBackward(newTranslation);
                    }
                }
            return false;
        }

        public List<(int, (int, int))> RankTranslations ((int xCoord, int yCoord) knightCoords)
        {
            var rankedTranslations = new List<(int, (int, int))>();

            foreach ((int xCoord, int yCoord) translation in Translations.All())
            {
                int nextX = knightCoords.xCoord + translation.xCoord;
                int nextY = knightCoords.yCoord + translation.yCoord;

                if (Validation.ValidatePos(Board.Size, (nextX, nextY)) &&
                    !Board.Squares[nextX, nextY].WasVisited) {
                    var onwardMoves = Board.GetOnwardMovesFromSquare((nextX, nextY));

                    rankedTranslations.Add((onwardMoves, translation));
                }
            }
            return rankedTranslations.OrderBy(tr => tr.Item1).ToList();
        }

        public void BackToPreviousSquare ((int, int) knightCoords)
        {
            currentValue--;
            Board.UnmarkSquare(knightCoords);
        }
    }
}