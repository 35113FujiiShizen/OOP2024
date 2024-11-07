using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class GramUnit: WeightUnit {
        private static List<GramUnit> units = new List<GramUnit> {
            new GramUnit{Name = "g",Coefficient =1},
            new GramUnit{Name = "kg",Coefficient =10*100},// 1キログラム = 1000グラム
        };
        public static ICollection<GramUnit> Units { get { return units; } }

        // ポンド単位からグラム単位への変換メソッド
        public double FromPoundUnit(PoundUnit unit, double value) {
            return (value * unit.Coefficient) * 28.35 / this.Coefficient;
        }
    }
}
