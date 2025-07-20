namespace Counting.Widget.Widgets;

/// <summary>
/// Counting Widget
/// </summary>
public class CountingWidget : WidgetBase
{
    private const string command = "inc";
    private const string default_display = "0";
    private static string _widgetTemplate = string.Empty;

    /// <summary>
    /// Definition Id
    /// </summary>
    public static string DefinitionId { get; } = nameof(CountingWidget);

    /// <summary>
    /// Click Count
    /// </summary>
    private uint ClickCount { get; set; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="widgetId">Widget Id</param>
    /// <param name="startingState">Starting State</param>
    /// <param name="widgetContext">Widget Context</param>
    public CountingWidget(string widgetId, string startingState, WidgetContext widgetContext) : base(widgetId, startingState, widgetContext)
    {
        if (state == string.Empty)
            state = default_display;
        else
            if (uint.TryParse(state, out uint parsedClickCount))
            ClickCount = parsedClickCount;
    }

    /// <summary>
    /// On Action Invoked
    /// </summary>
    /// <param name="actionInvokedArgs"Action Invoked Args></param>
    public override void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        if (actionInvokedArgs.Verb == command)
        {
            ClickCount++;
            state = ClickCount.ToString();
            var updateOptions = new WidgetUpdateRequestOptions(Id)
            {
                Data = GetDataForWidget(),
                CustomState = State
            };
            WidgetManager.GetDefault().UpdateWidget(updateOptions);
        }
    }

    /// <summary>
    /// Get Template for Widget
    /// </summary>
    /// <returns>Widget Template</returns>
    public override string GetTemplateForWidget()
    {
        if (string.IsNullOrEmpty(_widgetTemplate))
            _widgetTemplate = WidgetHelper.ReadJsonFromPackage("ms-appx:///Assets/CountingWidgetTemplate.json");
        return _widgetTemplate;
    }

    /// <summary>
    /// Get Data for Widget
    /// </summary>
    /// <returns>Widget Data</returns>
    public override string GetDataForWidget()
    {
        var stateNode = new JsonObject
        {
            ["count"] = State
        };
        return stateNode.ToJsonString();
    }
}
