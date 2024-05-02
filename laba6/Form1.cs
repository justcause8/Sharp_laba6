namespace laba6
{
    public partial class Form1 : Form
    {
        // ���������� ������, ���� ������
        List<Particle> particles = new List<Particle>();
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            for (var i = 0; i < 100; ++i)
            {
                var particle = new Particle();
                // �������� ������� � ����� �����������
                particle.X = picDisplay.Image.Width / 2;
                particle.Y = picDisplay.Image.Height / 2;
                // �������� ������
                particles.Add(particle);
            }
        }

        // ������� ������� ���������� ��������� �������
        private void UpdateState()
        {
            foreach (var particle in particles)
            {
                var directionInRadians = particle.Direction / 180 * Math.PI;
                particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
            }
        }

        // ������� ����������
        private void Render(Graphics g)
        {
            // ������� ���� ��������� ������
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White); // ������� �������
                foreach (var particle in particles)
                {
                    particle.Draw(g);
                    Render(g);
                }
            }
            // �������� picDisplay
            picDisplay.Invalidate();
        }
    }
}
