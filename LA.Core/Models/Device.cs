using System;
using System.Collections.Generic;

namespace LA.Core.Models
{
    public class Device
    {
        protected Device() {}

        public Device(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
            CreateAt();
        }
        
        private List<Location> _locations = new List<Location>();
        
        public Guid Id { get;}
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public Location Location { get; set; }
        public Guid LocationId { get; set; }

        public IEnumerable<Location> Locations => _locations.AsReadOnly();

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Device name cannot be empty.");
            }

            if (name.Length < 2)
            {
                throw new ArgumentException("Name requires minimum 5 characters.");
            }
            
            Name = name;
            UpdateAt();
        }

        public void SetDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentNullException(nameof(description), "Description name cannot be empty.");
            }

            if (description.Length < 5)
            {
                throw new ArgumentException("Name requires minimum 5 characters.");
            }

            Description = description;
            UpdateAt();
        }

        private void UpdateAt() { UpdatedAt = DateTime.UtcNow; }
        private void CreateAt() { CreatedAt = DateTime.UtcNow; }
    }
}