using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFileProcessor;
using static System.Net.Mime.MediaTypeNames;

namespace TextNumberSizeChange {
    class ToHankakuProcessor:TextProcessor {
        Dictionary<char,char> conv = new Dictionary<char, char>() {
        {'１','1'},{'２','2'},{'３','3'},{'４','4'},{'５','5'},
        {'６','6'},{'７','7'},{'８','8'},{'９','9'},{'０','0'}
        };
        private int _count;
        string _text ="";
        

        protected override void Initialize(string fname) {
            _count = 0;
        }

        protected override void Execute(string line) {
            string numberLower = new string
                (line.Select(n => (conv.ContainsKey(n) ? conv[n] : n)).ToArray());
            Console.WriteLine(numberLower);
            _count++;
        }

        protected override void Terminate() {
            Console.WriteLine("{0}行",_count);
            Console.WriteLine(_text);

        }
    }
}
