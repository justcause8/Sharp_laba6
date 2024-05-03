using System.Drawing;

namespace laba6
{
    public class Circle
    {
        private int value;
        private Point point;

        public Point Center { get; set; } // Центр круга
        public int Radius { get; set; }    // Радиус круга

        public Circle(Point center, int radius)
        {
            Center = center;
            Radius = radius;
        }

        public Circle(int value, Point point)
        {
            this.value = value;
            this.point = point;
        }

        public void Draw(Graphics g)
        {
            // Рисуем круг с учетом текущего радиуса и центра
            g.DrawEllipse(Pens.White, Center.X - Radius, Center.Y - Radius, 2 * Radius, 2 * Radius);
        }

        public void UpdateRadius(int newRadius)
        {
            Radius = newRadius;
        }
    }
}
