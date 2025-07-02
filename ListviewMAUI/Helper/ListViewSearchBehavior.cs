namespace ListViewMAUI
{
    public class ListViewSearchBehavior : Behavior<ContentPage>
    {
        #region Fields

        private Syncfusion.Maui.ListView.SfListView ListView;
        private Entry searchBar = null;

        #endregion

        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {
            ListView = ListView = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");
            searchBar = bindable.FindByName<Entry>("searchBar");          
            searchBar.TextChanged += SearchBar_TextChanged;

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView = null;
            searchBar = null;
            searchBar.TextChanged -= SearchBar_TextChanged;
            base.OnDetachingFrom(bindable);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as Entry);
            if (ListView.DataSource != null)
            {
                ListView.DataSource.Filter = FilterBooks;
                ListView.DataSource.RefreshFilter();
            }
            ListView.RefreshView();
        }
        private bool FilterBooks(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;

            var bookInfo = obj as BookInfo;
            return (bookInfo.Name.ToLower().Contains(searchBar.Text.ToLower()) || (bookInfo.Author.ToString()).ToLower().Contains(searchBar.Text.ToLower()) || bookInfo.Description.ToLower().Contains(searchBar.Text.ToLower()));
        }


        #endregion
    }
}
