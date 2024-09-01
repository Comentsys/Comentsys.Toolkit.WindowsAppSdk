namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget Base
/// </summary>
/// <param name="widgetId">Widget Id</param>
/// <param name="initialState">Initial State</param>
public abstract class WidgetBase(string widgetId, string initialState) : IWidget
{
    /// <summary>
    /// Id
    /// </summary>
    protected string id = widgetId;

    /// <summary>
    /// State
    /// </summary>
    protected string state = initialState;

    /// <summary>
    /// Is Activated
    /// </summary>
    protected bool isActivated = false;

    /// <summary>
    /// Id
    /// </summary>
    public string Id { get => id; }

    /// <summary>
    /// State
    /// </summary>
    public string State { get => state; }

    /// <summary>
    /// Is Activated?
    /// </summary>
    public bool IsActivated { get => isActivated; }

    /// <summary>
    /// Set State
    /// </summary>
    /// <param name="state">State</param>
    public void SetState(string state) =>
        this.state = state;

    /// <summary>
    /// Create Widget
    /// </summary>
    /// <param name="state">State</param>
    public virtual void CreateWidget(string state) { }

    /// <summary>
    /// Activate Widget
    /// </summary>
    public virtual void Activate() { }

    /// <summary>
    /// Deactivate Widget
    /// </summary>
    public virtual void Deactivate() { }

    /// <summary>
    /// Delete Widget
    /// </summary>
    /// <param name="state">State</param>
    public virtual void DeleteWidget(string state) { }

    /// <summary>
    /// Widget On Action Invoked
    /// </summary>
    /// <param name="actionInvokedArgs">Widget Action Invoked Args</param>
    public virtual void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs) { }

    /// <summary>
    /// On Widget Context Changed
    /// </summary>
    /// <param name="contextChangedArgs">Context Changed Args</param>
    public virtual void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs) { }

    /// <summary>
    /// On Widget Customization Requested
    /// </summary>
    /// <param name="customizationRequestedArgs">Customization Requested Args</param>
    public virtual void OnCustomizationRequested(WidgetCustomizationRequestedArgs customizationRequestedArgs) { }

    /// <summary>
    /// Get Template for Widget
    /// </summary>
    /// <returns>Widget Template</returns>
    public abstract string GetTemplateForWidget();

    /// <summary>
    /// Get Data for Widget
    /// </summary>
    /// <returns>Widget Data</returns>
    public abstract string GetDataForWidget();
}
