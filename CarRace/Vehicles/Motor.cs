using CarRace.RaceSimulator;
using CarRace.Utility;



namespace CarRace.Vehicles {


    class Motor : CarMotorMove {


        private static int instanceCounter = 0;
        private const double normalSpeed = 100.0;


        public Motor(Race race) : base(race) {
            name = "Motorcycle " + (++instanceCounter);
        }


        protected override void PrepareForLap() {
            speed = race.isRaining() ? normalSpeed - Util.RandInt(5, 50) : normalSpeed;
        }
    }
}
