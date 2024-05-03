namespace laba6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;
        GravityPoint point2;

        private Circle circle;
        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // Создаем круг с радиусом 50 и центром в середине формы
            circle = new Circle(new Point(picDisplay.Width / 2, picDisplay.Height / 2), 50);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.White,
                ColorTo = Color.FromArgb(0, Color.Gray),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            // привязываем гравитоны к полям
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }



        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbDistribution_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbDistribution.Value;
            lblDistribution.Text = $"{tbDistribution.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {

        }

        private void tbRadius_Scroll(object sender, EventArgs e)
        {
            if (circle != null)
            {
                circle.Radius = tbRadius.Value;
                picDisplay.Invalidate();
            }
        }




        private void cbCircle_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCircle.Checked)
            {
                // Если флажок выбран, создаем новый круг в центре формы с начальным радиусом
                circle = new Circle(tbRadius.Value, new Point(picDisplay.Width / 2, picDisplay.Height / 2));
            }
            else
            {
                // Если флажок не выбран, удаляем круг
                circle = null;
            }

            picDisplay.Invalidate();
        }

        private void tbSpeedDeparture_Scroll(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                emitter.SpeedMin = tbSpeedDeparture.Value;
                emitter.SpeedMax = tbSpeedDeparture.Value;
            }
        }

        private void tbNumberOfParticles_Scroll(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                emitter.ParticlesPerTick = tbNumberOfParticles.Value;
                emitter.UpdateState(); // Пересоздаем частицы с учетом нового значения
                UpdateTotalParticlesCount(); // Обновляем общее количество частиц
            }
        }

        private void UpdateTotalParticlesCount()
        {
            if (emitter != null)
            {
                int totalParticles = emitters.Sum(e => e.GetTotalParticlesCount());
                rtbTotalCountParticles.Text = $"{totalParticles}";
            }
        }

        /*private void UpdateTotalParticlesCount()
        {
            rtbTotalCountParticles.Text = $"{tbNumberOfParticles.Value}";
        }*/

        private void tbLife_Scroll(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                emitter.LifeMin = tbLife.Value / 5;
                emitter.LifeMax = tbLife.Value;
                picDisplay.Invalidate();
            }
        }
    }
}
