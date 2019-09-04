using System.Reactive;
using System.Reactive.Linq;
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
                this.OneWayBind(ViewModel, vm => vm.Animals, v => v.AnimalsCollection.ItemsSource, x =>
                {
                    return x;
                });
            });

            this.WhenAnyValue(x => x.ViewModel)
                .Where(vm => vm != null)
                .SubscribeOn(RxApp.TaskpoolScheduler)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Select(_ => Unit.Default)
                .InvokeCommand(this, x => x.ViewModel.LoadAnimals);
        }
    }
}
