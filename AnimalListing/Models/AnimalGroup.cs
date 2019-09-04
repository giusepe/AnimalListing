using System;
using System.Collections.Generic;

namespace AnimalListing.Models
{
    public class AnimalGroup : List<Animal>
    {
        public string Name { get; private set; }

        public AnimalGroup(string name, List<Animal> animals) : base(animals)
        {
            Name = name;
        }
    }
}
