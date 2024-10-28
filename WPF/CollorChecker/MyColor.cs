using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CollorChecker {
    internal struct MyColor {
        public Color Color { get; set; }
        public String Name { get; set; }
        public override string ToString() {
            return Name ?? string.Format("R："+Color.R+"　G："+Color.G+"　B："+Color.B);
        }
    }
}
