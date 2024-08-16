namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget Provider Factory
/// </summary>
/// <remarks>
/// Copyright (C) Microsoft Corporation. Licensed under the MIT License.
/// </remarks>
/// <typeparam name="T">Widget Provider</typeparam>
[RequiresUnreferencedCode("WidgetProviderFactory is incompatible with trimming.")]
internal class WidgetProviderFactory<T> : IClassFactory where T : IWidgetProvider, new()
{
    private const int CLASS_E_NOAGGREGATION = -2147221232;
    private const int E_NOINTERFACE = -2147467262;

    /// <summary>
    /// Create Instance
    /// </summary>
    /// <param name="pUnkOuter">Outer Unknown</param>
    /// <param name="riid">Reference Id</param>
    /// <param name="ppvObject">Object</param>
    /// <returns>Value</returns>
    public int CreateInstance(nint pUnkOuter, ref Guid riid, out nint ppvObject)
    {
        ppvObject = nint.Zero;

        if (pUnkOuter != nint.Zero)
            Marshal.ThrowExceptionForHR(CLASS_E_NOAGGREGATION);

        if (riid == typeof(T).GUID || riid == Guid.Parse(Guids.IUnknown))
            // Create the instance of the .NET object
            ppvObject = MarshalInspectable<IWidgetProvider>.FromManaged(new T());
        else
            // The object that ppvObject points to does not support the
            // interface identified by riid.
            Marshal.ThrowExceptionForHR(E_NOINTERFACE);
        return 0;
    }

    /// <summary>
    /// Lock Server
    /// </summary>
    /// <param name="fLock">Lock</param>
    /// <returns>Value</returns>
    int IClassFactory.LockServer(bool fLock) => 0;
}