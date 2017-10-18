using Menu.Domain.Enum;

namespace Menu.Domain.Entities
{
    public class Cost : EntityBase
    {
        public decimal Total { get; set; }
        public decimal PerUnit { get; set; }
        public UnitOfVolume Magnitude { get; set; }
        public UnitOfVolumeType MagnitudeType { get; set; }

        public virtual Consolidation Consolidation { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
