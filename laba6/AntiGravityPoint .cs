using System;
using System.Drawing;

namespace laba6
{
    public class AntiGravityPoint : IImpactPoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        public int Radius; 
        public int Power;

        // Метод для обработки столкновения частиц с точкой отталкивания
        public override void ImpactParticle(Particle particle)
        {
            float gX = particle.X - X;
            float gY = particle.Y - Y;
            float distanceSquared = gX * gX + gY * gY;

            if (distanceSquared < Power * Power)
            {
                double angle = Math.Atan2(particle.SpeedY, particle.SpeedX);
                double reflectionAngle = Math.Atan2(gY, gX);

                double totalSpeed = Math.Sqrt(particle.SpeedX * particle.SpeedX + particle.SpeedY * particle.SpeedY);

                // Установка нового угла для скорости частицы
                particle.SpeedX = (float)(totalSpeed * Math.Cos(reflectionAngle));
                particle.SpeedY = (float)(totalSpeed * Math.Sin(reflectionAngle));
            }
        }



        // Метод для отрисовки области точки отталкивания
        public override void Render(Graphics g)
        {
            // Рисование оранжевой окантовки
            g.DrawEllipse(Pens.Red, X - Power, Y - Power, Power * 2, Power * 2);
        }
    }
}
