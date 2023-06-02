namespace Demo.Autofac
{
    using global::Autofac;
    using LazyTab;
    using Shared;

    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App
    {
        /// <summary>Initializes a new instance of the <see cref="App" /> class.</summary>
        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>();
            builder.RegisterType<TabA>();
            builder.RegisterType<TabB>();
            builder.RegisterType<TabC>();
            builder.RegisterType<LazyTabFactory>().As<ILazyTabFactory>().SingleInstance();

            var container = builder.Build();
            using var scope = container.BeginLifetimeScope();
            var window = scope.Resolve<MainWindow>();
            window.Show();
        }
    }
}