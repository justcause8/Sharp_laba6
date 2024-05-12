namespace laba6
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;
        GravityPoint point2;

        private bool isDraggingPoint1 = false;
        private bool isDraggingPoint2 = false;
        private bool teleportEnabled = false;

        private Teleport teleport;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

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



        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}�";
        }

        private void tbDistribution_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbDistribution.Value;
            lblDistribution.Text = $"{tbDistribution.Value}�";
        }

        private void tbSpeedDeparture_Scroll(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                emitter.SpeedMin = tbSpeedDeparture.Value;
                emitter.SpeedMax = tbSpeedDeparture.Value;
            }
        }

        private void tbLife_Scroll(object sender, EventArgs e)
        {
            if (emitter != null)
            {
                emitter.LifeMin = tbLife.Value / 5;
                emitter.LifeMax = tbLife.Value;
                picDisplay.Invalidate();
            }
        }



        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }

        private void cbGraviton_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGraviton.Checked)
            {
                // �������� � ���������� ��������� point1
                point1 = new GravityPoint
                {
                    X = picDisplay.Width / 2 + 100,
                    Y = picDisplay.Height / 2,
                };
                emitter.impactPoints.Add(point1);

                // �������� � ���������� ��������� point2
                point2 = new GravityPoint
                {
                    X = picDisplay.Width / 2 - 100,
                    Y = picDisplay.Height / 2,
                };
                emitter.impactPoints.Add(point2);
            }
            else
            {
                // �������� ��������� point1, ���� �� ����������
                if (point1 != null)
                {
                    emitter.impactPoints.Remove(point1);
                    point1 = null;
                }

                // �������� ��������� point2, ���� �� ����������
                if (point2 != null)
                {
                    emitter.impactPoints.Remove(point2);
                    point2 = null;
                }
            }
        }

        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // ���������, ������ �� �� � ������� ��������� point1
            if (point1 != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - point1.X) <= point1.Power / 2 &&
                Math.Abs(e.Y - point1.Y) <= point1.Power / 2)
            {
                isDraggingPoint1 = true;
            }

            // ���������, ������ �� �� � ������� ��������� point2
            if (point2 != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - point2.X) <= point2.Power / 2 &&
                Math.Abs(e.Y - point2.Y) <= point2.Power / 2)
            {
                isDraggingPoint2 = true;
            }

            if (teleportEnabled)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (teleport == null)
                    {
                        teleport = new Teleport(e.X, e.Y, 40);
                        teleport.ExitX = e.X;
                        teleport.ExitY = e.Y;
                        emitters[0].impactPoints.Add(teleport);
                    }
                    else
                    {
                        teleport.EntranceX = e.X;
                        teleport.EntranceY = e.Y;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (teleport == null)
                    {
                        teleport = new Teleport(e.X, e.Y, 40);
                        teleport.X = e.X;
                        teleport.Y = e.Y;
                        emitters[0].impactPoints.Add(teleport);
                    }
                    else
                    {
                        teleport.ExitX = e.X;
                        teleport.ExitY = e.Y;
                    }
                }

            }
            picDisplay.Invalidate();
        }



        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraggingPoint1)
            {
                point1.X = e.X;
                point1.Y = e.Y;
                picDisplay.Invalidate();
            }

            if (isDraggingPoint2)
            {
                point2.X = e.X;
                point2.Y = e.Y;
                picDisplay.Invalidate();
            }
        }

        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            isDraggingPoint1 = false;
            isDraggingPoint2 = false;
        }


        private void cbTeleport_CheckedChanged(object sender, EventArgs e)
        {
            teleportEnabled = cbTeleport.Checked;
            if (!teleportEnabled && teleport != null)
            {
                emitters[0].impactPoints.Remove(teleport);
                teleport = null;
                picDisplay.Invalidate();
            }
        }

        private void tbSizeTeletort_Scroll(object sender, EventArgs e)
        {
            // �������� ������ ��������� ��� ��������� �������� TrackBar
            if (teleport != null)
            {
                teleport.Radius = tbSizeTeletort.Value;
                picDisplay.Invalidate(); // ����������� PictureBox
            }
        }
    }
}
