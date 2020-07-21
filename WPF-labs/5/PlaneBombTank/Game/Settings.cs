using System.Windows.Input;

namespace Game
{
    class Settings
    {
        public static RoutedCommand Start { get; set; }
        public static RoutedCommand Pause { get; set; }
        public static RoutedCommand Reset { get; set; }
        public static RoutedCommand Action { get; set; }

        static Settings()
        {
            Start = new RoutedCommand("Start", typeof(GameWindow));
            Pause = new RoutedCommand("Pause", typeof(GameWindow));
            Reset = new RoutedCommand("Reset", typeof(GameWindow));
            Action = new RoutedCommand("Action", typeof(GameWindow));
        }

    }

}
