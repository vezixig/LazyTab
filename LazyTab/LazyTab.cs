namespace LazyTab
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using DryIoc;
    using IContainer = DryIoc.IContainer;

    public class LazyTabBase : UserControl
    {
        #region Properties

        public required IContainer Container { get; set; }

        #endregion
    }

    /// <summary>Interaction logic for LazyTab.xaml</summary>
    public class LazyTab<T> : UserControl, INotifyPropertyChanged, IDisposable
        where T : UserControl
    {
        #region Fields

        private readonly IContainer _container;

        /// <summary>Backing field for <see cref="IsActive" />.</summary>
        private bool _isActive;

        /// <summary>Backing field for <see cref="TabTitle" />.</summary>
        private string _tabTitle = string.Empty;

        #endregion

        /// <summary>Initializes a new instance of the <see cref="LazyTab{T}" /> class.</summary>
        public LazyTab(IContainer container)
        {
            _container = container;
            DataContext = this;
        }

        #region Delegates & Events

        /// <summary>Event fired after the tab is opened for the first time.</summary>
        public event Action? ContentInitialized;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        /// <summary>Gets or sets a value indicating whether the tab is selected.</summary>
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (SetProperty(ref _isActive, value) && value)
                    if (Content == null)
                    {
                        Content = _container.Resolve<T>();
                        ContentInitialized?.Invoke();
                    }
            }
        }

        /// <summary>Gets or sets the title of the tab.</summary>
        public string TabTitle
        {
            get => _tabTitle;
            set => SetProperty(ref _tabTitle, value);
        }

        #endregion

        #region Methods

        /// <inheritdoc />
        public void Dispose()
        {
            (Content as IDisposable)?.Dispose();
            GC.SuppressFinalize(this);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new(propertyName));

        protected bool SetProperty<TProp>(ref TProp field, TProp value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<TProp>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}