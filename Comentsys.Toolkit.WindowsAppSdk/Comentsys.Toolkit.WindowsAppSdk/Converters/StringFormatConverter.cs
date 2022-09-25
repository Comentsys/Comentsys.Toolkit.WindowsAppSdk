namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// String Format Converter
/// </summary>

public class StringFormatConverter : IValueConverter
{
    /// <summary>
    /// Convert
    /// </summary>
    /// <param name="value">Bool Value</param>
    /// <param name="targetType">Target Type</param>
    /// <param name="parameter">String Format</param>
    /// <param name="language">Language</param>
    /// <returns>Formatted String</returns>
    public object Convert(object value, Type targetType, object parameter, string language) => 
        parameter != null ? string.Format((string)parameter, value) : value;

    /// <summary>
    /// Convert Back
    /// </summary>
    /// <param name="value">Bool Value</param>
    /// <param name="targetType">Target Type</param>
    /// <param name="parameter">String Format</param>
    /// <param name="language">Language</param>
    /// <exception cref="NotImplementedException"></exception>
    public object ConvertBack(object value, Type targetType, object parameter, string language) => 
        throw new NotImplementedException();
}