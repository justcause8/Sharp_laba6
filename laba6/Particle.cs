using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace laba6
{
    public class Particle
    {
        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float Direction; // направление движения
        public float Speed; // скорость перемещения
        public float Life; // запас здоровья частицы

        // добавили генератор случайных чисел
        public static Random rand = new Random();

        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // я не трогаю координаты X, Y потому что хочу, чтобы все частицы возникали из одного места
            Direction = rand.Next(360);
            Speed = 1 + rand.Next(10);
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100); // Добавили исходный запас здоровья от 20 до 120
        }

        public virtual void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);
            int alpha = (int)(k * 255);

            var color = Color.FromArgb(alpha, Color.Black);
            var b = new SolidBrush(color); // создали кисть для рисования

            // нарисовали залитый кружок радиусом Radius с центром в X, Y
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }

    // новый класс для цветных частиц
    public class ParticleColorful : Particle
    {
        // два новых поля под цвет начальный и конечный
        public Color FromColor;
        public Color ToColor;

        // для смеси цветов
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        // ну и отрисовку перепишем
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            // так как k уменьшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }
    }
}
