using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using AnimalListing.Models;
using DynamicData;
using ReactiveUI;
using Sextant;

namespace AnimalListing.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> LoadAnimals { get; set; }
        private readonly ReadOnlyObservableCollection<AnimalGroup> _animals;
        public ReadOnlyObservableCollection<AnimalGroup> Animals => _animals;

        private AnimalService _animalService;

        public HomeViewModel(IViewStackService viewStackService)
            : base(viewStackService)
        {
            LoadAnimals = ReactiveCommand.CreateFromObservable(() => _animalService.LoadAnimals());

            _animalService = new AnimalService();
            _animalService
                .Animals
                .Connect()
                .Group(arg => arg.AnimalGroupName)                                             //create a dynamic group
                .Transform(grouping => new AnimalGroup(grouping))
                .Where(x => x.Count > 0)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _animals)
                .DisposeMany()
                .Subscribe();

            LoadAnimals.Subscribe();
        }

        public override string Id => "Animals";
    }
}
