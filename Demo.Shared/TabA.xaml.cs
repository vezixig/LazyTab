namespace Demo.Shared
{
    using System.Diagnostics;

    /// <summary>Interaction logic for TabA.xaml</summary>
    public partial class TabA
    {
        /// <summary>Initializes a new instance of the <see cref="TabA" /> class.</summary>
        public TabA()
        {
            InitializeComponent();
            Debug.WriteLine($"Initialized {nameof(TabA)}");
        }
    }
}