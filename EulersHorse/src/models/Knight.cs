namespace EulersHorse.src.models {
    class Knight : Coordinates {
        public Knight ((int, int) coords) : base (coords) {}

        public void TranslateForward ((int xCoord, int yCoord) translation)
        {
            XCoord += translation.xCoord;
            YCoord += translation.yCoord;
        }

        public void TranslateBackward ((int xCoord, int yCoord) translation)
        {
            XCoord -= translation.xCoord;
            YCoord -= translation.yCoord;
        }
    }
}