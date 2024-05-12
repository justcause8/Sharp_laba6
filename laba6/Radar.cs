using System;
using System.Collections.Generic;
using System.Drawing;

namespace laba6
{
    public class Radar : IImpactPoint
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Radius { get; set; } // Радиус радара
        private List<Particle> particlesInsideRadar = new List<Particle>(); // Список частиц внутри радара

        // Добавляем свойство для цвета подсветки
        public Color HighlightColor { get; set; } = Color.Yellow;

        // Метод для воздействия на частицу
        public override void ImpactParticle(Particle particle)
        {
            // Проверяем, находится ли частица внутри радара
            if (IsParticleInsideRadar(particle))
            {
                // Если частица еще не была обработана, добавляем ее в список частиц внутри радара
                if (!particle.IsInRadarArea)
                {
                    particlesInsideRadar.Add(particle);
                    particle.IsInRadarArea = true; // Помечаем частицу, что она попала в радар

                    // Установка цвета частицы
                    if (particle is ParticleColorful colorfulParticle)
                    {
                        // Устанавливаем красный цвет
                        colorfulParticle.FromColor = Color.LimeGreen;
                        colorfulParticle.ToColor = Color.LimeGreen;
                    }
                }
            }
            else
            {
                // Если частица была внутри радара и вышла из него, удаляем ее из списка частиц внутри радара
                if (particle.IsInRadarArea)
                {
                    particlesInsideRadar.Remove(particle);
                    particle.IsInRadarArea = false; // Сбрасываем пометку о попадании в радар

                    // Возвращаем частице ее исходный цвет
                    if (particle is ParticleColorful colorfulParticle)
                    {
                        colorfulParticle.FromColor = particle.InitialColor;
                        colorfulParticle.ToColor = particle.InitialColor;
                    }
                }
            }
        }




        // Метод для отрисовки радара
        public override void Render(Graphics g)
        {
            // Рисуем круг радара
            g.DrawEllipse(Pens.Yellow, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);

            // Определяем размер строки текста
            string text = $"{particlesInsideRadar.Count}";
            SizeF textSize = g.MeasureString(text, new Font("Arial", 10));

            // Вычисляем координаты для вывода строки текста по центру радара
            float textX = X - textSize.Width / 2;
            float textY = Y - textSize.Height / 2;

            // Выводим количество обнаруженных частиц в центре радара
            g.DrawString(text, new Font("Arial", 10), Brushes.Yellow, textX, textY);
        }


        // Метод для проверки, находится ли частица внутри радара
        private bool IsParticleInsideRadar(Particle particle)
        {
            // Вычисляем расстояние между центром радара и частицей
            float distanceToCenter = (float)Math.Sqrt(Math.Pow(X - particle.X, 2) + Math.Pow(Y - particle.Y, 2));

            // Частица находится внутри радара, если ее расстояние до центра меньше радиуса радара
            return distanceToCenter <= Radius;
        }
    }
}
