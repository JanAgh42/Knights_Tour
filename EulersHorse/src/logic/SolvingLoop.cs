using EulersHorse.src.models;
using EulersHorse.src.constants;
using System.Diagnostics;

namespace EulersHorse.src.logic {
    class SolvingLoop {
        public CheckerBoard Board { get; set; }
        public Knight Knight { get; set; }

        private int currentValue = 1;
        private int numOfAttempts = 0;

        public SolvingLoop (int size, (int, int) coords) {
            Board = new CheckerBoard(size);
            Knight = new Knight(coords);

            Board.MarkSquare(currentValue, Knight.GetCoords, (-1, -1), (0, 0));

            Counter.Get().Start();

            if (SolveNextStep()) {
                Counter.Get().Stop();
                Board.DisplayBoard();
                Board.DisplaySteps();
            }
            else {
                Console.WriteLine(Counter.Get().IsOverLimit ? "Elapsed time" : $"No solution: {Counter.Get().GetMilliseconds()}ms");
            }
            Console.WriteLine($"Execution took {numOfAttempts} steps");
        }

        // brain of the entire program - 
        public bool SolveNextStep()
        {
                numOfAttempts++;

                // if we managed to fill in the last position, the tour is completed
                if (currentValue == Board.NumOfSquares) {
                    return true;
                }

                // if the solution is taking too long to compute, end execution
                if (Counter.Get().IsOverLimit) {
                    return false;
                }

                // iterating through every possible valid move
                foreach (var tr in RankTranslations(Knight.GetCoords))
                {
                    var newTranslation = tr.Item2;
                    var previousPos = Knight.GetCoords;
                    
                    // moving the knight forward using the selected move
                    Knight.TranslateForward(newTranslation);
                    Board.MarkSquare(++currentValue, Knight.GetCoords, previousPos, newTranslation);

                    // recursive calling
                    if (SolveNextStep()) {
                        return true;
                    }                       // if the timer runs out, stop the execution
                    else if (Counter.Get().IsOverLimit) {
                        break;
                    }
                    else {      // executed when SolveNextStep() returns false (knight found a dead end)
                        BackToPreviousSquare(Knight.GetCoords);
                        Knight.TranslateBackward(newTranslation);
                    }
                }
            return false;
        }

        // ranks every possible translation based on their cost according to Warnnsdorfs rule
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
            // orders every found legal translation from cheapest to most expensive
            return rankedTranslations.OrderBy(tr => tr.Item1).ToList();
        }

        // deletes a given square from the sequence of visited squares
        public void BackToPreviousSquare ((int, int) knightCoords)
        {
            currentValue--;
            Board.UnmarkSquare(knightCoords);
        }    
    }
}