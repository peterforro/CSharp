using CarRace.Utility;



namespace CarRace.RaceWeather {


    class Weather {
        
        public bool Raining {
            set;
            get;
        }

        public void SetRaining() {
            Raining = Util.RandInt(1, 100) <= 30;
        }
    }


}
