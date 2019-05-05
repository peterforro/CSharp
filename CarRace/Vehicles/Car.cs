using System;
using CarRace.RaceSimulator;
using CarRace.Utility;


namespace CarRace.Vehicles {


    class Car : Vehicle {

        private readonly double _normalSpeed;
        private static int _instanceCounter;


        public Car(Race race) : base(race) {
            _normalSpeed = Util.RandInt(80, 110);
            Name = "Car" + (++_instanceCounter);
        }


        protected override void PrepareForLap() {
            Speed = Race.IsThereABrokenTruck() ? 75.0 : _normalSpeed;
        }
    }
}
