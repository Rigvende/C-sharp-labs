using System;

namespace Labs3
{
    public interface IMove
    {
        string Name { get; set; }
        void Print();
        void Move(int speed);
    }
}