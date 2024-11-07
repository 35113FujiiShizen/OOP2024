using SampleWeightUnitConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SampleWeightUnitConverter {
    public class MainWindowViewModel : ViewModel {
        private double gramValue, poundValue;

        //▲で呼ばれるコマンド
        public ICommand PoundToGramUnit { get; private set; }
        //▼で呼ばれるコマンド
        public ICommand GramToPoundUnit { get; private set; }

        //上のComboBoxで選択されている値
        public GramUnit CurrentGramUnit { get; set; }
        //下のComboBoxで選択されている値
        public PoundUnit CurrentPoundUnit { get; set; }

        public double GramValue {
            get { return gramValue; }
            set {
                gramValue = value;
                OnPropertyChanged();
            }
        }
        public double PoundValue {
            get { return poundValue; }
            set {
                poundValue = value;
                OnPropertyChanged();
            }
        }
        //コンストラクタ
        public MainWindowViewModel() {
            CurrentGramUnit = GramUnit.Units.First();
            CurrentPoundUnit = PoundUnit.Units.First();

            GramToPoundUnit = new DelegateCommand(() =>
                PoundValue = CurrentPoundUnit.FromGramUnit(CurrentGramUnit, GramValue));

            PoundToGramUnit = new DelegateCommand(() =>
                GramValue = CurrentGramUnit.FromPoundUnit(CurrentPoundUnit, PoundValue));
        }
    }
}
