// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Counting.Widget;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : Application
{
    private const string headless = "-headless";

    private Window _window;

    /// <summary>
    /// Is Headless?
    /// </summary>
    /// <returns>True if Is, False if Not</returns>
    private static bool IsHeadless() =>
        Environment.GetCommandLineArgs().Contains(headless);

    /// <summary>
    /// Initializes the singleton application object.  This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        ComWrappersSupport.InitializeComWrappers();
        InitializeComponent();
        WidgetProvider.AddWidget(CountingWidget.DefinitionId, (widgetId, initialState, widgetContext) => 
            new CountingWidget(widgetId, initialState, widgetContext));
        WidgetRegistrationManager<WidgetProvider>.RegisterProvider();
    }

    /// <summary>
    /// Invoked when the application is launched.
    /// </summary>
    /// <param name="args">Details about the launch request and process.</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        if (!IsHeadless())
        {
            _window = new MainWindow();
            _window.Activate();
        }   
    }
}
