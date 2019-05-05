using System;
using System.Collections.Generic;
using System.Text;
using CarRace.Vehicles;
using CarRace.RaceWeather;


namespace CarRace.RaceSimulator {


    class Race {

        private readonly List<Vehicle> vehicles;
        private const int eachVehicleNumber = 10;
        private const int raceHours = 50;
        private readonly Weather weather;


        public Race() {
            weather = new Weather();
            vehicles = new List<Vehicle>();
            for (int i = 0; i < eachVehicleNumber; ++i) {
                vehicles.Add(new Car(this));
            }
            for (int i = 0; i < eachVehicleNumber; ++i) {
                vehicles.Add(new Motor(this));
            }
            for (int i = 0; i < eachVehicleNumber; ++i) {
                vehicles.Add(new Truck(this));
            }
        }


        public bool IsThereABrokenTruck() {
            foreach (var vehicle in vehicles) {
                if (vehicle is Truck && ((Truck) vehicle).BreakdownTurnsLeft > 0) return true;
            }
            return false;
        }


        public void SimulateRace() {
            for (int i = 0; i < raceHours; ++i) {
                weather.setRaining();
                foreach (var vehicle in vehicles) {
                    vehicle.MoveForAnHour();
                }
            }
        }


        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            foreach (var vehicle in vehicles ) {
                sb.Append(vehicle + "\n");
            }
            return sb.ToString();
        }


        public bool isRaining() {
            return weather.Raining;
        }
    }
}
