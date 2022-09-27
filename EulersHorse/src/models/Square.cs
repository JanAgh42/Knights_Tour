namespace EulersHorse.src.models {
    class Square : Coordinates {
        public Square Previous { get; set; } = null!;
        public int Value { get; set; } = 0;

        public Square ((int, int) coords) : base (coords) {}

        public bool WasVisited => Value != 0;
    }
}