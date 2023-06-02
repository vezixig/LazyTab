namespace Demo.Shared
{
    using System.Diagnostics;

    /// <summary>Interaction logic for TabA.xaml</summary>
    public partial class TabB
    {
        /// <summary>Initializes a new instance of the <see cref="TabB" /> class.</summary>
        public TabB()
        {
            InitializeComponent();
            Debug.WriteLine($"Initialized {nameof(TabB)}");
        }
    }
}