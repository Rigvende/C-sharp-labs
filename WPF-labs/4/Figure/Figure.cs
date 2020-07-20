using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Collections.ObjectModel;


namespace Figure
{
    class Figure : Panel
    {
        public Path path;
        public double X;
        public double Y;
        public Brush fon;
        public Brush line;
        public double width;

        public Figure() : this(0, 0, null, null, 0) { }

        public Figure(double X, double Y, Brush fon, Brush line, double width)
        {
            this.X = X;
            this.Y = Y;
            this.fon = fon;
            this.line = line;
            this.width = width;
            DrawFigure();
        }

        public void DrawFigure()
        {
            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(X, Y)
            };
            PathSegmentCollection collection = new PathSegmentCollection();
            ObservableCollection<Point> points = new ObservableCollection<Point>() 
            { 
                new Point(X + 100, Y), 
                new Point(X + 80, Y + 70), 
                new Point(X + 20, Y + 70), 
                new Point(X, Y) 
            };
            PolyLineSegment line = new PolyLineSegment(points, true);
            collection.Add(line);
            pathFigure.Segments = collection;
            PathFigureCollection figureCollection = new PathFigureCollection
            {
                pathFigure
            };
            PathGeometry geometry = new PathGeometry
            {
                Figures = figureCollection
            };
            path = new Path
            {
                Stroke = this.line,
                StrokeThickness = width,
                Data = geometry,
                Fill = fon
            };
        }

    }
}
