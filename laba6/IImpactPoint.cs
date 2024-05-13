using System;
using System.Collections.Generic;
using System.Drawing; // Для работы с графикой
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    // Абстрактный класс, представляющий базовую абстракцию точки воздействия
    public abstract class IImpactPoint
    {
        // Координаты X и Y точки воздействия
        public float X;
        public float Y;

        // Метод, который будет реализован в классах-наследниках для взаимодействия с частицами
        public abstract void ImpactParticle(Particle particle);

        // Метод для отрисовки точки воздействия
        public virtual void Render(Graphics g)
        {
            // Отрисовка окружности, представляющей точку воздействия
            g.FillEllipse(
                new SolidBrush(Color.Red), // Кисть для заливки красным цветом
                X - 5, // Координата X верхнего левого угла окружности
                Y - 5, // Координата Y верхнего левого угла окружности
                10, // Ширина окружности
                10 // Высота окружности
            );
        }
    }
}
