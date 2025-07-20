namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget
/// </summary>
public interface IWidget
{
    /// <summary>
    /// Widget Context
    /// </summary>
    WidgetContext? Context { get; set; }

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
    /// Is Configure?
    /// </summary>
    bool IsConfigure { get; set; }

    /// <summary>
    /// Set State
    /// </summary>
    /// <param name="state">State</param>
    void SetState(string state);

    /// <summary>
    /// Set Is Activated
    /// </summary>
    /// <param name="isActivated">Is Activated</param>
    void SetIsActivated(bool isActivated);

    /// <summary>
    /// Create Widget
    /// </summary>
    /// <param name="state">State</param>
    void CreateWidget(string state);

    /// <summary>
    /// Activate Widget
    /// </summary>
    void Activate();

    /// <summary>
    /// Deactivate Widget
    /// </summary>
    void Deactivate();

    /// <summary>
    /// Delete Widget
    /// </summary>
    /// <param name="state">State</param>
    void DeleteWidget(string state);

    /// <summary>
    /// Widget On Action Invoked
    /// </summary>
    /// <param name="actionInvokedArgs">Widget Action Invoked Args</param>
    void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs);

    /// <summary>
    /// On Widget Context Changed
    /// </summary>
    /// <param name="contextChangedArgs">Context Changed Args</param>
    void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs);

    /// <summary>
    /// On Widget Customization Requested
    /// </summary>
    /// <param name="customizationRequestedArgs">Customization Requested Args</param>
    void OnCustomizationRequested(WidgetCustomizationRequestedArgs customizationRequestedArgs);

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
