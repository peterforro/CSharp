using CarRace.RaceSimulator;


namespace CarRace.Vehicles {

    abstract class Vehicle {

        protected Race Race;
        protected string Name;
        protected double Speed;
        protected double DistanceTraveled;


        protected Vehicle(Race race) {
            this.Race = race;
        }


        protected abstract void PrepareForLap();


        public virtual void MoveForAnHour() {
            PrepareForLap();
            DistanceTraveled += Speed;
        }


        public override string ToString() {
            return $"{Name}\t{DistanceTraveled}km";
        }
    }
}
