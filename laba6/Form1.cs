using static System.Windows.Forms.AxHost;

namespace laba6
{
    public partial class Form1 : Form
    {
        // Список эмиттеров на форме
        List<Emitter> emitters = new List<Emitter>();
        // Текущий эмиттер
        Emitter emitter;

        // Гравитационные точки
        private GravityPoint point1;
        private GravityPoint point2;

        // Антигравитационная точка и телепорт
        private AntiGravityPoint antiGravityPoint;
        private Teleport teleport;
        private Radar radar;

        // Флаги для отслеживания действий пользователя
        private bool isDraggingPoint1 = false;
        private bool isDraggingPoint2 = false;
        private bool teleportEnabled = false;
        private bool isDraggingAntiGravityPoint1 = false;
        private bool isDraggingRadar = false;

        // Начальные координаты для перемещения радара
        private int startX;
        private int startY;

        // Конструктор формы
        public Form1()
        {
            // Инициализация компонентов формы
            InitializeComponent();
            // Создание изображения для PictureBox
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            // Привязка обработчика события колесика мыши к методу
            picDisplay.MouseWheel += picDisplay_MouseWheel;

            // Создание и настройка первого эмиттера
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

            // Добавление эмиттера в список
            emitters.Add(this.emitter);
        }

        // Метод, вызываемый при срабатывании таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Обновление состояния эмиттера и перерисовка
            emitter.UpdateState();
            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        // Метод, вызываемый при изменении положения ползунка направления
        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            // Обновление направления эмиттера и текста метки
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        // Метод, вызываемый при изменении положения ползунка разброса
        private void tbDistribution_Scroll(object sender, EventArgs e)
        {
            // Обновление разброса эмиттера и текста метки
            emitter.Spreading = tbDistribution.Value;
            lblDistribution.Text = $"{tbDistribution.Value}°";
        }

        // Метод, вызываемый при изменении положения ползунка скорости
        private void tbSpeedDeparture_Scroll(object sender, EventArgs e)
        {
            // Обновление скорости эмиттера
            if (emitter != null)
            {
                emitter.SpeedMin = tbSpeedDeparture.Value;
                emitter.SpeedMax = tbSpeedDeparture.Value;
            }
        }

        // Метод, вызываемый при изменении положения ползунка времени жизни частиц
        private void tbLife_Scroll(object sender, EventArgs e)
        {
            // Обновление времени жизни частиц и перерисовка
            if (emitter != null)
            {
                emitter.LifeMin = tbLife.Value / 5;
                emitter.LifeMax = tbLife.Value;
                picDisplay.Invalidate();
            }
        }

        // Метод, вызываемый при изменении положения ползунка силы гравитации для точки 1
        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            // Обновление силы гравитации для точки 1
            point1.Power = tbGraviton.Value;
        }

        // Метод, вызываемый при изменении положения ползунка силы гравитации для точки 2
        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            // Обновление силы гравитации для точки 2
            point2.Power = tbGraviton2.Value;
        }

        // Метод, вызываемый при изменении состояния флажка гравитационных точек
        private void cbGraviton_CheckedChanged(object sender, EventArgs e)
        {
            // Добавление или удаление гравитационных точек в зависимости от состояния флажка
            if (cbGraviton.Checked)
            {
                // Создание и добавление гравитационной точки 1
                point1 = new GravityPoint
                {
                    X = picDisplay.Width / 2 + 100,
                    Y = picDisplay.Height / 2,
                };
                emitter.impactPoints.Add(point1);

                // Создание и добавление гравитационной точки 2
                point2 = new GravityPoint
                {
                    X = picDisplay.Width / 2 - 100,
                    Y = picDisplay.Height / 2,
                };
                emitter.impactPoints.Add(point2);

                // Разблокировка tbGraviton и tbGraviton2
                tbGraviton.Enabled = true;
                tbGraviton2.Enabled = true;
            }
            else
            {
                // Удаление гравитационной точки 1, если она существует
                if (point1 != null)
                {
                    emitter.impactPoints.Remove(point1);
                    point1 = null;
                }

                // Удаление гравитационной точки 2, если она существует
                if (point2 != null)
                {
                    emitter.impactPoints.Remove(point2);
                    point2 = null;
                }

                // Блокировка tbGraviton и tbGraviton2
                tbGraviton.Enabled = false;
                tbGraviton2.Enabled = false;
            }
        }

        // Метод, вызываемый при нажатии кнопки мыши на PictureBox
        private void picDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            // Логика для перетаскивания гравитационных точек, телепорта, антигравитационной точки и радара
            // Проверяем, попали ли мы в область гравитона point1
            if (point1 != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - point1.X) <= point1.Power / 2 &&
                Math.Abs(e.Y - point1.Y) <= point1.Power / 2)
            {
                isDraggingPoint1 = true;
            }

            // Проверяем, попали ли мы в область гравитона point2
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

            // Проверяем, попали ли мы в область AntiGravityPoint1
            if (antiGravityPoint != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - antiGravityPoint.X) <= antiGravityPoint.Power &&
                Math.Abs(e.Y - antiGravityPoint.Y) <= antiGravityPoint.Power)
            {
                isDraggingAntiGravityPoint1 = true;
            }

            // Проверяем, попали ли мы в область радара и нажали левую кнопку мыши
            if (radar != null && e.Button == MouseButtons.Left &&
                Math.Abs(e.X - radar.X) <= radar.Radius &&
                Math.Abs(e.Y - radar.Y) <= radar.Radius)
            {
                isDraggingRadar = true; // Устанавливаем флаг перемещения радара
                startX = e.X; // Запоминаем начальную позицию X
                startY = e.Y; // Запоминаем начальную позицию Y
            }

            picDisplay.Invalidate();
        }

        // Метод, вызываемый при перемещении мыши по PictureBox
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // Логика для обновления положения гравитационных точек, телепорта, антигравитационной точки и радара
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
                    // Вычисляем смещение относительно начальной позиции
                    float deltaX = e.X - startX;
                    float deltaY = e.Y - startY;

                    // Обновляем координаты радара
                    radar.X += deltaX;
                    radar.Y += deltaY;

                    startX = e.X; // Обновляем начальную позицию X для следующего перемещения
                    startY = e.Y; // Обновляем начальную позицию Y для следующего перемещения

                    picDisplay.Invalidate(); // Перерисовываем PictureBox
                }
            }
        }

        // Метод, вызываемый при отпускании кнопки мыши на PictureBox
        private void picDisplay_MouseUp(object sender, MouseEventArgs e)
        {
            // Сброс флагов перетаскивания
            isDraggingPoint1 = false;
            isDraggingPoint2 = false;
            isDraggingAntiGravityPoint1 = false;
            isDraggingRadar = false;
        }

        // Метод, вызываемый при изменении состояния флажка телепорта
        private void cbTeleport_CheckedChanged(object sender, EventArgs e)
        {
            // Включение или выключение телепорта в зависимости от состояния флажка
            teleportEnabled = cbTeleport.Checked;
            if (!teleportEnabled && teleport != null)
            {
                emitters[0].impactPoints.Remove(teleport);
                teleport = null;
                picDisplay.Invalidate();
            }

            // Включение или выключение элемента управления tbSizeTeletort
            tbSizeTeletort.Enabled = cbTeleport.Checked;
        }

        // Метод, вызываемый при изменении положения ползунка радиуса телепорта
        private void tbSizeTeletort_Scroll(object sender, EventArgs e)
        {
            // Обновление радиуса телепорта при изменении значения TrackBar
            if (teleport != null)
            {
                teleport.Radius = tbSizeTeletort.Value;
                picDisplay.Invalidate(); // Перерисовка PictureBox
            }
        }

        // Метод, вызываемый при прокрутке колесика мыши на PictureBox
        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            // Логика для изменения радиуса и силы антигравитационной точки и радара при прокрутке колесика мыши
            antiGravityPoint = emitters[0].impactPoints.FirstOrDefault(point => point is AntiGravityPoint) as AntiGravityPoint;

            if (antiGravityPoint != null)
            {
                // Изменяем радиус и силу отталкивания при движении колесика мыши
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
                // Изменяем радиус радара при движении колесика мыши
                if (e.Delta > 0)
                {
                    radar.Radius += 5;
                }
                else
                {
                    radar.Radius = Math.Max(0, radar.Radius - 5);
                }

                picDisplay.Invalidate(); // Перерисовываем PictureBox
            }
        }

        // Метод, вызываемый при изменении состояния флажка антигравитационной точки
        private void cbAntiGravity_CheckedChanged(object sender, EventArgs e)
        {
            // Включение или выключение антигравитационной точки в зависимости от состояния флажка
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

            picDisplay.Invalidate(); // Перерисовываем PictureBox
        }


        // Метод, вызываемый при изменении состояния флажка радара
        private void cbRadar_CheckedChanged(object sender, EventArgs e)
        {
            // Включение или выключение радара в зависимости от состояния флажка
            CheckBox checkBox = (CheckBox)sender;

            if (checkBox.Checked)
            {
                // Создаем и добавляем радар на форму
                radar = new Radar
                {
                    X = picDisplay.Width / 2 + 100, // Примерные координаты радара
                    Y = picDisplay.Height / 2,
                    Radius = 50 // Примерный радиус радара
                };

                emitters[0].impactPoints.Add(radar); // Добавляем радар на форму
            }
            else
            {
                // Удаляем радар из списка воздействия эмиттера
                emitters[0].impactPoints.RemoveAll(point => point is Radar);

                // Удаляем радар из контейнера Controls, если он был добавлен
                foreach (Control control in this.Controls)
                {
                    if (control is Radar)
                    {
                        this.Controls.Remove(control);
                        break; // Прерываем цикл, если радар был удален
                    }
                }
            }

            picDisplay.Invalidate(); // Перерисовываем picDisplay
        }
    }
}
