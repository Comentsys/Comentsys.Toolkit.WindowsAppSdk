namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// IClassFactory
/// </summary>
/// <remarks>
/// Copyright (C) Microsoft Corporation. Licensed under the MIT License.
/// </remarks>
[ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(Guids.IClassFactory)]
internal interface IClassFactory
{
    /// <summary>
    /// Create Instance
    /// </summary>
    /// <param name="pUnkOuter"></param>
    /// <param name="riid"></param>
    /// <param name="ppvObject"></param>
    /// <returns>Value</returns>
    [PreserveSig]
    int CreateInstance(IntPtr pUnkOuter, ref Guid riid, out IntPtr ppvObject);

    /// <summary>
    /// Lock Server
    /// </summary>
    /// <param name="fLock">Is Locked</param>
    /// <returns>Value</returns>
    [PreserveSig]
    int LockServer(bool fLock);
}