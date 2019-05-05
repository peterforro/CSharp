using System;


namespace CarRace.Utility {

    static class Util {

        private static Random rnd = new Random();

        public static int RandInt(int min, int max) {
            return rnd.Next(min, max + 1);
        }


    }
}
