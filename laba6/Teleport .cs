using System;
using System.Drawing;

namespace laba6
{
    public class Teleport : IImpactPoint
    {
        public float EntranceX;
        public float EntranceY;
        public float ExitX;
        public float ExitY;
        public float Radius;

        private Random random = new Random();

        // В вашем классе Teleport создайте массив из четырех цветов
        Color[] teleportColors = new Color[]
        {
            Color.FromArgb(34, 40, 49),     // 222831
            Color.FromArgb(57, 62, 70),     // 393E46
            Color.FromArgb(0, 173, 181),    // 00ADB5
            Color.FromArgb(238, 238, 238)   // EEEEEE
        };

        public Teleport(float entranceX, float entranceY,float radius)
        {
            EntranceX = entranceX;
            EntranceY = entranceY;
            Radius = radius;
        }

        public override void ImpactParticle(Particle particle)
        {
            float distanceToEntrance = (float)Math.Sqrt(Math.Pow(EntranceX - particle.X, 2) + Math.Pow(EntranceY - particle.Y, 2));
            float distanceToExit = (float)Math.Sqrt(Math.Pow(ExitX - particle.X, 2) + Math.Pow(ExitY - particle.Y, 2));

            if (distanceToEntrance <= Radius)
            {
                // Частица попала в радиус действия входного телепорта
                particle.FromTeleport = true;

                // Генерируем случайный угол для направления вылета
                double randomAngle = random.NextDouble() * 2 * Math.PI;

                // Вычисляем новые координаты частицы на основе сгенерированного угла
                particle.X = ExitX + (float)(Radius * Math.Cos(randomAngle));
                particle.Y = ExitY + (float)(Radius * Math.Sin(randomAngle));
            }
            else if (distanceToExit <= Radius)
            {
                // Частица выходит из телепорта и меняет цвет
                if (particle.FromTeleport)
                {
                    if (particle is ParticleColorful colorfulParticle)
                    {
                        // Выбираем случайный цвет из массива
                        Random rnd = new Random();
                        int index = rnd.Next(teleportColors.Length);
                        colorfulParticle.FromColor = teleportColors[index];
                        colorfulParticle.ToColor = Color.FromArgb(0, colorfulParticle.FromColor);
                    }
                    // Сбрасываем флаг FromTeleport для предотвращения повторного окрашивания
                    particle.FromTeleport = false;
                }
            }
        }


        public override void Render(Graphics g)
        {
            // Рисуем круг для обозначения положения точки входа телепорта
            g.DrawEllipse(Pens.Blue, EntranceX - Radius, EntranceY - Radius, Radius * 2, Radius * 2);

            // Рисуем круг для обозначения положения точки выхода телепорта
            g.DrawEllipse(Pens.Red, ExitX - Radius, ExitY - Radius, Radius * 2, Radius * 2);
        }
    }
}
