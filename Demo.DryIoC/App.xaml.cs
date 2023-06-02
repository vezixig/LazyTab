namespace Demo.DryIoC
{
    using DryIoc;

    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App
    {
        /// <summary>Initializes a new instance of the <see cref="App" /> class.</summary>
        public App()
        {
            var container = new Container();
            container.Register<MainWindow>();
            container.Register<TabA>();
            container.Register<TabB>();
            container.Register<TabC>();
            container.Register<ILazyTabFactory, LazyTabFactory>();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}