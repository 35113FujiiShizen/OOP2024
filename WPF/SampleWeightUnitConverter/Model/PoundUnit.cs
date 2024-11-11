﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWeightUnitConverter {
    public class PoundUnit:WeightUnit {
        private static List<PoundUnit> units = new List<PoundUnit> {
            new PoundUnit{Name = "oz",Coefficient =1},
            new PoundUnit{Name = "lb",Coefficient =16},
            new PoundUnit{Name = "stone",Coefficient=224},
        };
        public static ICollection<PoundUnit> Units { get { return units; } }

        // グラム単位からポンド単位への変換メソッド
        public double FromGramUnit(GramUnit unit, double value) {
            return (value * unit.Coefficient) / 28.35 / this.Coefficient;
        }
    }
}