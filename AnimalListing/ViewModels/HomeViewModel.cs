using System;
using System.Collections.Generic;
using AnimalListing.Models;
using Sextant;

namespace AnimalListing.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(IViewStackService viewStackService) : base(viewStackService)
        {
            var service = new AnimalService();
            Animals = service.CreateAnimalGrouls();
        }

        public override string Id => "Animals";

        public List<AnimalGroup> Animals { get; }
    }
}
