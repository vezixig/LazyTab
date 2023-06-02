namespace Demo.Shared
{
    using System.Diagnostics;

    /// <summary>Interaction logic for TabA.xaml</summary>
    public partial class TabC
    {
        /// <summary>Initializes a new instance of the <see cref="TabC" /> class.</summary>
        public TabC()
        {
            InitializeComponent();
            Debug.WriteLine($"Initialized {nameof(TabC)}");
        }
    }
}