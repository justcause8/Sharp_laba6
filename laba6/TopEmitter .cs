using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6
{
    public class TopEmitter : Emitter
    {
        public int Width; // длина экрана

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); // вызываем базовый сброс частицы, там жизнь переопределяется и все такое

            // а теперь тут уже подкручиваем параметры движения
            particle.X = Particle.rand.Next(Width); // позиция X -- произвольная точка от 0 до Width
            particle.Y = 0;  // ноль -- это верх экрана 

            particle.SpeedY = 1; // падаем вниз по умолчанию
            particle.SpeedX = Particle.rand.Next(-2, 2); // разброс влево и вправа у частиц 
        }
    }
}
