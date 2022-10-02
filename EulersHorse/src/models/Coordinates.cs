namespace EulersHorse.src.models {
    class Coordinates {
        public int XCoord { get; protected set; }
        public int YCoord { get; protected set; }

        public Coordinates ((int xCoord, int yCoord) coords)
        {
            XCoord = coords.xCoord;
            YCoord = coords.yCoord;
        }

        // returns the coordinates of a given entity encapsulated in a tupple
        public (int, int) GetCoords => (XCoord, YCoord);
    }
}