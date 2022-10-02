namespace EulersHorse.src.models {
    class Square : Coordinates {
        public Square Previous { get; set; } = null!;
        public int Value { get; set; } = 0;

        public Square ((int, int) coords) : base (coords) {}

        // lambda for determining if the square has already been visited (marked)
        public bool WasVisited => Value != 0;
    }
}