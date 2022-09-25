namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Bool to Visiblity Converter
/// </summary>
public class BoolToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Convert
    /// </summary>
    /// <param name="value">Bool Value</param>
    /// <param name="targetType">Target Type</param>
    /// <param name="parameter">Parameter</param>
    /// <param name="language">Language</param>
    /// <returns>Visiblity</returns>
    public object Convert(object value, Type targetType, object parameter, string language) =>
        (bool)value ? Visibility.Visible : Visibility.Collapsed;

    /// <summary>
    /// Convert Back
    /// </summary>
    /// <param name="value">Value</param>
    /// <param name="targetType">Target Type</param>
    /// <param name="parameter">Parameter</param>
    /// <param name="language">Language</param>
    /// <exception cref="NotImplementedException"></exception>
    public object ConvertBack(object value, Type targetType, object parameter, string language) =>
        throw new NotImplementedException();
}
