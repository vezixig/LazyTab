namespace Demo.DryIoC
{
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow
    {
        /// <summary>Initializes a new instance of the <see cref="MainWindow" /> class.</summary>
        /// <param name="lazyTabFactory">The factory to create generic lazy tabs.</param>
        public MainWindow(ILazyTabFactory lazyTabFactory)
        {
            InitializeComponent();
            DataContext = this;

            Tabs.Add(lazyTabFactory.Create<TabA>("Tab A"));
            Tabs.Add(lazyTabFactory.Create<TabB>("Tab B", true));
            Tabs.Add(lazyTabFactory.Create<TabC>("Tab C"));
        }

        #region Properties

        /// <summary>Gets the collection of tabs.</summary>
        public ObservableCollection<UserControl> Tabs { get; } = new();

        #endregion
    }
}