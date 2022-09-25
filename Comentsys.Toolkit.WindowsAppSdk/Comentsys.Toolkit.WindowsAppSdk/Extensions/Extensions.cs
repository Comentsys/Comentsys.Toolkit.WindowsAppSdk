namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// As Windows Color
    /// </summary>
    /// <param name="color">Drawing Color</param>
    /// <returns>Windows Color</returns>
    public static Color AsWindowsColor(this System.Drawing.Color color) =>
        Color.FromArgb(color.A, color.R, color.G, color.B);

    /// <summary>
    /// As Drawing Color
    /// </summary>
    /// <param name="color">Windows Color</param>
    /// <returns>Drawing Color</returns>
    public static System.Drawing.Color AsDrawingColor(this Color color) =>
        System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

    /// <summary>
    /// As Image Source
    /// </summary>
    /// <param name="assetResource">Asset Resource</param>
    /// <returns>Image Source</returns>
    public static async Task<ImageSource?> AsImageSourceAsync(this AssetResource? assetResource)
    {
        if (assetResource != null)
        {
            var source = new SvgImageSource();
            if (assetResource.Stream.Length > 0)
                await source.SetSourceAsync(assetResource.Stream.AsRandomAccessStream());
            return source;
        }
        return null;
    }
}
