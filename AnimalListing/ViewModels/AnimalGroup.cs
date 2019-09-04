using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using AnimalListing.Models;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;

namespace AnimalListing.ViewModels
{
    public class AnimalGroup : ObservableCollectionExtended<Animal>, IDisposable
    {
        private readonly IDisposable _cleanUp;

        string _header;
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Header)));
            }
        }

        public AnimalGroup(IGroup<Animal, string, string> animalGroup)
        {
            _cleanUp = animalGroup
                .Cache
                .Connect()
                .Bind(this)
                .Subscribe();

            Header  = animalGroup.Key;
        }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }

    }
}
