using Domain.Attributes;
using Domain.Models;
using System;
using System.Collections.Generic;

namespace Domain
{
    [BsonCollection("experiences")]
    public class ExperienceEntity : Document
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public DateTime DateTime { get; set; }
        public double Price { get; set; }
        public long Duration { get; set; }
        public PhysicalLocationEntity Location { get; set; }
        public int NumberOfTourists { get; set; }
        public TourBusinessEntity Guide { get; set; }
        public string AvailableLanguages { get; set; }
        public IEnumerable<string> Highlights { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> IncludedServices { get; set; }
        public IEnumerable<string> NotIncludedServices { get; set; }
        public TimeCancellationPolicyEntity CancelationPolicy { get; set; }
    }
}
