namespace EulersHorse.src.models {
    class Knight : Coordinates {
        public Knight ((int, int) coords) : base (coords) {}

        public void Translate((int xCoord, int yCoord) translation)
        {
            XCoord += translation.xCoord;
            YCoord += translation.yCoord;
        }
    }
}