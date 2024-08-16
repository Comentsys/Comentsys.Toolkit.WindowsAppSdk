namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Directional Pad Event Args
/// </summary>
/// <param name="direction">Directional Pad Direction</param>
public class DirectionalPadEventArgs(DirectionalPadDirection direction) : EventArgs
{
    /// <summary>
    /// Direction
    /// </summary>
    public DirectionalPadDirection Direction { get; set; } = direction;
}
