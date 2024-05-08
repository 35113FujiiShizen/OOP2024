namespace BallApp {
    public partial class Form1 : Form {
        Obj ball;
        PictureBox pb;

        //�R���X�g���N�^
        public Form1() {
            InitializeComponent();
        }
        //�t�H�[�����ŏ��Ƀ��[�h�����Ƃ���x�������s�����
        private void Form1_Load(object sender, EventArgs e) {
            //this.BackColor = Color.Green;

        }

        private void timer1_Tick(object sender, EventArgs e) {
            ball.Move();
            pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                pb = new PictureBox(); //�摜��\������R���g���[��
                pb.Size = new Size(50, 50);
                ball = new SoccerBall(e.X-25, e.Y-25);
                pb.Image = ball.Image;
                pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;
                timer1.Start();
            } else if(e.Button == MouseButtons.Right) {
                pb = new PictureBox(); //�摜��\������R���g���[��
                pb.Size = new Size(30, 30);
                ball = new TennisBall(e.X-15, e.Y-15);
                pb.Image = ball.Image;
                pb.Location = new Point((int)ball.PosX, (int)ball.PosY);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Parent = this;
                timer1.Start();
            }
        }
    }
}
