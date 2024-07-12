using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CarReportSystem {
    public partial class Form1 : Form {

        //�J�[���|�[�g�Ǘ��p���X�g
        BindingList<CarReport> listCarReports = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X�𐶐�
        Settings setting = Settings.getInstance();


        public Form1() {
            InitializeComponent();
            dgvCarReport.DataSource = listCarReports;
        }
        //�ǉ��{�^��
        private void btAddReport_Click(object sender, EventArgs e) {
            if (cbAuthor.Text == "" || cbCarName.Text == "") {
                tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
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
            dgvCarReport.ClearSelection();//�Z���N�V�������O��
            //if (cbAuthor.Text != string.Empty && cbCarName.Text != string.Empty) {
            inputItemsAllClear();
            //}

        }
        //���͍��ڂ����ׂăN���A
        private void inputItemsAllClear() {
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            tslbMessage.Text = "";
            cbAuthor.Text = "";
            cbCarName.Text = "";
            tbReport.Text = "";
            pbPicture.Image = null;
            setRadioButtonMaker(CarReport.MakerGroup.����);
        }

        //�L�^�҂̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbAuthor(string author) {
            var idx = cbAuthor.Items.IndexOf(cbAuthor.Text);
            if (idx == -1) {
                cbAuthor.Items.Add(author);
            }
        }
        //�Ԗ��̗������R���{�{�b�N�X�֓o�^�i�d���Ȃ��j
        private void setCbCarName(string carName) {
            var idx = cbCarName.Items.IndexOf(cbCarName.Text);
            if (idx == -1) {
                cbCarName.Items.Add(carName);
            }
        }

        //�I������Ă��郁�[�J�[����񋓌^�ŕԂ�
        private CarReport.MakerGroup GetRadioButtonMaker() {
            if (rbToyota.Checked) {
                return CarReport.MakerGroup.�g���^;
            } else if (rbNissan.Checked) {
                return CarReport.MakerGroup.���Y;
            } else if (rbHonda.Checked) {
                return CarReport.MakerGroup.�z���_;
            } else if (rbSubaru.Checked) {
                return CarReport.MakerGroup.�X�o��;
            } else if (rbInport.Checked) {
                return CarReport.MakerGroup.�A����;
            } else {
                return CarReport.MakerGroup.���̑�;
            }
        }
        //�w�肵�����[�J�[�̃��W�I�{�^�����Z�b�g
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.����:
                    rbAllClear();
                    break;
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbInport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
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

        //�폜�{�^��
        private void btPicDelete_Click(object sender, EventArgs e) {
            if ((dgvCarReport.CurrentRow == null)
                || (!dgvCarReport.CurrentRow.Selected)) return;
            pbPicture.Image = null;
            dgvCarReport.ClearSelection();
        }

        private void Form1_Load(object sender, EventArgs e) {
            dgvCarReport.Columns["Picture"].Visible = false;//�摜��\�����Ȃ�

            //���݂ɐF��ݒ�i�f�[�^�O���b�h�r���[�j
            dgvCarReport.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgvCarReport.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

            if (File.Exists("settings.xml")) {
                try {
                    //�ݒ�t�@�C�����t�V���A�������Ĕw�i��ݒ�
                    using (var reader = XmlReader.Create("settings.xml")) {
                        var serializer = new XmlSerializer(typeof(Settings));
                        var setting = serializer.Deserialize(reader) as Settings;
                        BackColor = Color.FromArgb(setting.MainFormColor);
                        setting.MainFormColor = BackColor.ToArgb();
                    }
                }
                catch (Exception ex) {
                    tslbMessage.Text = "�F���t�@�C���G���[";
                }
            } else {
                tslbMessage.Text = "�F��񂪂���܂���";
            }
    }


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

    //�폜�{�^��
    private void btDeleteReport_Click(object sender, EventArgs e) {
        if (dgvCarReport.CurrentRow == null) {
            tslbMessage.Text = "�f�[�^�����͂���Ă��܂���";
            return;
        }
        listCarReports.RemoveAt(dgvCarReport.CurrentRow.Index);
    }

    //�C���{�^��
    private void btModifyReport_Click(object sender, EventArgs e) {
        if (dgvCarReport.Rows.Count == 0) return;
        if (dgvCarReport.CurrentRow == null) {
            tslbMessage.Text = "�f�[�^�����͂���Ă��܂���";
            return;
        }
        if (cbAuthor.Text == "" || cbCarName.Text == "") {
            tslbMessage.Text = "�L�^�ҁA�܂��͎Ԗ��������͂ł�";
            return;
        }
        listCarReports[dgvCarReport.CurrentRow.Index].Date = dtpDate.Value;
        listCarReports[dgvCarReport.CurrentRow.Index].Author = cbAuthor.Text;
        listCarReports[dgvCarReport.CurrentRow.Index].Maker = GetRadioButtonMaker();
        listCarReports[dgvCarReport.CurrentRow.Index].CarName = cbCarName.Text;
        listCarReports[dgvCarReport.CurrentRow.Index].Report = tbReport.Text;
        listCarReports[dgvCarReport.CurrentRow.Index].Picture = pbPicture.Image;

        dgvCarReport.Refresh();//�f�[�^�O���b�h�r���[�̍X�V
    }

    //�L�^�҂̃e�L�X�g���ҏW���ꂽ��
    private void cbAuthor_TextChanged(object sender, EventArgs e) {
        tslbMessage.Text = "";
    }
    //�Ԗ��̃e�L�X�g���ҏW���ꂽ��
    private void cbCarName_TextChanged(object sender, EventArgs e) {
        tslbMessage.Text = "";
    }
    //�ۑ��{�^��
    private void ReportSave_Click(object sender, EventArgs e) {
        ReportSaveFile();//�t�@�C���Z�[�u����

    }
    //�t�@�C���Z�[�u����
    private void ReportSaveFile() {
        if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
            try {
                //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                using (FileStream fs = File.Open(sfdReportFileSave.FileName, FileMode.Create)) {
                    bf.Serialize(fs, listCarReports);
                }
            }
            catch (Exception) {
                tslbMessage.Text = "�������݃G���[";
            }
        }
    }

    //�J���{�^���C�x���g�n���h���[
    private void btReportOpen_Click(object sender, EventArgs e) {
        ReportOpenFile();//�t�@�C���I�[�v������
    }
    //�t�@�C���I�[�v������
    private void ReportOpenFile() {
        if (ofdReportFileOpen.ShowDialog() == DialogResult.OK) {
            try {
                //�t�V���A�����Ńo�C�i���`������荞��
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�

                using (FileStream fs = File.Open(ofdReportFileOpen.FileName, FileMode.Open, FileAccess.Read)) {
                    listCarReports = (BindingList<CarReport>)bf.Deserialize(fs);
                    dgvCarReport.DataSource = listCarReports;

                    foreach (var carReport in listCarReports) {
                        setCbAuthor(carReport.Author);
                        setCbCarName(carReport.CarName);
                    }
                    tslbMessage.Text = "";
                }
            }
            catch (Exception ex) {
                tslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
            }
            dgvCarReport.ClearSelection();//�Z���N�V�������O��
        }
    }

    private void btClear_Click(object sender, EventArgs e) {
        inputItemsAllClear();
    }

    private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
        ReportOpenFile();//�t�@�C���I�[�v������
    }

    private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
        ReportSaveFile();//�t�@�C���Z�[�u����
    }

    private void �I��ToolStripMenuItem_Click(object sender, EventArgs e) {
        if (MessageBox.Show("�A�v���P�[�V�������I�����܂����H", "�m�F", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
            Application.Exit();
        }
    }

    private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
        if (cdColor.ShowDialog() == DialogResult.OK) {
            BackColor = cdColor.Color;//�w�i�F�ݒ�
            setting.MainFormColor = cdColor.Color.ToArgb();//�w�i�F�ۑ�
        }
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
        //�ݒ�t�@�C���̃V���A����
        try {
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(setting.GetType());
                serializer.Serialize(writer, setting);
            }
        }
        catch (Exception) {
            MessageBox.Show("�ݒ�t�@�C���������݃G���[");
        }
    }
}
}
