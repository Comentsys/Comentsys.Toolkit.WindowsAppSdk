namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Widget Helper
/// </summary>
public static class WidgetHelper
{
    /// <summary>
    /// Read Json from Package
    /// </summary>
    /// <param name="packageUri">Package Uri</param>
    /// <returns>Json</returns>
    public static string ReadJsonFromPackage(string packageUri)
    {
        var uri = new Uri(packageUri);
        var storageFileTask = StorageFile.GetFileFromApplicationUriAsync(uri).AsTask();
        storageFileTask.Wait();
        var readTextTask = FileIO.ReadTextAsync(storageFileTask.Result).AsTask();
        readTextTask.Wait();
        return readTextTask.Result;
    }
}
