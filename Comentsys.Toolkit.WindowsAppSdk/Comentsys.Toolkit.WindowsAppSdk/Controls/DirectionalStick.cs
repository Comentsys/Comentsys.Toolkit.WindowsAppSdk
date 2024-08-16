namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Directional Stick
/// </summary>
public class DirectionalStick : Grid
{
    private bool _capture;
    private Ellipse? _knob;
    private Ellipse? _face;
    private double x = 0;
    private double y = 0;
    private double _m = 0;
    private double _res = 0;
    private double _width = 0;
    private double _height = 0;
    private double _alpha = 0;
    private double _alphaM = 0;
    private double _centreX = 0;
    private double _centreY = 0;
    private double _distance = 0;
    private double _oldAlphaM = -999.0;
    private double _oldDistance = -999.0;

    /// <summary>
    /// Value Changed Event
    /// </summary>
    public event EventHandler<DirectionalStickEventArgs>? ValueChanged;

    /// <summary>
    /// Foreground Dependency Property
    /// </summary>
    public static readonly DependencyProperty ForegroundProperty =
    DependencyProperty.Register(nameof(Foreground), typeof(Brush),
    typeof(DirectionalStick), new PropertyMetadata(new SolidColorBrush(Colors.Red)));

    /// <summary>
    /// Foreground
    /// </summary>
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }

    /// <summary>
    /// Fill Dependency Property
    /// </summary>
    public static readonly DependencyProperty FillProperty =
    DependencyProperty.Register(nameof(Fill), typeof(Brush),
    typeof(DirectionalStick), new PropertyMetadata(new SolidColorBrush(Colors.Black)));

    /// <summary>
    /// Fill
    /// </summary>
    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    /// <summary>
    /// Radius Dependency Property
    /// </summary>
    public static readonly DependencyProperty RadiusProperty =
    DependencyProperty.Register(nameof(Radius), typeof(int),
    typeof(DirectionalStick), new PropertyMetadata(100,
    new PropertyChangedCallback((obj, eventArgs) =>
    (obj as DirectionalStick)?.Load())));

    /// <summary>
    /// Radius
    /// </summary>
    public int Radius
    {
        get { return (int)GetValue(RadiusProperty); }
        set { SetValue(RadiusProperty, value); }
    }

    /// <summary>
    /// Angle Dependency Property
    /// </summary>
    public static readonly DependencyProperty AngleProperty =
    DependencyProperty.Register(nameof(Angle), typeof(double),
    typeof(DirectionalStick), null);

    /// <summary>
    /// Angle
    /// </summary>
    public double Angle
    {
        get { return (double)GetValue(AngleProperty); }
        set { SetValue(AngleProperty, value); }
    }

    /// <summary>
    /// Ratio Dependency Property
    /// </summary>
    public static readonly DependencyProperty RatioProperty =
    DependencyProperty.Register(nameof(Ratio), typeof(double),
    typeof(DirectionalStick), null);

    /// <summary>
    /// Ratio
    /// </summary>
    public double Ratio
    {
        get { return (double)GetValue(RatioProperty); }
        set { SetValue(RatioProperty, value); }
    }

    /// <summary>
    /// Sensitivity Dependency Property
    /// </summary>
    public static readonly DependencyProperty SensitivityProperty =
    DependencyProperty.Register(nameof(Sensitivity), typeof(double),
    typeof(DirectionalStick), null);

    /// <summary>
    /// Sensitivity
    /// </summary>
    public double Sensitivity
    {
        get { return (double)GetValue(SensitivityProperty); }
        set { SetValue(SensitivityProperty, value); }
    }

    /// <summary>
    /// To Radians
    /// </summary>
    /// <param name="angle">Angle</param>
    /// <returns>Radians</returns>
    private static double ToRadians(double angle) =>
        Math.PI * angle / 180.0;

    /// <summary>
    /// To Degrees
    /// </summary>
    /// <param name="angle">Angle</param>
    /// <returns>Degrees</returns>
    private static double ToDegrees(double angle) =>
        angle * (180.0 / Math.PI);

    /// <summary>
    /// Set Centre
    /// </summary>
    private void SetCentre()
    {
        _capture = false;
        Canvas.SetLeft(_knob, (Width - _width) / 2);
        Canvas.SetTop(_knob, (Height - _height) / 2);
        _centreX = Width / 2;
        _centreY = Height / 2;
    }

    /// <summary>
    /// Get Circle
    /// </summary>
    /// <param name="dimension">Dimension</param>
    /// <param name="path">Property Path</param>
    /// <returns>Ellipse</returns>
    private Ellipse GetCircle(double dimension, string path)
    {
        var circle = new Ellipse()
        {
            Height = dimension,
            Width = dimension
        };
        circle.SetBinding(Shape.FillProperty, new Microsoft.UI.Xaml.Data.Binding()
        {
            Source = this,
            Path = new PropertyPath(path),
            Mode = BindingMode.TwoWay
        });
        return circle;
    }

    /// <summary>
    /// Move
    /// </summary>
    /// <param name="e">Args</param>
    private void Move(PointerRoutedEventArgs e)
    {
        x = e.GetCurrentPoint(this).Position.X;
        y = e.GetCurrentPoint(this).Position.Y;
        _res = Math.Sqrt((x - _centreX) *
            (x - _centreX) + (y - _centreY) * (y - _centreY));
        _m = (y - _centreY) / (x - _centreX);
        _alpha = ToDegrees(Math.Atan(_m) + Math.PI / 2);
        if (x < _centreX)
            _alpha += 180.0;
        else if (x == _centreX && y <= _centreY)
            _alpha = 0.0;
        else if (x == _centreX)
            _alpha = 180.0;
        if (_res > Radius)
        {
            x = _centreX + Math.Cos(ToRadians(_alpha) - Math.PI / 2) * Radius;
            y = _centreY + Math.Sin(ToRadians(_alpha) - Math.PI / 2) * Radius
                * ((_alpha % 180.0 == 0.0) ? -1.0 : 1.0);
            _res = Radius;
        }
        if (Math.Abs(_alpha - _alphaM) >= Sensitivity ||
            Math.Abs(_distance * Radius - _res) >= Sensitivity)
        {
            _alphaM = _alpha;
            _distance = _res / Radius;
        }
        if (_oldAlphaM != _alphaM ||
            _oldDistance != _distance)
        {
            Angle = _alphaM;
            Ratio = _distance;
            _oldAlphaM = _alphaM;
            _oldDistance = _distance;
            ValueChanged?.Invoke(this, new DirectionalStickEventArgs(Angle, Ratio));
        }
        Canvas.SetLeft(_knob, x - _width / 2);
        Canvas.SetTop(_knob, y - _height / 2);
    }

    /// <summary>
    /// Set Capture
    /// </summary>
    private void SetCapture() => _capture = true;

    /// <summary>
    /// Check Capture
    /// </summary>
    /// <param name="e">Args</param>
    private void CheckCapture(PointerRoutedEventArgs e)
    {
        if (_capture)
            Move(e);
    }

    /// <summary>
    /// Layout
    /// </summary>
    private void Layout()
    {
        _knob = GetCircle(Radius, nameof(Foreground));
        _face = GetCircle(Radius * 2, nameof(Fill));
        _height = _knob.ActualHeight;
        _width = _knob.ActualWidth;
        Width = _width + Radius * 2;
        Height = _height + Radius * 2;
        SetCentre();
        PointerExited -= null;
        PointerExited += (object sender, PointerRoutedEventArgs e) => SetCentre();
        _knob.PointerReleased += (object sender, PointerRoutedEventArgs e) => SetCentre();
        _knob.PointerPressed += (object sender, PointerRoutedEventArgs e) => SetCapture();
        _knob.PointerMoved += (object sender, PointerRoutedEventArgs e) => CheckCapture(e);
        _knob.PointerExited += (object sender, PointerRoutedEventArgs e) => SetCentre();
    }

    /// <summary>
    /// Load
    /// </summary>
    internal void Load()
    {
        Layout();
        Children.Clear();
        Children.Add(_face);
        var canvas = new Canvas()
        {
            Width = Width,
            Height = Height
        };
        canvas.Children.Add(_knob);
        Children.Add(canvas);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public DirectionalStick() => Load();
}
