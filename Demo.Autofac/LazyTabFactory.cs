namespace Demo.Autofac
{
    using System;
    using System.Windows.Controls;
    using global::Autofac;
    using LazyTab;

    /// <inheritdoc cref="ILazyTabFactory" />
    public class LazyTabFactory : ILazyTabFactory
    {
        #region Fields

        private readonly ILifetimeScope _componentContext;

        #endregion

        /// <summary>Initializes a new instance of the <see cref="LazyTabFactory" /> class.</summary>
        /// <remarks>As the factory is part of the composition root, using it does not fall into the service locator anti-pattern.</remarks>
        /// <param name="componentContext">The Autofac container.</param>
        public LazyTabFactory(ILifetimeScope componentContext)
            => _componentContext = componentContext;

        #region Methods

        /// <inheritdoc />
        public LazyTab<T> Create<T>(string tabTitle, bool isActive = false)
            where T : UserControl
            => new(_componentContext.Resolve<Func<T>>(), tabTitle, isActive);

        #endregion
    }
}