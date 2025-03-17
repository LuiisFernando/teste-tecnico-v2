using Thunders.TechTest.Domain.Enums;

namespace Thunders.TechTest.Domain.Entities
{
    public class TollLog
    {
        public int Id { get; set; }
        public DateTime LogDateTime { get; set; }
        public string? TollPlaza { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public decimal AmountPaid { get; set; }
        public VehicleType VehicleType { get; set; }

    }
}
