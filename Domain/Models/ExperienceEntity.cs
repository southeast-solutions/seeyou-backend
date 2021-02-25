using Domain.Attributes;
using Domain.Models;
using System;

namespace Domain
{
    [BsonCollection("experiences")]
    public class ExperienceEntity : Document
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public int NumberOfTourists { get; set; }
        public TourBusinessEntity Guide { get; set; }
        public string AvailableLanguages { get; set; }
        public string Highlights { get; set; }
        public string Description { get; set; }
        public string Included { get; set; }
        public string NotIncluded { get; set; }
        public string CancelationPolicy { get; set; }
    }
}
