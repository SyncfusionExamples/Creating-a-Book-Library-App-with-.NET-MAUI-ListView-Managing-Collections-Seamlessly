using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ListViewMAUI
{
    public class BookInfo : INotifyPropertyChanged
    {
        #region Fields

        private string name;
        private string desc;
        private string author;
        private string image;

        #endregion

        #region Constructor

        public BookInfo()
        {

        }

        #endregion

        #region Properties
        
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        
        public string Description
        {
            get { return desc; }
            set
            {
                desc = value;
                OnPropertyChanged("Description");
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        [Display(AutoGenerateField = false)]
        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }            
        #endregion
    }

    public class BookOption
    {
        public string ActionName { get; set; }

        public string ActionIcon { get; set; }
    }
}
