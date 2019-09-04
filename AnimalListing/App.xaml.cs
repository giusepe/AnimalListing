using System;
using AnimalListing.ViewModels;
using AnimalListing.Views;
using ReactiveUI;
using Sextant;
using Sextant.XamForms;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Sextant.Sextant;


namespace AnimalListing
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Instance.InitializeForms();

            Locator
                .CurrentMutable
                .RegisterNavigationView(() => new NavigationView(RxApp.MainThreadScheduler, RxApp.TaskpoolScheduler, ViewLocator.Current))
                .RegisterView<HomeView, HomeViewModel>();

            Locator
                .Current
                .GetService<IViewStackService>()
                .PushPage(new HomeViewModel(Locator.Current.GetService<IViewStackService>()), null, true, false)
                .Subscribe();

            MainPage = Locator.Current.GetNavigationView();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
