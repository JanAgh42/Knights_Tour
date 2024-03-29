namespace EulersHorse.src.logic {
    static class Validation {

        // checks if a given position is valid
        public static bool ValidatePos (int size, (int x, int y) trans)
        {
            return trans.x >= 0 && trans.x < size && trans.y >= 0 && trans.y < size;
        }

        // determines the knights new position and checks if its valid
        public static bool ValidateMove (int size,
            (int xCoord, int yCoord) position,
            (int xCoord, int yCoord) translation)
        {
            int newPosX = position.xCoord + translation.xCoord;
            int newPosY = position.xCoord + translation.yCoord;

            return ValidatePos(size, (newPosX, newPosY));
        }
    }
}