namespace EulersHorse.src.models {
    class Knight : Coordinates {
        public Knight ((int, int) coords) : base (coords) {}

        // moves the knight ahead using the selected translation
        public void TranslateForward ((int xCoord, int yCoord) translation)
        {
            XCoord += translation.xCoord;
            YCoord += translation.yCoord;
        }

        // returns the knight to his previous position on the board
        public void TranslateBackward ((int xCoord, int yCoord) translation)
        {
            XCoord -= translation.xCoord;
            YCoord -= translation.yCoord;
        }
    }
}