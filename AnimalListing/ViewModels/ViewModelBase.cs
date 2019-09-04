using System;
using ReactiveUI;
using Sextant;

namespace AnimalListing.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IViewModel
    {
        protected readonly IViewStackService ViewStackService;

        protected ViewModelBase(IViewStackService viewStackService)
        {
            ViewStackService = viewStackService;
        }

        public abstract string Id { get; }
    }
}
