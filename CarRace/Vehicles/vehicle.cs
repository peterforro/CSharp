using CarRace.RaceSimulator;


namespace CarRace.Vehicles {

    abstract class Vehicle {

        protected Race race;
        protected string name;
        protected double speed;
        protected double distanceTraveled;


        protected Vehicle(Race race) {
            this.race = race;
        }


        protected abstract void PrepareForLap();


        public abstract void MoveForAnHour();


        public override string ToString() {
            return $"{name}\t{distanceTraveled}km";
        }
    }
}
