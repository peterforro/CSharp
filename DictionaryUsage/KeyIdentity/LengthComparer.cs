using System;
using System.Collections.Generic;
using DictionaryUsage.Model;

namespace DictionaryUsage.KeyIdentity {
    class LengthComparer : IEqualityComparer<Point> {
        public bool Equals(Point x, Point y) {
            return (Math.Abs(x.x) + Math.Abs(x.y) == Math.Abs(y.x) + Math.Abs(y.y));
        }

        public int GetHashCode(Point obj) {
            return (int) (Math.Abs(obj.x) + Math.Abs(obj.y));
        }
    }
}
