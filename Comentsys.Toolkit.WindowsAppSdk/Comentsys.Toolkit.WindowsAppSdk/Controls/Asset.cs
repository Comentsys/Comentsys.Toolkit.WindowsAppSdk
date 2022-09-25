namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Asset
/// </summary>
public class Asset : ContentControl
{
    private const int default_size = 32;

    internal Image _image;

    /// <summary>
    /// Set Asset Resource
    /// </summary>
    /// <param name="asset">Asset</param>
    /// <param name="assetResource">Asset Resource</param>
    private static async void SetAssetResource(Asset? asset, AssetResource? assetResource)
    {
        if(asset != null && assetResource != null)
        {
            asset._image.Height = assetResource.Height;
            asset._image.Width = assetResource.Width;
            asset._image.Source = await assetResource.AsImageSourceAsync();
        }
    }

    /// <summary>
    /// Constructor
    /// </summary>
    public Asset()
    {
        _image = new()
        {  
            Height = default_size,
            Width = default_size
        };
        Viewbox output = new()
        {
            Child = _image
        };
        Content = output;
    }

    /// <summary>
    /// Asset Resource Dependency Property
    /// </summary>
    public static readonly DependencyProperty AssetResourceProperty =
    DependencyProperty.Register(nameof(AssetResource), typeof(AssetResource),
    typeof(Asset), new PropertyMetadata(AssetResource.Empty,
    new PropertyChangedCallback((DependencyObject obj, DependencyPropertyChangedEventArgs eventArgs) =>
        SetAssetResource(obj as Asset, eventArgs.NewValue as AssetResource))));

    /// <summary>
    /// Asset Resource
    /// </summary>
    public AssetResource AssetResource
    {
        get => (AssetResource)GetValue(AssetResourceProperty);
        set => SetValue(AssetResourceProperty, value);
    }
}
