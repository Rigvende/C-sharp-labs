using System;
using System.Windows;

namespace Game
{
    //конкретный объект - самолет
    class Plane : AbstractObject
    {
        private Movement move;

        public override void Init()
        {
            Rect rect = GameObject;
            rect.Location = new Point(-200, 550);
            GameObject = rect;
            move = new Movement { Start = -200, Step = 1, End = 1280 };
            IsEnabled = true;
        }

        public override void Update()
        {
            Rect rect = GameObject;
            rect.X = Math.Round(move.Location);
            GameObject = rect;
            Info = string.Format("Сокол, это Ласточка. Приём! \nМои координаты: {0}", GameObject.Location);
        }

    }

}
