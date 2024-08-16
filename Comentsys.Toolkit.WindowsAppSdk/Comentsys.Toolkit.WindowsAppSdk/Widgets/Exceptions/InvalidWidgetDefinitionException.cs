namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Invalid Widget Definition Exception
/// </summary>
/// <param name="definitionId">Definition Id</param>
public class InvalidWidgetDefinitionException(string definitionId) : Exception
{
    /// <summary>
    /// Definition Id
    /// </summary>
    public string DefinitionId { get; set; } = definitionId;
}