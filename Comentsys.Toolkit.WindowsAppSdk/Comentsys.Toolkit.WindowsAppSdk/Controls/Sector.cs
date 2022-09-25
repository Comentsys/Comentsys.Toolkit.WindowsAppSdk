namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Sector
/// </summary>
public class Sector : Path
{
    /// <summary>
    /// Get Point
    /// </summary>
    /// <param name="angle">Angle</param>
    /// <param name="value">Value</param>
    /// <param name="radius">Radius</param>
    /// <returns>Point</returns>
    private static Point GetPoint(double angle, double value, double radius)
    {
        double radians = Math.PI / 180 * (angle - 90);
        double x = value * Math.Cos(radians);
        double y = value * Math.Sin(radians);
        return new Point(x += radius, y += radius);
    }

    /// <summary>
    /// Get Path Geometry
    /// </summary>
    /// <param name="start">Start</param>
    /// <param name="finish">Finish</param>
    /// <param name="radius">Radius</param>
    /// <param name="hole">Hole</param>
    /// <returns>Path Geometry</returns>
    private static PathGeometry GetPathGeometry(double start, double finish, double radius, double hole)
    {
        bool isLargeArc = finish > 180.0;
        Point innerArcStart = GetPoint(start, hole, radius);
        Point outerArcStart = GetPoint(start, radius, radius);
        Point innerArcEnd = GetPoint(start + finish, hole, radius);
        Point outerArcEnd = GetPoint(start + finish, radius, radius);
        Size outerArcSize = new(radius, radius);
        Size innerArcSize = new(hole, hole);
        LineSegment lineOne = new()
        {
            Point = outerArcStart
        };
        ArcSegment arcOne = new()
        {
            SweepDirection = SweepDirection.Clockwise,
            IsLargeArc = isLargeArc,
            Point = outerArcEnd,
            Size = outerArcSize
        };
        LineSegment lineTwo = new()
        {
            Point = innerArcEnd
        };
        ArcSegment arcTwo = new()
        {
            SweepDirection = SweepDirection.Counterclockwise,
            IsLargeArc = isLargeArc,
            Point = innerArcStart,
            Size = innerArcSize
        };
        PathFigure figure = new()
        {
            StartPoint = innerArcStart,
            IsClosed = true,
            IsFilled = true
        };
        figure.Segments.Add(lineOne);
        figure.Segments.Add(arcOne);
        figure.Segments.Add(lineTwo);
        figure.Segments.Add(arcTwo);
        PathGeometry pathGeometry = new();
        pathGeometry.Figures.Add(figure);
        return pathGeometry;
    }

    /// <summary>
    /// Set
    /// </summary>
    /// <param name="start">Start</param>
    /// <param name="finish">Finish</param>
    /// <param name="radius">Radius</param>
    /// <param name="hole">Hole</param>
    internal void SetSector(double start, double finish, double radius, double hole) => 
        Data = GetPathGeometry(start, finish, radius, hole);

    /// <summary>
    /// Start Property
    /// </summary>
    private readonly DependencyProperty StartProperty =
    DependencyProperty.Register(nameof(Start), typeof(double),
    typeof(Sector), new PropertyMetadata(0.0,
    new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs eventArgs) =>
    {
        var sector = (Sector)obj;
        sector.SetSector((double)eventArgs.NewValue, sector.Finish, sector.Radius, sector.Hole);
    })));

    /// <summary>
    /// Sector Start
    /// </summary>
    public double Start
    {
        get => (double)GetValue(StartProperty);
        set => SetValue(StartProperty, value);
    }

    /// <summary>
    /// Finish Property
    /// </summary>
    private readonly DependencyProperty FinishProperty =
    DependencyProperty.Register(nameof(Finish), typeof(double),
    typeof(Sector), new PropertyMetadata(0.0,
    new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs eventArgs) =>
    {
        var sector = (Sector)obj;
        sector.SetSector(sector.Start, (double)eventArgs.NewValue, sector.Radius, sector.Hole);
    })));

    /// <summary>
    /// Sector Finish
    /// </summary>
    public double Finish
    {
        get => (double)GetValue(FinishProperty);
        set => SetValue(FinishProperty, value);
    }

    /// <summary>
    /// Radius Property
    /// </summary>
    private readonly DependencyProperty RadiusProperty =
    DependencyProperty.Register(nameof(Radius), typeof(double),
    typeof(Sector), new PropertyMetadata(0.0,
    new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs eventArgs) =>
    {
        var sector = (Sector)obj;
        sector.SetSector(sector.Start, sector.Finish, (double)eventArgs.NewValue, sector.Hole);
    })));

    /// <summary>
    /// Sector Radius
    /// </summary>
    public double Radius
    {
        get => (double)GetValue(RadiusProperty);
        set => SetValue(RadiusProperty, value);
    }

    /// <summary>
    /// Hole Property
    /// </summary>
    private readonly DependencyProperty HoleProperty =
    DependencyProperty.Register(nameof(Hole), typeof(double),
    typeof(Sector), new PropertyMetadata(0.0,
    new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs eventArgs) =>
    {
        var sector = (Sector)obj;
        sector.SetSector(sector.Start, sector.Finish, sector.Radius, (double)eventArgs.NewValue);
    })));

    /// <summary>
    /// Sector Hole
    /// </summary>
    public double Hole
    {
        get => (double)GetValue(HoleProperty);
        set => SetValue(HoleProperty, value);
    }
}
