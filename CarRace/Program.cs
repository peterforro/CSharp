using System;
using CarRace.RaceSimulator;



namespace CarRace {


    class Program {


        static void Main(string[] args) {
            Race race = new Race();
            race.SimulateRace();
            Console.WriteLine(race);
            Console.ReadKey();
        }
    }
}
