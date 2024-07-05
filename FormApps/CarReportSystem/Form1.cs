using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //カーレポート管理用リスト
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }
        //追加ボタン
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }
            CarReport carReport = new CarReport {
                Date = dtpDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReports.Add(carReport);
            dgvCarReport.ClearSelection();
            //if (cbAuthor.Text != string.Empty && cbCarName.Text != string.Empty) {
            inputItemsAllClear();
            //}

        }
        //入力項目をすべてクリア
        private void inputItemsAllClear() {
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            tslbMessage.Text = "";
            cbAuthor.Text = "";
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
            setRadioButtonMaker(CarReport.MakerGroup.無し);
        }

        //記録者の履歴をコンボボックスへ登録（重複なし）
        private void setCbAuthor(string author) {
            var idx = cbAuthor.Items.IndexOf(cbAuthor.Text);
            if (idx == -1) {
                cbAuthor.Items.Add(author);
            }
        }
        //車名の履歴をコンボボックスへ登録（重複なし）
        private void setCbCarName(string carName) {
            var idx = cbCarName.Items.IndexOf(cbCarName.Text);
            if (idx == -1) {
                cbCarName.Items.Add(carName);
            }
        }

        //選択されているメーカー名を列挙型で返す
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.トヨタ;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.日産;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.ホンダ;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.スバル;
            } else if (rbInport.Checked) {
                return CarReport.MakerGroup.輸入車;
            } else {
                return CarReport.MakerGroup.その他;
            }
        }
        //指定したメーカーのラジオボタンをセット
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.無し:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbInport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbOther.Checked = true;
                    break;
            }
        }

        private void rbAllClear() {
            rbToyota.Checked = false;
            rbNissan.Checked = false;
            rbHonda.Checked = false;
            rbSubaru.Checked = false;
            rbInport.Checked = false;
            rbOther.Checked = false;
        }



        private void btPicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK)
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
        }

        //削除ボタン
        private void btPicDelete_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;
            pbPicture.Image = null;
            dgvCarReport.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;//画像を表示しない
        }

        //修正ボタン
        private void dgvCarReport_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;
            dtpDate.Value = (DateTime)dgvCarReport.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvCarReport.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvCarReport.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvCarReport.CurrentRow.Cells["Carname"].Value;
            tbReport.Text = (string)dgvCarReport.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvCarReport.CurrentRow.Cells["picture"].Value;
        }

        private void btDeleteReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.CurrentRow == null) {
                tslbMessage.Text = "データが入力されていません";
                return;
            }
            listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
        }

        //修正ボタン
        private void btModifyReport_Click(object sender, EventArgs e) {
            if (dgvCarReport.Rows.Count == 0) return;
            if (dgvCarReport.CurrentRow == null) {
                tslbMessage.Text = "データが入力されていません";
                return;
            }
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "記録者、または車名が未入力です";
                return;
            }
            listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
            listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
            listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
            listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

            dgvCarReport.Refresh();//データグリッドビューの更新
        }

        //記録者のテキストが編集されたら
        private void cbAuthor_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }

        private void cbCarName_TextChanged(object sender, EventArgs e) {
            tslbMessage.Text = "";
        }
    }
}
