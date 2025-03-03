using Syncfusion.Maui.Core;

namespace ListViewMAUI
{
    public partial class BookPage : ContentPage
    {
        public BookPage()
        {
            InitializeComponent();
        }

        private void OnChipClicked(object sender, EventArgs e)
        {
            var viewmodel = this.BindingContext as ViewModel;
            var chip = (sender as SfChip);
            var layout = chip.Children[0] as HorizontalStackLayout;
            var action = (layout.BindingContext as BookOption).ActionName;
            if (string.IsNullOrEmpty(action))
                return;

            switch(action)
            {
                case "Edit":
                    viewmodel.OnEditBookCommand();
                    break;
                case "Delete":
                    viewmodel.OnDeleteBookCommand();
                    break;
                case "Save":
                    bookForm.Commit();
                    viewmodel.OnSaveBook();                    
                    break;
                case "Cancel":
                    viewmodel.OnCancelBook();
                    break;
            }
        }
    }
}