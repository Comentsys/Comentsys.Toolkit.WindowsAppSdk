namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Class Object
/// </summary>
/// <remarks>
/// Copyright (C) Microsoft Corporation. Licensed under the MIT License.
/// </remarks>
[RequiresUnreferencedCode("ClassObject is incompatible with trimming.")]
internal static class ClassObject
{
    /// <summary>
    /// Register
    /// </summary>
    /// <param name="clsid">Class Id</param>
    /// <param name="pUnk">Unknown</param>
    /// <param name="cookie">Cookie</param>
    public static void Register(Guid clsid, object pUnk, out uint cookie)
    {
        [DllImport("ole32.dll")]
        static extern int CoRegisterClassObject(
        [MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
        [MarshalAs(UnmanagedType.IUnknown)] object pUnk,
        uint dwClsContext,
        uint flags,
        out uint lpdwRegister);
        int result = CoRegisterClassObject(clsid, pUnk, 0x4, 0x1, out cookie);
        if (result != 0)
            Marshal.ThrowExceptionForHR(result);
    }

    /// <summary>
    /// Revoke
    /// </summary>
    /// <param name="cookie">Cookie</param>
    /// <returns>Result</returns>
    public static int Revoke(uint cookie)
    {
        [DllImport("ole32.dll")]
        static extern int CoRevokeClassObject(uint dwRegister);
        return CoRevokeClassObject(cookie);
    }
}
