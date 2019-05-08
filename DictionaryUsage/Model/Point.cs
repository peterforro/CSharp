using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DictionaryUsage.Model {

    struct Point {
        public double x;
        public double y;

        public Point(double x, double y) {
            this.x = x;
            this.y = y;
        }

        public override string ToString() {
            return $"x={x} y={y}";
        }
    }
}
