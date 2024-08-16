﻿namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget Provider
/// </summary>
/// <remarks>
/// Copyright (C) Microsoft Corporation. Licensed under the MIT License
/// </remarks>
[ComVisible(true)]
[ComDefaultInterface(typeof(IWidgetProvider))]
public abstract class WidgetProviderBase : IWidgetProvider
{
    private static bool _recoveredWidgets = false;
    private static readonly Dictionary<string, IWidget> _widgetInstances = [];
    private static readonly Dictionary<string, WidgetCreateDelegate> _widgetImplementations = [];

    /// <summary>
    /// Recover Running Widgets
    /// </summary>
    private static void RecoverRunningWidgets()
    {
        if(!_recoveredWidgets)
        {
            try
            {
                var widgetManager = WidgetManager.GetDefault();
                if (widgetManager?.GetWidgetInfos() != null)
                {
                    foreach (var widgetInfo in widgetManager.GetWidgetInfos())
                    {
                        var widgetContext = widgetInfo.WidgetContext;
                        var widgetState = widgetInfo.CustomState;
                        var widgetName = widgetContext.DefinitionId;
                        var widgetId = widgetContext.Id;
                        if (FindWidget(widgetId) is null)
                        {
                            if (_widgetImplementations.TryGetValue(widgetName, out WidgetCreateDelegate? value))
                                _widgetInstances[widgetId] = value(widgetId, widgetState);
                            else
                                widgetManager.DeleteWidget(widgetId);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Ignore Exception
            }
            finally
            {
                _recoveredWidgets = true;
            }
        }
    }

    /// <summary>
    /// Find Widget
    /// </summary>
    /// <param name="widgetId">Widget Id</param>
    /// <returns>Widget</returns>
    private static IWidget? FindWidget(string widgetId) => 
        _widgetInstances.TryGetValue(widgetId, out var widget) ? widget : default;

    /// <summary>
    /// Constructor
    /// </summary>
    public WidgetProviderBase() => 
        RecoverRunningWidgets();

    /// <summary>
    /// Activate Widget
    /// </summary>
    /// <param name="widgetContext">Widget Context</param>
    public void Activate(WidgetContext widgetContext)
    {
        if (FindWidget(widgetContext.Id) is { } widget)
            widget.Activate();
    }

    /// <summary>
    /// Deactivate Widget
    /// </summary>
    /// <param name="widgetId">Widget Id</param>
    public void Deactivate(string widgetId)
    {
        if (FindWidget(widgetId) is { } widget)
            widget.Deactivate();
    }


    /// <summary>
    /// Create Widget
    /// </summary>
    /// <param name="widgetContext">Widget Context</param>
    /// <exception cref="InvalidWidgetDefinitionException"></exception>
    public void CreateWidget(WidgetContext widgetContext)
    {
        if (!_widgetImplementations.TryGetValue(widgetContext.DefinitionId, out WidgetCreateDelegate? widgetCreateDelegate))
            throw new InvalidWidgetDefinitionException(widgetContext.DefinitionId);

        var widgetInstance = widgetCreateDelegate(widgetContext.Id, string.Empty);
        _widgetInstances[widgetContext.Id] = widgetInstance;

        var widgetOptions = new WidgetUpdateRequestOptions(widgetContext.Id)
        {
            Template = widgetInstance.GetTemplateForWidget(),
            Data = widgetInstance.GetDataForWidget(),
            CustomState = widgetInstance.State
        };
        WidgetManager.GetDefault().UpdateWidget(widgetOptions);
    }

    /// <summary>
    /// Delete Widget
    /// </summary>
    /// <param name="widgetId">Widget Id</param>
    /// <param name="customState">Custom State</param>
    public void DeleteWidget(string widgetId, string customState) =>
        _widgetInstances.Remove(widgetId);

    /// <summary>
    /// Widget On Action Invoked
    /// </summary>
    /// <param name="actionInvokedArgs">Action Invoked Args</param>
    public void OnActionInvoked(WidgetActionInvokedArgs actionInvokedArgs)
    {
        if (FindWidget(actionInvokedArgs.WidgetContext.Id) is { } runningWidget)
            runningWidget.OnActionInvoked(actionInvokedArgs);
    }

    /// <summary>
    /// On Widget Context Changed
    /// </summary>
    /// <param name="contextChangedArgs">Context Changed Args</param>
    public void OnWidgetContextChanged(WidgetContextChangedArgs contextChangedArgs)
    {
        if (FindWidget(contextChangedArgs.WidgetContext.Id) is { } runningWidget)
            runningWidget.OnWidgetContextChanged(contextChangedArgs);
    }

    /// <summary>
    /// Update Widget
    /// </summary>
    /// <param name="widgetId">Widget Id</param>
    /// <param name="customState">Custom State</param>
    /// <returns>True if Updated, False if Not</returns>
    public static bool UpdateWidget(string widgetId, string customState)
    {
        RecoverRunningWidgets();
        var widgetInstance = FindWidget(widgetId);
        if(widgetInstance == null) 
            return false;    
        widgetInstance.SetState(customState);
        var widgetOptions = new WidgetUpdateRequestOptions(widgetId)
        {
            Template = widgetInstance.GetTemplateForWidget(),
            Data = widgetInstance.GetDataForWidget(),
            CustomState = widgetInstance.State
        };
        WidgetManager.GetDefault().UpdateWidget(widgetOptions);
        return true;
    }

    /// <summary>
    /// Add Widget
    /// </summary>
    /// <param name="widgetName">Widget Name</param>
    /// <param name="widgetCreateDelegate">Widget Create Delegate</param>
    public static void AddWidget(string widgetName, WidgetCreateDelegate widgetCreateDelegate) =>
        _widgetImplementations.Add(widgetName, widgetCreateDelegate);

    /// <summary>
    /// Clear Widgets
    /// </summary>
    public static void ClearWidgets() => 
        _widgetImplementations.Clear();
}
