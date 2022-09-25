namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Dice
/// </summary>
public class Dice : Grid
{
    private const int size = 3;

    private static readonly byte[][] _dice =
    {           
                  // a, b, c, d, e, f, g, h, i
        new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 0
        new byte[] { 0, 0, 0, 0, 1, 0, 0, 0, 0 }, // 1
        new byte[] { 1, 0, 0, 0, 0, 0, 0, 0, 1 }, // 2
        new byte[] { 1, 0, 0, 0, 1, 0, 0, 0, 1 }, // 3
        new byte[] { 1, 0, 1, 0, 0, 0, 1, 0, 1 }, // 4
        new byte[] { 1, 0, 1, 0, 1, 0, 1, 0, 1 }, // 5
        new byte[] { 1, 0, 1, 1, 0, 1, 1, 0, 1 }, // 6
    };

    internal Grid _grid;

    /// <summary>
    /// Set Pip Fill
    /// </summary>
    /// <param name="brush">Brush</param>
    internal void SetPipFill(Brush? brush)
    {
        foreach (var dot in _grid.Children.Cast<Ellipse>())
            dot.Fill = brush ?? new SolidColorBrush(Colors.Black);
    }

    /// <summary>
    /// Set Pip
    /// </summary>
    /// <param name="value">Value</param>
    internal void SetPip(int? value)
    {
        int count = 0;
        var index = value.HasValue && value.Value < _dice.GetLength(0) ? value.Value : 0;
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                var element = _grid.Children.Cast<FrameworkElement>()
                .FirstOrDefault(f => GetRow(f) == row && GetColumn(f) == column);
                if (element != null)
                    element.Opacity = _dice[index][count++];
            }
        }
    }

    /// <summary>
    /// Add Pip
    /// </summary>
    /// <param name="row">Row</param>
    /// <param name="column">Column</param>
    private void AddPip(int row, int column)
    {
        Ellipse element = new()
        {
            Opacity = 0,
            Margin = new Thickness(5)
        };
        element.SetValue(ColumnProperty, column);
        element.SetValue(RowProperty, row);
        _grid.Children.Add(element);
    }

    /// <summary>
    /// Dice
    /// </summary>
    public Dice()
    {
        _grid = new Grid()
        {
            Width = 100,
            Height = 100,
            Padding = new Thickness(5)
        };
        for (int row = 0; row < size; row++)
        {
            _grid.RowDefinitions.Add(new RowDefinition());
            for (int column = 0; column < size; column++)
            {
                if (row == 0)
                    _grid.ColumnDefinitions.Add(new ColumnDefinition());
                AddPip(row, column);
            }
        }
        SetPip(Value);
        Viewbox viewbox = new()
        {
            Child = _grid
        };
        Children.Add(viewbox);
    }

    /// <summary>
    /// Dice Foreground Dependency Property
    /// </summary>
    public static readonly DependencyProperty ForegroundProperty =
    DependencyProperty.Register(nameof(Foreground), typeof(Brush),
    typeof(Dice), new PropertyMetadata(new SolidColorBrush(Colors.Black),
    new PropertyChangedCallback((obj, eventArgs) =>
    (obj as Dice)?.SetPipFill(eventArgs.NewValue as Brush))));

    /// <summary>
    /// Dice Foreground
    /// </summary>
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }

    /// <summary>
    /// Dice Value Dependency Property
    /// </summary>
    public static readonly DependencyProperty ValueProperty =
    DependencyProperty.Register(nameof(Value), typeof(int),
    typeof(Dice), new PropertyMetadata(0,
    new PropertyChangedCallback((obj, eventArgs) =>
    (obj as Dice)?.SetPip(eventArgs.NewValue as int?))));

    /// <summary>
    /// Dice Value
    /// </summary>
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}
