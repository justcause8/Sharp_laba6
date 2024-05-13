using System;
using System.Collections.Generic;
using System.Drawing;

namespace laba6
{
    public class Emitter
    {
        // Список частиц, создаваемых эмиттером
        List<Particle> particles = new List<Particle>();
        // Список объектов воздействия (гравитационные точки, радар и т. д.)
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        // Переменные для хранения позиции мыши и параметров гравитации
        public int MousePositionX = 0;
        public int MousePositionY = 0;
        public float GravitationX = 0;
        public float GravitationY = 1;

        // Параметры генерации частиц
        public int ParticlesCount = 200;
        public int X;
        public int Y;
        public int Direction = 0;
        public int Spreading = 360;
        public int SpeedMin = 1;
        public int SpeedMax = 10;
        public int RadiusMin = 2;
        public int RadiusMax = 10;
        public int LifeMin = 20;
        public int LifeMax = 100;
        public int ParticlesPerTick = 1;

        // Цвет частицы (начальный и конечный для градиента)
        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);

        // Метод для сброса параметров частицы при пересоздании
        public virtual void ResetParticle(Particle particle)
        {
            // Устанавливаем случайную продолжительность жизни частицы
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            // Устанавливаем позицию частицы на эмиттере
            particle.X = X;
            particle.Y = Y;

            // Устанавливаем случайное направление движения частицы и скорость
            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            // Вычисляем компоненты скорости по осям X и Y
            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            // Устанавливаем случайный радиус частицы
            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

            // Устанавливаем начальный и конечный цвет для частицы (для частиц с цветовым градиентом)
            if (particle is ParticleColorful colorfulParticle)
            {
                colorfulParticle.FromColor = ColorFrom;
                colorfulParticle.ToColor = ColorTo;
            }
        }

        // Метод для создания новой частицы
        public virtual Particle CreateParticle()
        {
            // Создаем новый экземпляр частицы
            var particle = new ParticleColorful();
            // Устанавливаем начальный и конечный цвет для частицы (для частиц с цветовым градиентом)
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        // Метод для обновления состояния частиц (перемещение, воздействие гравитации и т. д.)
        public void UpdateState()
        {
            // Количество частиц, которые нужно создать в текущем обновлении
            int particlesToCreate = ParticlesPerTick;

            // Обходим все частицы в списке
            foreach (var particle in particles)
            {
                // Если жизнь частицы истекла
                if (particle.Life <= 0)
                {
                    // Перезапускаем частицу
                    ResetParticle(particle);
                    // Если есть еще несозданные частицы на этом обновлении, создаем еще одну
                    if (particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {
                    // Обновляем позицию частицы и ее параметры
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;

                    // Применяем воздействие гравитационных точек к частице
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    // Применяем гравитацию к частице
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            // Создаем новые частицы, если они нужны
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        // Метод для отрисовки частиц и объектов воздействия
        public void Render(Graphics g)
        {
            // Отрисовываем все частицы
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            // Отрисовываем все объекты воздействия (гравитационные точки, радар и т. д.)
            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        // Метод для получения общего количества активных частиц
        public int GetTotalParticlesCount()
        {
            // Возвращаем количество частиц, у которых осталась жизнь
            return particles.Count(p => p.Life > 0);
        }
    }
}