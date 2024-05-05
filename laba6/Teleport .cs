using System;
using System.Drawing;

namespace laba6
{
    public class Teleporter : IImpactPoint
    {
        public float EntranceX { get; set; }
        public float EntranceY { get; set; }
        public float ExitX { get; set; }
        public float ExitY { get; set; }
        public float Radius { get; set; }

        private Random random = new Random();

        public Teleporter(float entranceX, float entranceY, float exitX, float exitY, float radius)
        {
            EntranceX = entranceX;
            EntranceY = entranceY;
            ExitX = exitX;
            ExitY = exitY;
            Radius = radius;
        }

        public override void ImpactParticle(Particle particle)
        {
            float distanceToEntrance = (float)Math.Sqrt(Math.Pow(EntranceX - particle.X, 2) + Math.Pow(EntranceY - particle.Y, 2));
            particle.FromTeleporter = true;

            if (distanceToEntrance <= Radius)
            {
                // Генерируем случайный угол для направления вылета
                double randomAngle = random.NextDouble() * 2 * Math.PI;

                // Вычисляем новые координаты частицы на основе сгенерированного угла
                particle.X = ExitX + (float)(Radius * Math.Cos(randomAngle));
                particle.Y = ExitY + (float)(Radius * Math.Sin(randomAngle));

                // Изменяем цвет только для частиц, выходящих из телепорта
                if (particle is ParticleColorful colorfulParticle)
                {
                    colorfulParticle.FromColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                    colorfulParticle.ToColor = Color.FromArgb(0, colorfulParticle.FromColor);
                }
            }
        }

        public override void Render(Graphics g)
        {
            // Рисуем окружность для обозначения радиуса действия телепорта
            g.DrawEllipse(new Pen(Color.Blue), EntranceX - Radius, EntranceY - Radius, Radius * 2, Radius * 2);
        }
    }
}
