using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceConverter {
    internal class Program {
        static void Main(string[] args) {
            if (args.Length >= 1 && args[0] == "-tom") {
                //フィードからメートルへの対応表を出力
                PrintToMeterList(int.Parse(args[1]), int.Parse(args[2]));
            } else {
                //メートルからフィートへの対応表を出力
                PrintMeterToFeetList(int.Parse(args[1]), int.Parse(args[2]));
            }
        }

        private static void PrintMeterToFeetList(int start, int stop) {
            for (int meter = 0; meter <= 10; meter++) {
                double feet = MeterToFeet(meter);
                Console.WriteLine("{0}m = {1:0.0000}ft", meter, feet);
            }
        }

        private static void PrintToMeterList(int start, int stop) {
            for (int feet = 0; feet <= 10; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine("{0}ft = {1:0.0000}m", feet, meter);
            }
        }

        //フィートからメートルを求める
        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }
        //メートルからフィートを求める
        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }
    }
}
