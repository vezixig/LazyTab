namespace LazyTab
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;

    /// <summary>Interaction logic for LazyTab.xaml</summary>
    public class LazyTab<T> : UserControl, INotifyPropertyChanged, IDisposable
        where T : UserControl
    {
        #region Fields

        private readonly Func<T> _contentFactory;


        /// <summary>Backing field for <see cref="IsActive" />.</summary>
        private bool _isActive;

        /// <summary>Backing field for <see cref="TabTitle" />.</summary>
        private string _tabTitle = string.Empty;

        #endregion

        /// <summary>Initializes a new instance of the <see cref="LazyTab{T}" /> class.</summary>
        public LazyTab(Func<T> contentFactory, string tabTitle, bool isActive = false)
        {
            _contentFactory = contentFactory ?? throw new ArgumentNullException(nameof(contentFactory), "The content factory was not injected.");
            TabTitle = tabTitle;
            IsActive = isActive;
        }

        #region Delegates & Events

        /// <summary>Event fired after the tab is opened for the first time.</summary>
        public event Action? ContentInitialized;

        /// <inheritdoc />
        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Properties

        /// <summary>Gets or sets a value indicating whether the tab is selected.</summary>
        public bool IsActive
        {
            get => _isActive;
            set
            {
                if (!SetProperty(ref _isActive, value) || !value || Content is not null) return;
                Content = _contentFactory.Invoke();
                ContentInitialized?.Invoke();
            }
        }

        /// <summary>Gets or sets the title of the tab shown in the tab control register.</summary>
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

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new(propertyName));

        private bool SetProperty<TProp>(ref TProp field, TProp value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<TProp>.Default.Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}