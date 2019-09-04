using AnimalListing.ViewModels;
using ReactiveUI;
using ReactiveUI.XamForms;

namespace AnimalListing.Views
{
    public partial class HomeView : ReactiveContentPage<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, vm => vm.Animals, v => v.AnimalsCollection.ItemsSource);
            });
        }
    }
}
