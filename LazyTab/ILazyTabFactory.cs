namespace LazyTab
{
    using System.Windows.Controls;

    /// <summary>Factory to create generic instances of <see cref="LazyTab{T}" />.</summary>
    public interface ILazyTabFactory
    {
        #region Methods

        /// <summary>Returns a new instance of a <see cref="LazyTab{T}" /> object.</summary>
        /// <typeparam name="T">The type of the tab content.</typeparam>
        /// <param name="tabTitle">The title of the tab.</param>
        /// <param name="isActive">Indicates whether the tab should be active per default.</param>
        /// <returns>A new instance of <see cref="LazyTab{T}" />.</returns>
        LazyTab<T> Create<T>(string tabTitle, bool isActive = false)
            where T : UserControl;

        #endregion
    }
}