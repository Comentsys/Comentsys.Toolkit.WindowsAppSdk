namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Piece
/// </summary>
public class Piece : Grid
{
    private const int thickness = 10;

    internal Grid _grid;
    internal Shape? _shape;
    internal TextBlock? _text;

    /// <summary>
    /// Get Shape
    /// </summary>
    /// <param name="isSquare">Is Square?</param>
    /// <returns>Shape</returns>
    internal static Shape GetShape(bool isSquare) =>
        isSquare ?
        new Rectangle()
        {
            StrokeThickness = thickness
        }
        : new Ellipse()
        {
            StrokeThickness = thickness
        };

    /// <summary>
    /// Get Text Block
    /// </summary>
    /// <returns>Text Block</returns>
    internal static TextBlock GetTextBlock() =>
        new()
        {
            FontSize = 32,
            TextLineBounds = TextLineBounds.Tight,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center
        };

    /// <summary>
    /// Set Piece
    /// </summary>
    /// <param name="piece">Piece</param>
    /// <param name="isSquare">Is Square</param>
    internal static void SetPiece(Piece? piece, bool isSquare)
    {
        if (piece != null)
        {
            var fill = piece?._shape?.Fill;
            var stroke = piece?._shape?.Stroke;
            piece!._shape = GetShape(isSquare);
            piece!._shape.Fill = fill;
            piece!._shape.Stroke = stroke;
            piece!._grid.Children.Clear();
            piece!._grid.Children.Add(piece._shape);
            piece!._grid.Children.Add(piece._text);
        }
    }

    /// <summary>
    /// Set Stroke
    /// </summary>
    /// <param name="piece">Piece</param>
    /// <param name="brush">Brush</param>
    internal static void SetStroke(Piece? piece, Brush? brush)
    {
        if (piece?._shape != null)
            piece._shape.Stroke = brush;
    }

    /// <summary>
    /// Set Fill
    /// </summary>
    /// <param name="piece">Piece</param>
    /// <param name="brush">Brush</param>
    internal static void SetFill(Piece? piece, Brush? brush)
    {
        if (piece?._shape != null)
            piece._shape.Fill = brush;
    }

    /// <summary>
    /// Set Foreground
    /// </summary>
    /// <param name="piece">Piece</param>
    /// <param name="brush">Brush</param>
    internal static void SetForeground(Piece? piece, Brush? brush)
    {
        if (piece?._text != null)
            piece._text.Foreground = brush;
    }

    /// <summary>
    /// Set Text
    /// </summary>
    /// <param name="piece">Piece</param>
    /// <param name="text">Text</param>
    internal static void SetText(Piece? piece, string? text)
    {
        if (piece?._text != null)
            piece._text.Text = text;
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public Piece()
    {
        _grid = new()
        {
            Padding = new Thickness(5),
            Height = 100,
            Width = 100
        };
        _grid.RowDefinitions.Add(new RowDefinition());
        _grid.ColumnDefinitions.Add(new ColumnDefinition());
        _text = GetTextBlock();
        SetPiece(this, false);
        Viewbox viewbox = new()
        {
            Child = _grid
        };
        Children.Add(viewbox);
    }

    /// <summary>
    /// Stroke Dependency Property
    /// </summary>
    public static readonly DependencyProperty StrokeProperty =
    DependencyProperty.Register(nameof(Stroke), typeof(Brush),
    typeof(Piece), new PropertyMetadata(new SolidColorBrush(Colors.Blue),
    new PropertyChangedCallback((obj, eventArgs) =>
        SetStroke(obj as Piece, eventArgs.NewValue as Brush))));

    /// <summary>
    /// Piece Stroke
    /// </summary>
    public Brush Stroke
    {
        get => (Brush)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }

    /// <summary>
    /// Fill Dependency Property
    /// </summary>
    public static readonly DependencyProperty FillProperty =
    DependencyProperty.Register(nameof(Fill), typeof(Brush),
    typeof(Piece), new PropertyMetadata(new SolidColorBrush(Colors.Transparent),
    new PropertyChangedCallback((obj, eventArgs) =>
        SetFill(obj as Piece, eventArgs.NewValue as Brush))));

    /// <summary>
    /// Piece Fill
    /// </summary>
    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    /// <summary>
    /// Foreground Dependency Property
    /// </summary>
    public static readonly DependencyProperty ForegroundProperty =
    DependencyProperty.Register(nameof(Foreground), typeof(Brush),
    typeof(Piece), new PropertyMetadata(new SolidColorBrush(Colors.Transparent),
    new PropertyChangedCallback((obj, eventArgs) =>
        SetForeground(obj as Piece, eventArgs.NewValue as Brush))));

    /// <summary>
    /// Piece Foreground
    /// </summary>
    public Brush Foreground
    {
        get => (Brush)GetValue(ForegroundProperty);
        set => SetValue(ForegroundProperty, value);
    }

    /// <summary>
    /// Value Dependency Property
    /// </summary>
    public static readonly DependencyProperty ValueProperty =
    DependencyProperty.Register(nameof(Value), typeof(string),
    typeof(Piece), new PropertyMetadata(string.Empty,
    new PropertyChangedCallback((obj, eventArgs) =>
        SetText(obj as Piece, eventArgs.NewValue as string))));

    /// <summary>
    /// Piece Value
    /// </summary>
    public string Value
    {
        get => (string)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }

    /// <summary>
    /// Is Square Dependency Property
    /// </summary>
    private readonly DependencyProperty IsSquareProperty =
    DependencyProperty.Register(nameof(IsSquare), typeof(bool),
    typeof(Piece), new PropertyMetadata(false,
    new PropertyChangedCallback((obj, eventArgs) =>
        SetPiece(obj as Piece, (bool)eventArgs.NewValue))));

    /// <summary>
    /// Piece Is Square?
    /// </summary>
    public bool IsSquare
    {
        get => (bool)GetValue(IsSquareProperty);
        set => SetValue(IsSquareProperty, value);
    }
}
