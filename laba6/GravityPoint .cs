using System;
using System.Drawing;

namespace laba6
{
    public class GravityPoint : IImpactPoint
    {
        public int Power = 100; // сила притяжения

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // считаем расстояние от центра точки до центра частицы
            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                // то притягиваем ее
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }

        public override void Render(Graphics g)
        {
            // буду рисовать окружность с диаметром равным Power
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // обязательно выносим текст и шрифт в переменные
            var text = $"Я гравитон\nc силой {Power}";
            var font = new Font("Verdana", 10);

            // вызываем MeasureString, чтобы померить размеры текста
            var size = g.MeasureString(text, font);

            // рисуем подложнку под текст
            g.FillRectangle(
                new SolidBrush(Color.Red),
                X - size.Width / 2, // так как я выравнивал текст по центру то подложка должна быть центрирована относительно X,Y
                Y - size.Height / 2,
                size.Width,
                size.Height
            );

            // ну и текст рисую уже на базе переменных
            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }
}
