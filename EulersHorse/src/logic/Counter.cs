using System.Diagnostics;

namespace EulersHorse.src.logic {
    class Counter {
        private static Counter instance = null!;
        private readonly Stopwatch _counter;

        private Counter () {
            _counter = new Stopwatch();
        }

        public static Counter Get ()
        {
            if(instance == null) {
                instance = new Counter();
            }
            return instance;
        }

        public void Start ()
        {
            if (_counter.ElapsedMilliseconds > 0) {
                _counter.Restart();
            }
            else {
                _counter.Start();
            }
        }

        public void Stop ()
        {
            _counter.Stop();
        }

        public double GetMilliseconds ()
        {
            return _counter.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L)) / 1000.0;
        }

        public bool IsOverLimit => GetMilliseconds() > 20000;
    }
}