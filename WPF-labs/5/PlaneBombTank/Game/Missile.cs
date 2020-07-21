using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Game
{
    //конкретный объект - бомба
    class Missile : AbstractObject
    {
        private Movement move;

        public override void Init()
        {
            move = new Movement() { Step = 0.05, End = double.MaxValue };
            Image = BitmapFrame.Create(new Uri("images/missile.png", UriKind.RelativeOrAbsolute));
            IsEnabled = true;
            IsActive = true;
        }

        public override void Update()
        {
            if (IsActive)
            {
                Rect rect = GameObject;
                rect.X += 1;
                double y = move.Location;
                rect.Y -= y;
                GameObject = rect;
                string text = "Бомба стремительно мчится к земле: \n{0:F} м/c\nВот это скорость!";
                Info = string.Format(text, Math.Sqrt(1 + y * y) * 10);
            }
        }

    }

}
