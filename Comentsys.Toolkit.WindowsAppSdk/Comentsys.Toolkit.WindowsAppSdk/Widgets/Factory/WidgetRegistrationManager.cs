namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget Registration Manager
/// </summary>
/// <remarks>
/// Copyright (C) Microsoft Corporation. Licensed under the MIT License.
/// </remarks>
/// <typeparam name="TWidgetProvider">Widget Provider</typeparam>
[RequiresUnreferencedCode("WidgetRegistrationManager is incompatible with trimming.")]
public class WidgetRegistrationManager<TWidgetProvider> : IDisposable where TWidgetProvider : IWidgetProvider, new()
{
    private bool _disposedValue = false;
    private readonly ManualResetEvent _disposedEvent = new(false);

    /// <summary>
    /// Class Lifetime Unregister
    /// </summary>
    /// <param name="registrationHandle">Registration Handle</param>
    private class ClassLifetimeUnregister(uint registrationHandle) : IDisposable
    {
        private readonly uint _comRegistrationHandle = registrationHandle;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose() =>
            ClassObject.Revoke(_comRegistrationHandle);
    }

    private readonly IDisposable _registeredProvider;

    private WidgetRegistrationManager(IDisposable provider) =>
        _registeredProvider = provider;

    /// <summary>
    /// Register Provider
    /// </summary>
    /// <returns>Registration Manager of Widget Provider</returns>
    public static WidgetRegistrationManager<TWidgetProvider> RegisterProvider()
    {
        var registration = RegisterClass(typeof(TWidgetProvider).GUID, new WidgetProviderFactory<TWidgetProvider>());
        return new WidgetRegistrationManager<TWidgetProvider>(registration);
    }

    /// <summary>
    /// Register Class
    /// </summary>
    /// <param name="clsid">Class Id</param>
    /// <param name="factory">Class Factory</param>
    /// <returns>Disposable</returns>
    private static IDisposable RegisterClass(Guid clsid, IClassFactory factory)
    {
        ClassObject.Register(clsid, factory, out uint registrationHandle);
        return new ClassLifetimeUnregister(registrationHandle);
    }

    /// <summary>
    /// Dispose
    /// </summary>
    /// <param name="disposing">Is Disposing</param>
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            _registeredProvider.Dispose();
            _disposedValue = true;
            _disposedEvent.Set();
        }
    }

    /// <summary>
    /// Destructor
    /// </summary>
    ~WidgetRegistrationManager() =>
        Dispose(disposing: false);

    /// <summary>
    /// Get Disposed Event
    /// </summary>
    /// <returns></returns>
    public ManualResetEvent GetDisposedEvent() =>
        _disposedEvent;

    /// <summary>
    /// Disposed
    /// </summary>
    public void Dispose()
    {
        // Do not change this code. Put clean up code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}