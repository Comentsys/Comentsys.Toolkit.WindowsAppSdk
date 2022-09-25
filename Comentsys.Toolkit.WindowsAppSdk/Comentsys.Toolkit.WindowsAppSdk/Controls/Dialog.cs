namespace Comentsys.Toolkit.WindowsAppSdk;

/// <summary>
/// Dialog
/// </summary>
public class Dialog
{
    private readonly string? _title;
    private readonly XamlRoot _root;
    private ContentDialog? _dialog;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="root">Xaml Root</param>
    /// <param name="title">Title</param>
    public Dialog(XamlRoot root, string? title = null) =>
        (_root, _title) = (root, title);

    /// <summary>
    /// Confirm
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="primaryButtonText">Primary Button Text</param>
    /// <param name="secondaryButtonText">Secondary Button Text</param>
    /// <param name="title">Override Title</param>
    /// <returns>True if Primary Button Selected False if not</returns>
    public async Task<bool> ConfirmAsync(object content,
        string primaryButtonText = "Ok", string secondaryButtonText = "", 
        string? title = null)
    {
        try
        {
            if (_dialog != null)
                _dialog.Hide();
            _dialog = new ContentDialog()
            {
                XamlRoot = _root,
                Content = content,
                Title = title ?? _title,
                PrimaryButtonText = primaryButtonText,
                SecondaryButtonText = secondaryButtonText
            };
            return await _dialog.ShowAsync() == ContentDialogResult.Primary;
        }
        catch (TaskCanceledException)
        {
            return false;
        }
    }

    /// <summary>
    /// Confirm
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="primaryButtonText">Primary Button Text</param>
    /// <param name="secondaryButtonText">Secondary Button Text</param>
    /// <param name="title">Override Title</param>
    /// <returns>True if Primary Button Selected False if not</returns>
    public Task<bool> ConfirmAsync(string content,
        string primaryButtonText = "Ok", string secondaryButtonText = "",
        string? title = null) =>
           ConfirmAsync(content as object, primaryButtonText, secondaryButtonText, title);

    /// <summary>
    /// Show
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="primaryButtonText">Primary Button Text</param>
    /// <param name="title">Override Title</param>
    public async void Show(object content, string primaryButtonText = "Ok", string? title = null) =>
        _ = await ConfirmAsync(content, primaryButtonText, title: title);

    /// <summary>
    /// Show
    /// </summary>
    /// <param name="content">Content</param>
    /// <param name="primaryButtonText">Primary Button Text</param>
    /// <param name="title">Override Title</param>
    public void Show(string content, string primaryButtonText = "Ok", string? title = null) =>
        Show(content as object, primaryButtonText, title);
}
