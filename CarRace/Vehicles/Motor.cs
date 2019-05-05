using CarRace.RaceSimulator;
using CarRace.Utility;



namespace CarRace.Vehicles {


    class Motor : Vehicle {


        private static int _instanceCounter;
        private const double normalSpeed = 100.0;


        public Motor(Race race) : base(race) {
            Name = "Motor" + (++_instanceCounter);
        }


        protected override void PrepareForLap() {
            Speed = Race.IsRaining() ? normalSpeed - Util.RandInt(5, 50) : normalSpeed;
        }
    }
}
