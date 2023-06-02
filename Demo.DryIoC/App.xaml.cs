namespace Demo.DryIoC
{
    using DryIoc;
    using LazyTab;
    using Shared;

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
            container.Register<ILazyTabFactory, LazyTabFactory>(Reuse.Singleton);

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}