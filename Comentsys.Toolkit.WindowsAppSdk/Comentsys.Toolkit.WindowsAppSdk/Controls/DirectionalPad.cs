namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Directional Pad
/// </summary>
public class DirectionalPad : Grid
{
    private const int size = 3;
    private const string path_up = "M 0,0 40,0 40,60 20,80 0,60 0,0 z";
    private const string path_down = "M 0,20 20,0 40,20 40,80 0,80 z";
    private const string path_left = "M 0,0 60,0 80,20 60,40 0,40 z";
    private const string path_right = "M 0,20 20,0 80,0 80,40 20,40 z";

    internal Grid _grid;

    /// <summary>
    /// Value Changed Event
    /// </summary>
    public event EventHandler<DirectionalPadEventArgs>? ValueChanged;

    /// <summary>
    /// Foreground Dependency Property
    /// </summary>
    public static readonly DependencyProperty ForegroundProperty =
    DependencyProperty.Register(nameof(Foreground), typeof(Brush),
    typeof(DirectionalPad), null);

    /// <summary>
    /// Foreground
    /// </summary>
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }

    /// <summary>
    /// Direction Dependency Property
    /// </summary>
    public static readonly DependencyProperty DirectionProperty =
    DependencyProperty.Register(nameof(Direction), typeof(DirectionalPadDirection),
    typeof(DirectionalPad), null);

    /// <summary>
    /// Direction
    /// </summary>
    public DirectionalPadDirection Direction
    {
        get => (DirectionalPadDirection)GetValue(DirectionProperty);
        set => SetValue(DirectionProperty, value);
    }

    /// <summary>
    /// Get Path
    /// </summary>
    /// <param name="value">Path Data</param>
    /// <returns>Path</returns>
    private static Path GetPath(string value) => (Path)XamlReader.Load(
        $"<Path xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Path.Data>{value}</Path.Data></Path>");

    /// <summary>
    /// Get Direction
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Arguments</param>
    private void GetDirection(object sender, PointerRoutedEventArgs e)
    {
        var path = (Path)sender;
        var point = e.GetCurrentPoint(this);
        var fire = e.Pointer.PointerDeviceType == PointerDeviceType.Mouse ? 
            point.Properties.IsLeftButtonPressed : point.IsInContact;
        if (fire)
        {
            Direction = (DirectionalPadDirection)Enum.Parse(typeof(DirectionalPadDirection), path.Name);
            ValueChanged?.Invoke(path, new DirectionalPadEventArgs(Direction));
        }
    }

    /// <summary>
    /// Add
    /// </summary>
    /// <param name="grid">Grid</param>
    /// <param name="direction">Direction</param>
    /// <param name="data">Data</param>
    /// <param name="row">Row</param>
    /// <param name="column">Column</param>
    /// <param name="rowspan">Row Span</param>
    /// <param name="columnspan">Column Span</param>
    /// <param name="vertical">Vertical</param>
    /// <param name="horizontal">Horizontal</param>
    private void Add(Grid grid, DirectionalPadDirection direction, string data, 
        int row, int column, int? rowspan, int? columnspan, 
        VerticalAlignment? vertical = null, 
        HorizontalAlignment? horizontal = null)
    {
        var path = GetPath(data);
        path.Margin = new Thickness(5);
        path.Name = direction.ToString();
        if (vertical != null)
            path.VerticalAlignment = vertical.Value;
        if (horizontal != null)
            path.HorizontalAlignment = horizontal.Value;
        path.SetBinding(Shape.FillProperty, new Microsoft.UI.Xaml.Data.Binding()
        {
            Path = new PropertyPath(nameof(Foreground)),
            Mode = BindingMode.TwoWay,
            Source = this
        });
        path.PointerPressed += GetDirection;
        path.PointerMoved += GetDirection;
        path.SetValue(RowProperty, row);
        path.SetValue(ColumnProperty, column);
        if (rowspan != null)
            path.SetValue(RowSpanProperty, rowspan);
        if (columnspan != null)
            path.SetValue(ColumnSpanProperty, columnspan);
        grid.Children.Add(path);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public DirectionalPad()
    {
        _grid = new Grid()
        {
            Height = 180,
            Width = 180
        };
        _grid.Children.Clear();
        _grid.ColumnDefinitions.Clear();
        _grid.RowDefinitions.Clear();
        for (int index = 0; index < size; index++)
        {
            _grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = (index == 1) ? GridLength.Auto : new GridLength(100, GridUnitType.Star)
            });
            _grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = (index == 1) ? GridLength.Auto : new GridLength(100, GridUnitType.Star)
            });
        }
        Add(_grid, DirectionalPadDirection.Up, path_up, 0, 1, 2, null,
            VerticalAlignment.Top, null);
        Add(_grid, DirectionalPadDirection.Down, path_down, 1, 1, 2, null,
            VerticalAlignment.Bottom, null);
        Add(_grid, DirectionalPadDirection.Left, path_left, 1, 0, null, 2, null,
            HorizontalAlignment.Left);
        Add(_grid, DirectionalPadDirection.Right, path_right, 1, 1, null, 2, null,
            HorizontalAlignment.Right);
        var viewbox = new Viewbox()
        {
            Child = _grid
        };
        Children.Add(viewbox);
    }
}
