namespace EulersHorse.src.constants {
    static class Translations {
        public static readonly (int xCoord, int yCoord) UpLeft = (-1, 2);
        public static readonly (int xCoord, int yCoord) UpRight = (1, 2);
        public static readonly (int xCoord, int yCoord) RightUp = (2, 1);
        public static readonly (int xCoord, int yCoord) RightDown = (2, -1);
        public static readonly (int xCoord, int yCoord) DownRight = (1, -2);
        public static readonly (int xCoord, int yCoord) DownLeft = (-1, -2);
        public static readonly (int xCoord, int yCoord) LeftDown = (-2, -1);
        public static readonly (int xCoord, int yCoord) LeftUp = (-2, 1);

        public static List<(int, int)> All ()
        {
            return new List<(int xCoord, int yCoord)>
            {
                UpLeft,
                UpRight,
                RightUp,
                RightDown,
                DownRight,
                DownLeft,
                LeftDown,
                LeftUp
            };
        } 
    }
}