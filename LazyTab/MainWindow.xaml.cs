namespace LazyTab
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;

    /// <summary>Interaction logic for MainWindow.xaml</summary>
    public partial class MainWindow
    {
        public MainWindow(Func<LazyTab<TabA>> createTabA, Func<LazyTab<TabB>> createTabB)
        {
            InitializeComponent();
            DataContext = this;

            Tabs.Add(createTabA());
            Tabs.Add(createTabB());
        }

        #region Properties

        /// <summary>Gets the tabs.</summary>
        public ObservableCollection<UserControl> Tabs { get; } = new();

        #endregion
    }
}