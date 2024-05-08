namespace BallApp {
    public partial class Form1 : Form {
        SoccerBall soccerBoll;
        PictureBox pb;

        //コンストラクタ
        public Form1() {
            InitializeComponent();
        }
        //フォームが最初にロードされるとき一度だけ実行される
        private void Form1_Load(object sender, EventArgs e) {
            //this.BackColor = Color.Green;

        }

        private void timer1_Tick(object sender, EventArgs e) {
            soccerBoll.Move();
            pb.Location = new Point((int)soccerBoll.PosX, (int)soccerBoll.PosY);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            pb = new PictureBox();　//画像を表示するコントロール
            pb.Size = new Size(50, 50);

            soccerBoll = new SoccerBall(e.X, e.Y);

            pb.Image = soccerBoll.Image;
            pb.Location = new Point((int)soccerBoll.PosX, (int)soccerBoll.PosY);
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Parent = this;

            timer1.Start();
        }
    }
}
