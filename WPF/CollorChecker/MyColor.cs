using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CollorChecker {
    internal class MyColor {
        public Color Color { get; set; }
        public String Name { get; set; } = String.Empty;
        public override string ToString() {
            return "R:"+Color.R+"G:"+Color.G+"B:"+Color.B;
        }
    }
}
