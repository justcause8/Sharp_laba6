using static System.Windows.Forms.AxHost;

namespace laba6
{
    public partial class Form1 : Form
    {
        // ������ ��������� �� �����
        List<Emitter> emitters = new List<Emitter>();
        // ������� �������
        Emitter emitter;

        // �������������� �����
        private GravityPoint point1;
        private GravityPoint point2;

        // ������������������ ����� � ��������
        private AntiGravityPoint antiGravityPoint;
        private Teleport teleport;
        private Radar radar;

        // ����� ��� ������������ �������� ������������
        private bool isDraggingPoint1 = false;
        private bool isDraggingPoint2 = false;
        private bool teleportEnabled = false;
        private bool isDraggingAntiGravityPoint1 = false;
        private bool isDraggingRadar = false;

        // ��������� ���������� ��� ����������� ������
        private int startX;
        private int startY;

        // ����������� �����
        public Form1()
        {
            // ������������� ����������� �����
            InitializeComponent();
            // �������� ����������� ��� PictureBox
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            // �������� ����������� ������� �������� ���� � ������
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            // �������� � ��������� ������� ��������
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

            // ���������� �������� � ������
            emitters.Add(this.emitter);
        }

        // �����, ���������� ��� ������������ �������
        private void timer1_Tick(object sender, EventArgs e)
        {
            // ���������� ��������� �������� � �����������
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        // �����, ���������� ��� ��������� ��������� �������� �����������
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            // ���������� ����������� �������� � ������ �����
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}�";
        }

        // �����, ���������� ��� ��������� ��������� �������� ��������
        private void tbDistribution_Scroll(object sender, EventArgs e)
        {
            // ���������� �������� �������� � ������ �����
            emitter.Spreading = tbDistribution.Value;
            lblDistribution.Text = $"{tbDistribution.Value}�";
        }

        // �����, ���������� ��� ��������� ��������� �������� ��������
        private void tbSpeedDeparture_Scroll(object sender, EventArgs e)
        {
            // ���������� �������� ��������
            if (emitter != null)
            {
                emitter.SpeedMin = tbSpeedDeparture.Value;
                emitter.SpeedMax = tbSpeedDeparture.Value;
            }
        }

        // �����, ���������� ��� ��������� ��������� �������� ������� ����� ������
        private void tbLife_Scroll(object sender, EventArgs e)
        {
            // ���������� ������� ����� ������ � �����������
            if (emitter != null)
            {
                emitter.LifeMin = tbLife.Value / 5;
                emitter.LifeMax = tbLife.Value;
                picDisplay.Invalidate();
            }
        }

        // �����, ���������� ��� ��������� ��������� �������� ���� ���������� ��� ����� 1
        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            // ���������� ���� ���������� ��� ����� 1
            point1.Power = tbGraviton.Value;
        }

        // �����, ���������� ��� ��������� ��������� �������� ���� ���������� ��� ����� 2
        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            // ���������� ���� ���������� ��� ����� 2
            point2.Power = tbGraviton2.Value;
        }

        // �����, ���������� ��� ��������� ��������� ������ �������������� �����
        private void cbGraviton_CheckedChanged(object sender, EventArgs e)
        {
            // ���������� ��� �������� �������������� ����� � ����������� �� ��������� ������
            if (cbGraviton.Checked)
            {
                // �������� � ���������� �������������� ����� 1
                point1 = new GravityPoint
                {
                    X = picDisplay.Width / 2 + 100,
                    Y = picDisplay.Height / 2,
                };
                emitter.impactPoints.Add(point1);

                // �������� � ���������� �������������� ����� 2
                point2 = new GravityPoint
                {
                    X = picDisplay.Width / 2 - 100,
                    Y = picDisplay.Height / 2,
                };
                emitter.impactPoints.Add(point2);

                // ������������� tbGraviton � tbGraviton2
                tbGraviton.Enabled = true;
                tbGraviton2.Enabled = true;
            }
            else
            {
                // �������� �������������� ����� 1, ���� ��� ����������
                if (point1 != null)
                {
                    emitter.impactPoints.Remove(point1);
                    point1 = null;
                }

                // �������� �������������� ����� 2, ���� ��� ����������
                if (point2 != null)
                {
                    emitter.impactPoints.Remove(point2);
                    point2 = null;
                }

                // ���������� tbGraviton � tbGraviton2
                tbGraviton.Enabled = false;
                tbGraviton2.Enabled = false;
            }
        }

        // �����, ���������� ��� ������� ������ ���� �� PictureBox
        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // ������ ��� �������������� �������������� �����, ���������, ������������������ ����� � ������
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

            // ���������, ������ �� �� � ������� AntiGravityPoint1
            if (antiGravityPoint != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - antiGravityPoint.X) <= antiGravityPoint.Power &&
                Math.Abs(e.Y - antiGravityPoint.Y) <= antiGravityPoint.Power)
            {
                isDraggingAntiGravityPoint1 = true;
            }

            // ���������, ������ �� �� � ������� ������ � ������ ����� ������ ����
            if (radar != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - radar.X) <= radar.Radius &&
                Math.Abs(e.Y - radar.Y) <= radar.Radius)
            {
                isDraggingRadar = true; // ������������� ���� ����������� ������
                startX = e.X; // ���������� ��������� ������� X
                startY = e.Y; // ���������� ��������� ������� Y
            }

            picDisplay.Invalidate();
        }

        // �����, ���������� ��� ����������� ���� �� PictureBox
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // ������ ��� ���������� ��������� �������������� �����, ���������, ������������������ ����� � ������
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

            if (isDraggingAntiGravityPoint1)
            {
                if (antiGravityPoint != null)
                {
                    antiGravityPoint.X = e.X;
                    antiGravityPoint.Y = e.Y;
                    picDisplay.Invalidate();
                }
            }

            if (isDraggingRadar)
            {
                if (radar != null)
                {
                    // ��������� �������� ������������ ��������� �������
                    float deltaX = e.X - startX;
                    float deltaY = e.Y - startY;

                    // ��������� ���������� ������
                    radar.X += deltaX;
                    radar.Y += deltaY;

                    startX = e.X; // ��������� ��������� ������� X ��� ���������� �����������
                    startY = e.Y; // ��������� ��������� ������� Y ��� ���������� �����������

                    picDisplay.Invalidate(); // �������������� PictureBox
                }
            }
        }

        // �����, ���������� ��� ���������� ������ ���� �� PictureBox
        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // ����� ������ ��������������
            isDraggingPoint1 = false;
            isDraggingPoint2 = false;
            isDraggingAntiGravityPoint1 = false;
            isDraggingRadar = false;
        }

        // �����, ���������� ��� ��������� ��������� ������ ���������
        private void cbTeleport_CheckedChanged(object sender, EventArgs e)
        {
            // ��������� ��� ���������� ��������� � ����������� �� ��������� ������
            teleportEnabled = cbTeleport.Checked;
            if (!teleportEnabled && teleport != null)
            {
                emitters[0].impactPoints.Remove(teleport);
                teleport = null;
                picDisplay.Invalidate();
            }

            // ��������� ��� ���������� �������� ���������� tbSizeTeletort
            tbSizeTeletort.Enabled = cbTeleport.Checked;
        }

        // �����, ���������� ��� ��������� ��������� �������� ������� ���������
        private void tbSizeTeletort_Scroll(object sender, EventArgs e)
        {
            // ���������� ������� ��������� ��� ��������� �������� TrackBar
            if (teleport != null)
            {
                teleport.Radius = tbSizeTeletort.Value;
                picDisplay.Invalidate(); // ����������� PictureBox
            }
        }

        // �����, ���������� ��� ��������� �������� ���� �� PictureBox
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            // ������ ��� ��������� ������� � ���� ������������������ ����� � ������ ��� ��������� �������� ����
            antiGravityPoint = emitters[0].impactPoints.FirstOrDefault(point => point is AntiGravityPoint) as AntiGravityPoint;

            if (antiGravityPoint != null)
            {
                // �������� ������ � ���� ������������ ��� �������� �������� ����
                if (e.Delta > 0)
                {
                    antiGravityPoint.Radius += 5;
                    antiGravityPoint.Power += 20;
                }
                else
                {
                    antiGravityPoint.Radius = Math.Max(0, antiGravityPoint.Radius - 5);
                    antiGravityPoint.Power = Math.Max(0, antiGravityPoint.Power - 5);
                }

                picDisplay.Invalidate();
            }

            if (radar != null)
            {
                // �������� ������ ������ ��� �������� �������� ����
                if (e.Delta > 0)
                {
                    radar.Radius += 5;
                }
                else
                {
                    radar.Radius = Math.Max(0, radar.Radius - 5);
                }

                picDisplay.Invalidate(); // �������������� PictureBox
            }
        }

        // �����, ���������� ��� ��������� ��������� ������ ������������������ �����
        private void cbAntiGravity_CheckedChanged(object sender, EventArgs e)
        {
            // ��������� ��� ���������� ������������������ ����� � ����������� �� ��������� ������
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                var antiGravityPoint1 = new AntiGravityPoint
                {
                    X = picDisplay.Width / 2 + 50,
                    Y = picDisplay.Height / 2,
                    Power = 100
                };

                emitters[0].impactPoints.Add(antiGravityPoint1);
            }
            else
            {
                emitters[0].impactPoints.RemoveAll(point => point is AntiGravityPoint);
            }

            picDisplay.Invalidate(); // �������������� PictureBox
        }


        // �����, ���������� ��� ��������� ��������� ������ ������
        private void cbRadar_CheckedChanged(object sender, EventArgs e)
        {
            // ��������� ��� ���������� ������ � ����������� �� ��������� ������
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                // ������� � ��������� ����� �� �����
                radar = new Radar
                {
                    X = picDisplay.Width / 2 + 100, // ��������� ���������� ������
                    Y = picDisplay.Height / 2,
                    Radius = 50 // ��������� ������ ������
                };

                emitters[0].impactPoints.Add(radar); // ��������� ����� �� �����
            }
            else
            {
                // ������� ����� �� ������ ����������� ��������
                emitters[0].impactPoints.RemoveAll(point => point is Radar);

                // ������� ����� �� ���������� Controls, ���� �� ��� ��������
                foreach (Control control in this.Controls)
                {
                    if (control is Radar)
                    {
                        this.Controls.Remove(control);
                        break; // ��������� ����, ���� ����� ��� ������
                    }
                }
            }

            picDisplay.Invalidate(); // �������������� picDisplay
        }
    }
}
