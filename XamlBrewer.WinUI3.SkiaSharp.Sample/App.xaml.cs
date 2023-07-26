using Microsoft.UI.Xaml;
using XamlBrewer.WinUI3.Services;

namespace XamlBrewer.WinUI3.SkiaSharp.Sample
{
    public partial class App : Application
    {
        private Shell shell;

        public App()
        {
            InitializeComponent();
        }

        internal INavigation Navigation => shell;

        internal UIElement AppRoot => shell.AppRoot;

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            shell = new Shell();
            shell.Activate();
        }
    }
}
