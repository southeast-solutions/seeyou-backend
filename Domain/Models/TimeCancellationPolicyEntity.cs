using System;

namespace Domain.Models
{
    public class TimeCancellationPolicyEntity
    {
        public DateTime FullCashbackUntil { get; set; }
        public DateTime HalfCashbackUntil { get; set; }
    }
}
