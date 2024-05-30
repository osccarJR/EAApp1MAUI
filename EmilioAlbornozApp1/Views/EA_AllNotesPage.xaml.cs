namespace EmilioAlbornozApp1.Views
{
    public partial class EA_AllNotesPage : ContentPage
    {
        public EA_AllNotesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((Models.EA_AllNotes)BindingContext).LoadNotes();
        }

        private async void Add_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(EA_NotePage));
        }

        private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.Count != 0)
            {
                // Get the note model
                var note = (Models.EA_Note)e.CurrentSelection[0];

                // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
                await Shell.Current.GoToAsync($"{nameof(EA_NotePage)}?{nameof(EA_NotePage.ItemId)}={note.Filename}");

                // Unselect the UI
                notesCollection.SelectedItem = null;
            }
        }
    }
}
