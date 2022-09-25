namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Card
/// </summary>
public class Card : Grid
{
    private const int suit = 13;
    private const int maximum = 52;
    private const string club = @"M 19.5155,51.3 C 17.1155,50.1 15.9155,43.7 
        21.5155,43.7 C 27.1155,43.7 25.9155,50.1 23.5155,51.3 C 25.1155,50.1 
        30.3155,48.5 30.3155,54.1 C 30.3155,59.7 23.1155,59.3 22.7155,54.9 L 
        21.9155,54.9 C 21.9155,54.9 22.3155,59.3 23.5155,61.3 L 19.5155,61.3 C 
        20.7155,59.3 21.1155,54.9 21.1155,54.9 L 20.3155,54.9 C 19.9155,59.3 
        12.3155,59.7 12.3155,54.1 C 12.3155,49.3 17.9155,50.1 19.5155,51.3 z";
    private const string diamond = @"M 170.1155,199.8 L 177.3155,191 L 184.5155,199.4 
        L 177.3155,209 L 170.1155,199.8 z";
    private const string heart = @"M 99.5,99.75 C 99.5,93.75 89.5,81.75 79.5,81.75 C 
        69.5,81.75 59.5,89.75 59.5,103.75 C 59.5,125.75 91.5,161.75 99.5,171.75 C 
        107.5,161.75 139.5,125.75 139.5,103.75 C 139.5,89.75 129.5,81.75 119.5,81.75 C 
        109.45012,81.75 99.5,93.75 99.5,99.75 z";
    private const string spade = @"M 21.1155,43.3 C 17.9155,48.1 13.7155,50.9 13.7155,54.9 
        C 13.7155,58.5 15.7155,59.3 16.9155,59.3 C 18.5155,59.3 19.7155,58.5 19.7155,55.7 
        C 19.7155,54.9 20.5155,54.9 20.5155,55.7 C 20.5155,59.7 19.7155,59.7 18.9155,61.7 
        L 23.3155,61.7 C 22.5155,59.7 21.7155,59.7 21.7155,55.7 C 21.7155,54.9 22.5155,54.9 
        22.5155,55.7 C 22.5155,58.9 23.7155,59.3 25.3155,59.3 C 26.5155,59.3 28.9155,58.5 
        28.9155,54.9 C 28.9155,50.84784 24.3155,48.1 21.1155,43.3 z";

    private static readonly string[] _pips = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r" };
    private static readonly string[] _values = { "", "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
    private static readonly string[] _items = { "topleft", "bottomleft", "bottomright", "topright" };
    private static readonly int[][] _table =
    {
        //          a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 0
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // 1
        new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, // 2
        new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 }, // 3
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 }, // 4
        new int[] { 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0 }, // 5
        new int[] { 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0 }, // 6
        new int[] { 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 0 }, // 7
        new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0 }, // 8
        new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 1, 0 }, // 9
        new int[] { 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0 }, // 10
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // 11
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // 12
        new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 }, // 13
    };

    internal Grid _grid;

    /// <summary>
    /// Get Geometry
    /// </summary>
    /// <param name="data">Data</param>
    /// <returns>Geometry</returns>
    private static Geometry GetGeometry(string data) =>
        (Geometry)XamlReader.Load(
        $"<Geometry xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'>{data}</Geometry>");

    /// <summary>
    /// Get Pip
    /// </summary>
    /// <param name="symbol">Symbol</param>
    /// <param name="color">Colour</param>
    /// <param name="height">Height</param>
    /// <param name="margin">Margin</param>
    /// <param name="name">Name</param>
    /// <returns>Path</returns>
    private static Path GetPip(string symbol, Color color, double height, int margin, string name) =>
        new()
        {
            Opacity = 0,
            Height = height,
            Name = $"{name}.pip",
            Stretch = Stretch.Uniform,
            Data = GetGeometry(symbol),
            Margin = new Thickness(margin),
            Fill = new SolidColorBrush(color)
        };

    /// <summary>
    /// Get Num
    /// </summary>
    /// <param name="color">Colour</param>
    /// <param name="value">Value</param>
    /// <param name="size">Size</param>
    /// <param name="name">Name</param>
    /// <returns>Text Block</returns>
    private static TextBlock GetNum(Color color, string value, int size, string name) =>
        new()
        {
            HorizontalAlignment = HorizontalAlignment.Center,
            Foreground = new SolidColorBrush(color),
            Name = $"{name}.num",
            FontSize = size,
            Text = value,
            Opacity = 0
        };

    /// <summary>
    /// Add Pip
    /// </summary>
    /// <param name="grid">Grid</param>
    /// <param name="row">Row</param>
    /// <param name="rowspan">Row Span</param>
    /// <param name="column">Column</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="color">Colour</param>
    /// <param name="name">Name</param>
    private static void AddPip(Grid grid, int row, int rowspan, int column, string symbol,
        Color color, string name)
    {
        bool flip = row > 2;
        Path pip = GetPip(symbol, color, 100, 5, name);
        if (flip)
        {
            pip.RenderTransform = new ScaleTransform()
            {
                ScaleY = -1,
                CenterY = 50
            };
        }
        pip.SetValue(RowProperty, row);
        pip.SetValue(RowSpanProperty, rowspan);
        pip.SetValue(ColumnProperty, column);
        grid.Children.Add(pip);
    }

    /// <summary>
    /// Add Item
    /// </summary>
    /// <param name="grid">Grid</param>
    /// <param name="row">Row</param>
    /// <param name="column">Column</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="color">Colour</param>
    /// <param name="value">Value</param>
    /// <param name="flip">Flip</param>
    /// <param name="name">Name</param>
    private static void AddItem(Grid grid, int row, int column, string symbol,
        Color color, string value, bool flip, string name)
    {
        StackPanel item = new()
        {
            Name = name,
        };
        Path pip = GetPip(symbol, color, 40, 0, name);
        if (flip)
        {
            pip.RenderTransform = new ScaleTransform()
            {
                ScaleY = -1,
                CenterY = 20
            };
        }
        item.Children.Add(pip);
        item.Children.Add(GetNum(color, value, 40, name));
        item.SetValue(ColumnProperty, column);
        item.SetValue(RowProperty, row);
        grid.Children.Add(item);
    }

    /// <summary>
    /// Add Face
    /// </summary>
    /// <param name="grid">Grid</param>
    /// <param name="row">Row</param>
    /// <param name="rowspan">Row Span</param>
    /// <param name="column">Column</param>
    /// <param name="colspan">Column Span</param>
    /// <param name="color">Colour</param>
    /// <param name="value">Value</param>
    /// <param name="name">Name</param>
    private static void AddFace(Grid grid, int row, int rowspan, int column, int colspan,
        Color color, string value, string name)
    {
        var face = GetNum(color, value, 300, name);
        face.SetValue(RowProperty, row);
        face.SetValue(RowSpanProperty, rowspan);
        face.SetValue(ColumnProperty, column);
        face.SetValue(ColumnSpanProperty, colspan);
        grid.Children.Add(face);
    }

    /// <summary>
    /// Set Pip
    /// </summary>
    /// <param name="panel">Panel</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="color">Colour</param>
    /// <param name="name">Name</param>
    /// <param name="opacity">Opacity</param>
    private static void SetPip(Panel panel, string symbol,
        Color color, string name, int opacity)
    {
        var pip = panel.Children.Cast<FrameworkElement>()
        .FirstOrDefault(item => item.Name == $"{name}.pip") as Path;
        if (pip != null)
        {
            pip.Fill = new SolidColorBrush(color);
            pip.Data = GetGeometry(symbol);
            pip.Opacity = opacity;
        }
    }

    /// <summary>
    /// Set Num
    /// </summary>
    /// <param name="panel">Panel</param>
    /// <param name="color">Colour</param>
    /// <param name="value">Value</param>
    /// <param name="name">Name</param>
    /// <param name="opacity">Opacity</param>
    private static void SetNum(Panel panel,
        Color color, string value, string name, int opacity)
    {
        var num = panel.Children.Cast<FrameworkElement>()
        .FirstOrDefault(item => item.Name == $"{name}.num") as TextBlock;
        if (num != null)
        {
            num.Foreground = new SolidColorBrush(color);
            num.Opacity = opacity;
            num.Text = value;
        }
    }

    /// <summary>
    /// Set Item
    /// </summary>
    /// <param name="panel">Panel</param>
    /// <param name="symbol">Symbol</param>
    /// <param name="color">Colour</param>
    /// <param name="value">Value</param>
    /// <param name="name">Name</param>
    /// <param name="opacity">Opacity</param>
    private static void SetItem(Panel panel, string symbol, Color color, string value, string name, int opacity)
    {
        var item = panel.Children.Cast<FrameworkElement>()
        .FirstOrDefault(item => item.Name == name) as Panel;
        if (item != null)
        {
            SetPip(item, symbol, color, name, opacity);
            SetNum(item, color, value, name, opacity);
        }
    }

    /// <summary>
    /// Set Back
    /// </summary>
    /// <param name="brush">Brush</param>
    internal void SetBack(Brush? brush) =>
        _grid.Background = Value < 1 || Value > maximum ? brush ??
            new SolidColorBrush(Colors.White) :
            new SolidColorBrush(Colors.White);

    /// <summary>
    /// Set Card
    /// </summary>
    /// <param name="value">Value</param>
    internal void SetCard(int? value)
    {
        int index = value ?? 0;
        index = index > maximum ? 0 : index;
        int mod = index % suit;
        int total = _pips.Length - 1;
        int number = value > 0 && mod == 0 ? suit : mod;
        var symbol = value switch
        {
            int when value is > 0 and <= 13 => club,
            int when value is > 13 and <= 26 => diamond,
            int when value is > 26 and <= 39 => heart,
            int when value is > 39 and <= 52 => spade,
            _ => club
        };
        var color = symbol == heart || symbol == diamond ? Colors.Red : Colors.Black;
        foreach (var item in _items)
        {
            SetItem(_grid, symbol, color, _values[number], item, number > 0 ? 1 : 0);
        }
        for (int pip = 0; pip < total; pip++)
        {
            SetPip(_grid, symbol, color, _pips[pip], _table[number][pip]);
        }
        SetNum(_grid, color, _values[number], _pips[total], _table[number][total]);
        SetBack(Back);
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public Card()
    {
        string suit = club;
        var color = Colors.Black;
        var value = string.Empty;
        _grid = new()
        {
            BorderBrush = new SolidColorBrush(color),
            Padding = new Thickness(10, 20, 10, 10),
            CornerRadius = new CornerRadius(10),
            BorderThickness = new Thickness(5),
            Margin = new Thickness(10)
        };
        for (int column = 0; column < 5; column++)
        {
            _grid.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(80)
            });
        }
        for (int row = 0; row < 6; row++)
        {
            _grid.RowDefinitions.Add(new RowDefinition()
            {
                Height = new GridLength(100)
            });
        }
        AddItem(_grid, 0, 0, suit, color, value, false, _items[0]);
        AddItem(_grid, 6, 0, suit, color, value, true, _items[1]);
        AddItem(_grid, 6, 4, suit, color, value, true, _items[2]);
        AddItem(_grid, 0, 4, suit, color, value, false, _items[3]);
        int count = 0;
        for (int i = 1; i < 5; i++)
        {
            AddPip(_grid, i, 1, 1, suit, color, _pips[count]);
            count++;
        }
        AddPip(_grid, 2, 2, 1, suit, color, _pips[count]);
        count++;
        for (int i = 1; i < 5; i++)
        {
            AddPip(_grid, i, 1, 2, suit, color, _pips[count]);
            count++;
        }
        for (int i = 1; i < 4; i++)
        {
            AddPip(_grid, i, 2, 2, suit, color, _pips[count]);
            count++;
        }
        AddPip(_grid, 2, 2, 3, suit, color, _pips[count]);
        count++;
        for (int i = 1; i < 5; i++)
        {
            AddPip(_grid, i, 1, 3, suit, color, _pips[count]);
            count++;
        }
        AddFace(_grid, 1, 4, 1, 3, color, value, _pips[count]);
        Viewbox viewbox = new()
        {
            Child = _grid
        };
        Children.Add(viewbox);
    }

    /// <summary>
    /// Back Dependency Property
    /// </summary>
    public static readonly DependencyProperty BackProperty =
    DependencyProperty.Register(nameof(Back), typeof(Brush),
    typeof(Card), new PropertyMetadata(new SolidColorBrush(Colors.Blue),
    new PropertyChangedCallback((obj, eventArgs) =>
        (obj as Card)?.SetBack(eventArgs.NewValue as Brush))));

    /// <summary>
    /// Card Back
    /// </summary>
    public Brush Back
    {
        get => (Brush)GetValue(BackProperty);
        set => SetValue(BackProperty, value);
    }

    /// <summary>
    /// Value Dependency Property
    /// </summary>
    public static readonly DependencyProperty ValueProperty =
    DependencyProperty.Register(nameof(Value), typeof(int),
    typeof(Card), new PropertyMetadata(0,
    new PropertyChangedCallback((obj, eventArgs) =>
        (obj as Card)?.SetCard(eventArgs.NewValue as int?))));

    /// <summary>
    /// Card Value
    /// </summary>
    public int Value
    {
        get => (int)GetValue(ValueProperty);
        set => SetValue(ValueProperty, value);
    }
}