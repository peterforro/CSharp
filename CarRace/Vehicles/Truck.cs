using CarRace.RaceSimulator;
using CarRace.Utility;



namespace CarRace.Vehicles {


    class Truck : Vehicle {

        private static int _instanceCounter;

        public int BreakdownTurnsLeft {
            set;
            get;
        }

        
        public Truck(Race race) : base(race) {
            Speed = 100.0;
            Name = "Truck" + (++_instanceCounter);
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
                DistanceTraveled += Speed;
            }
        }
    }
}
