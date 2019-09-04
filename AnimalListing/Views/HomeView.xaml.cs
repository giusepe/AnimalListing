using System;
using System.Collections.Generic;
using AnimalListing.ViewModels;
using ReactiveUI.XamForms;
using Xamarin.Forms;

namespace AnimalListing.Views
{
    public partial class HomeView : ReactiveContentPage<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
