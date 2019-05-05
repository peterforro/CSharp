using System;
using CarRace.RaceSimulator;
using CarRace.Utility;


namespace CarRace.Vehicles {


    class Car : CarMotorMove {

        private readonly double normalSpeed;
        private static int instanceCounter = 0;


        public Car(Race race) : base(race) {
            normalSpeed = Util.RandInt(80, 110);
            name = "Car" + (++instanceCounter);
        }


        protected override void PrepareForLap() {
            speed = race.IsThereABrokenTruck() ? 75.0 : normalSpeed;
        }
    }
}
