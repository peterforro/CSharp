using System.Collections.Generic;
using System.Text;
using CarRace.Vehicles;
using CarRace.RaceWeather;


namespace CarRace.RaceSimulator {


    class Race {

        private readonly List<Vehicle> _vehicles;
        private const int EachVehicleNumber = 10;
        private const int RaceHours = 50;
        private readonly Weather _weather;


        public Race() {
            _weather = new Weather();
            _vehicles = new List<Vehicle>();
            for (var i = 0; i < EachVehicleNumber; ++i) {
                _vehicles.Add(new Car(this));
            }
            for (var i = 0; i < EachVehicleNumber; ++i) {
                _vehicles.Add(new Motor(this));
            }
            for (var i = 0; i < EachVehicleNumber; ++i) {
                _vehicles.Add(new Truck(this));
            }
        }


        public bool IsThereABrokenTruck() {
            foreach (var vehicle in _vehicles) {
                if (vehicle is Truck truck && truck.BreakdownTurnsLeft > 0) return true;
            }
            return false;
        }


        public void SimulateRace() {
            for (var i = 0; i < RaceHours; ++i) {
                _weather.SetRaining();
                foreach (var vehicle in _vehicles) {
                    vehicle.MoveForAnHour();
                }
            }
        }


        public override string ToString() {
            var truck = new Truck(this);
            var sb = new StringBuilder();
            sb.Append("----------------------CARS----------------------\n");
            foreach (var vehicle in _vehicles ) {
                if(vehicle is Car) sb.Append(vehicle + "\n");
            }
            sb.Append("---------------------MOTORS---------------------\n");
            foreach (var vehicle in _vehicles) {
                if (vehicle is Motor) sb.Append(vehicle + "\n");
            }
            sb.Append("---------------------TRUCKS---------------------\n");
            foreach (var vehicle in _vehicles) {
                if (vehicle is Truck) sb.Append(vehicle + "\n");
            }
            return sb.ToString();
        }


        public bool IsRaining() {
            return _weather.Raining;
        }
    }
}
