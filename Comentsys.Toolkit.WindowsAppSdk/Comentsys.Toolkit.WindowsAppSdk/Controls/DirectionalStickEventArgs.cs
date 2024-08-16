namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Directional Stick Event Args
/// </summary>
/// <param name="angle">Stick Angle around Centre</param>
/// <param name="ratio"> Stick Ratio from Centre</param>
public class DirectionalStickEventArgs(double angle, double ratio) : EventArgs
{
    /// <summary>
    /// Stick Angle around Centre
    /// </summary>
    public double Angle { get; set; } = angle;

    /// <summary>
    /// Stick Ratio from Centre
    /// </summary>
    public double Ratio { get; set; } = ratio;
}
