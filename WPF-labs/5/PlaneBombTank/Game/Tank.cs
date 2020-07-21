using System;
using System.Windows.Media.Imaging;

namespace Game
{
    //конкретный объект - неподвижный танк
    class Tank : AbstractObject
    {
        public override void Init()
        {
            IsEnabled = true;
            Image = BitmapFrame.Create(new Uri("images/tank.png", UriKind.RelativeOrAbsolute));
        }

    }

}
 