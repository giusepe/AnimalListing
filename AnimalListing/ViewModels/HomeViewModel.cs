using System;
using Sextant;

namespace AnimalListing.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(IViewStackService viewStackService) : base(viewStackService)
        {
            
        }

        public override string Id => "Animals";
    }
}
