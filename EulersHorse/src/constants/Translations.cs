namespace EulersHorse.src.constants {
    static class Translations {
        // constants containing permitted moves for the knight
        public static readonly (int xCoord, int yCoord) _UpLeft = (-1, 2);
        public static readonly (int xCoord, int yCoord) _UpRight = (1, 2);
        public static readonly (int xCoord, int yCoord) _RightUp = (2, 1);
        public static readonly (int xCoord, int yCoord) _RightDown = (2, -1);
        public static readonly (int xCoord, int yCoord) _DownRight = (1, -2);
        public static readonly (int xCoord, int yCoord) _DownLeft = (-1, -2);
        public static readonly (int xCoord, int yCoord) _LeftDown = (-2, -1);
        public static readonly (int xCoord, int yCoord) _LeftUp = (-2, 1);

        // returns an enumerable list of all constants
        public static List<(int, int)> All ()
        {
            return new List<(int xCoord, int yCoord)> {
                _UpLeft,
                _UpRight,
                _RightUp,
                _RightDown,
                _DownRight,
                _DownLeft,
                _LeftDown,
                _LeftUp
            };
        } 
    }
}