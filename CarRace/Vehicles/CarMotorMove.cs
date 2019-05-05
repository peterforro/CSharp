using CarRace.RaceSimulator;

namespace CarRace.Vehicles {


    abstract class CarMotorMove : Vehicle {
        protected CarMotorMove(Race race) : base(race) { }

        public override void MoveForAnHour() {
            PrepareForLap();
            distanceTraveled += speed;
        }
    }
}
