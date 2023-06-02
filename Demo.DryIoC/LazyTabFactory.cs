namespace Demo.DryIoC
{
    using System;
    using System.Windows.Controls;
    using DryIoc;
    using LazyTab;

    /// <inheritdoc cref="ILazyTabFactory" />
    public class LazyTabFactory : ILazyTabFactory
    {
        #region Fields

        private readonly IContainer _container;

        #endregion

        /// <summary>Initializes a new instance of the <see cref="LazyTabFactory" /> class.</summary>
        /// <remarks>As the factory is part of the composition root, using it does not fall into the service locator anti-pattern.</remarks>
        /// <param name="container">The DryIoC container.</param>
        public LazyTabFactory(IContainer container)
            => _container = container;

        #region Methods

        /// <inheritdoc />
        public LazyTab<T> Create<T>(string tabTitle, bool isActive = false)
            where T : UserControl
            => new(_container.Resolve<Func<T>>(), tabTitle, isActive);

        #endregion
    }
}