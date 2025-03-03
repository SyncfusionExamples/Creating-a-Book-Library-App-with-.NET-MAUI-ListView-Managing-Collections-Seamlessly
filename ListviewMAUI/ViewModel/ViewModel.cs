using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Linq;

namespace ListViewMAUI
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<BookInfo> bookInfo;

        private BookInfo selectBook;

        private bool isReadOnly;

        public event PropertyChangedEventHandler? PropertyChanged;

        #endregion

        #region Constructor

        public ViewModel()
        {
            GenerateSource();
            InitializeCommands();            
            InitializeCRUDOptions();
            InitializeCommitOptions();
        }

        #endregion

        #region Properties

        public ObservableCollection<BookInfo> Books
        {
            get { return bookInfo; }
            set { bookInfo = value; }
        }

        public BookInfo SelectedItem
        {
            get
            {
                return selectBook;
            }
            set
            {
                selectBook = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public ObservableCollection<BookOption> CRUDOptions { get; set; }

        public ObservableCollection<BookOption> CommitOptions { get; set; }

        private void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                isReadOnly = value;

                OnPropertyChanged(nameof(IsReadOnly));
                OnPropertyChanged(nameof(IsVisible));
            }
        }

        public bool IsVisible
        {
            get
            {
                return !IsReadOnly;
            }
        }

        public Command CreateBookCommand { get; set; }
        public Command SaveBookCommand { get; set; }
        public Command CancelBookCommand { get; set; }
        public Command EditBookCommand { get; set; }
        public Command DeleteBookCommand { get; set; }
        public Command TapCommand { get; set; }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            ListViewBookInfoRepository bookInfoRepository = new ListViewBookInfoRepository();
            bookInfo = bookInfoRepository.GetBookInfo();
        }

        #endregion
        private void InitializeCommands()
        {
            CreateBookCommand = new Command(OnCreateBook);
            SaveBookCommand = new Command(OnSaveBook);
            CancelBookCommand = new Command(OnCancelBook);
            TapCommand = new Command(OnTapCommand);
            EditBookCommand = new Command(OnEditBookCommand);
            DeleteBookCommand = new Command(OnDeleteBookCommand);
        }

        internal async void OnCreateBook()
        {
            SelectedItem = new BookInfo();
            IsReadOnly = false;
            var editPage = new BookPage();
            editPage.BindingContext = this;
            await App.Current.MainPage.Navigation.PushAsync(editPage);
        }

        internal async void OnCancelBook()
        {
            SelectedItem = null;
            await App.Current.MainPage.Navigation.PopAsync();
        }

        internal async void OnSaveBook()
        {
            if (!Books.Contains(SelectedItem))
            {
                Books.Add(SelectedItem);
            }            
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnTapCommand(object eventArgs)
        {
            var tappedEventArgs = eventArgs as Syncfusion.Maui.ListView.ItemTappedEventArgs;
            if (tappedEventArgs != null)
            {
                SelectedItem = tappedEventArgs.DataItem as BookInfo;
                if (SelectedItem == null)
                    return;
                IsReadOnly = true;
                var editPage = new BookPage();
                editPage.BindingContext = this;
                await App.Current.MainPage.Navigation.PushAsync(editPage);
            }
        }
        internal void OnEditBookCommand()
        {
            IsReadOnly = false;
        }

        internal async void OnDeleteBookCommand()
        {
            Books.Remove(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void InitializeCRUDOptions()
        {
            CRUDOptions = new ObservableCollection<BookOption>();
            CRUDOptions.Add(new BookOption() { ActionName = "Edit", ActionIcon = "\ue73d" });
            CRUDOptions.Add(new BookOption() { ActionName = "Delete", ActionIcon = "\ue73c" });
        }
        private void InitializeCommitOptions()
        {
            CommitOptions = new ObservableCollection<BookOption>();
            CommitOptions.Add(new BookOption() { ActionName = "Save", ActionIcon = "\ue726" });
            CommitOptions.Add(new BookOption() { ActionName = "Cancel", ActionIcon = "\ue755" });
        }


    }
}
