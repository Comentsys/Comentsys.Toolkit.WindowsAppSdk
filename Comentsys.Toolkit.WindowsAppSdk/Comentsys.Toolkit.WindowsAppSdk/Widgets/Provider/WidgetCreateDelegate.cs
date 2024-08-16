using Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget Create Delegate
/// </summary>
/// <remarks>
/// Copyright (C) Microsoft Corporation. Licensed under the MIT License.
/// </remarks>
/// <param name="widgetId">Widget Id</param>
/// <param name="initialState">Initial State</param>
/// <returns>Widget Base</returns>
public delegate WidgetBase WidgetCreateDelegate(string widgetId, string initialState);