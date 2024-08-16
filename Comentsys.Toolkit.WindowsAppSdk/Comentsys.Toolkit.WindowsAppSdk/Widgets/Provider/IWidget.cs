namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget
/// </summary>
public interface IWidget
{
    /// <summary>
    /// Id
    /// </summary>
    string Id { get; }

    /// <summary>
    /// State
    /// </summary>
    string State { get; }

    /// <summary>
    /// Is Activated?
    /// </summary>
    bool IsActivated { get; }

    /// <summary>
    /// Set State
    /// </summary>
    /// <param name="state">State</param>
    void SetState(string state);

    /// <summary>
    /// Activate Widget
    /// </summary>
    void Activate();

    /// <summary>
    /// Deactivate Widget
    /// </summary>
    void Deactivate();

    /// <summary>
    /// Widget On Action Invoked
    /// </summary>
    /// <param name="actionInvokedArgs">Widget Action Invoked Args</param>
    void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs);

    /// <summary>
    /// On Widget Context Changed
    /// </summary>
    /// <param name="contextChangedArgs"></param>
    void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs);

    /// <summary>
    /// Get Template for Widget
    /// </summary>
    /// <returns>Widget Template</returns>
    string GetTemplateForWidget();

    /// <summary>
    /// Get Data for Widget
    /// </summary>
    /// <returns>Widget Data</returns>
    string GetDataForWidget();
}
