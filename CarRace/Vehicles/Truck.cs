using CarRace.RaceSimulator;
using CarRace.Utility;



namespace CarRace.Vehicles {


    class Truck : Vehicle {

        private static int instanceCounter = 0;

        public int BreakdownTurnsLeft {
            set;
            get;
        }

        
        public Truck(Race race) : base(race) {
            speed = 100.0;
            name = "Truck " + (++instanceCounter);
        }


        protected override void PrepareForLap() {
            if (BreakdownTurnsLeft > 0) {
                --BreakdownTurnsLeft;
            }
            else {
                if (Util.RandInt(1, 100) <= 5) {
                    BreakdownTurnsLeft = 2;
                }
            }
        }


        public override void MoveForAnHour() {
            PrepareForLap();
            if (BreakdownTurnsLeft == 0) {
                distanceTraveled += speed;
            }
        }
    }
}
