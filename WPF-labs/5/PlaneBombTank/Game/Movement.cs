namespace Game
{
    //класс хранит данные о перемещении объекта
    class Movement
    {
        private double _location;
        public double Start { get; set; }
        public double End { get; set; }
        public double Step { get; set; }

        public Movement()
        {
            Step = 1;
            End = double.MaxValue;
        }

        public double Location
        {
            get
            {               
                double state = _location;
                _location += Step;
                if (state >= End)
                {
                    state = _location = Start;
                }
                return state;
            }
            set
            {
                _location = value;
            }
        }

    }

}
