using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Game
{
    //класс-котроллер за игровыми событиями
    public partial class GameWindow : UserControl
    {
        public static readonly DependencyProperty SelectedObjectInfoProperty =
                DependencyProperty.Register("SelectedObjectInfo", typeof(string),
                typeof(GameWindow), new UIPropertyMetadata(string.Empty));

        public GameWindow()
        {
            InitializeComponent();
            Context.Init();
        }

        public string SelectedObjectInfo
        {
            get 
            { 
                return (string)GetValue(SelectedObjectInfoProperty); 
            }
            set
            {
                SetValue(SelectedObjectInfoProperty, value);
            }
        }

        private void StartExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Context.Start();
        }

        private void StartCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !Context.IsStarted;
        }

        private void PauseExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Context.Pause();
        }

        private void PauseCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Context.IsStarted;
        }

        private void ResetExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Context.Init();
        }

        private void ResetCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void ActionExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Rect missileObject = Context.Missile.GameObject;
            missileObject.Location = Context.Plane.GameObject.Location;
            Context.Missile.GameObject = missileObject;
            Context.Missile.Init();
        }

        private void ActionCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Context.IsStarted && !Context.Missile.IsEnabled;
        }

        private void MouseLeftClick(object sender, MouseButtonEventArgs e)
        {
            object obj = (sender as FrameworkElement).DataContext;
            SetBinding(SelectedObjectInfoProperty, new Binding("Info") { Source = obj });
        }

    }

}
