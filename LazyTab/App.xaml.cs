namespace LazyTab
{
    using System.Windows;
    using DryIoc;

    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        public App()
        {
            Container = new Container();
            Container.Register(typeof(LazyTab<>), setup: Setup.With(allowDisposableTransient: true));
            Container.Register<MainWindow>();

            var window = Container.Resolve<MainWindow>();
            window.Show();
        }

        #region Properties

        public IContainer Container { get; }

        #endregion
    }
}