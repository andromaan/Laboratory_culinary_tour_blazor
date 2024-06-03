using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace culinary_tour.Core.Entities
{
    public class GastroFacility : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public FacilityType? Type { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(2, 1)")]
        public double? RatingAvg { get; set; } = 0;
        public string? Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public byte[]? Photo { get; set; }
        public virtual ICollection<Cuisine> Cuisines { get; set; } = new HashSet<Cuisine>();
    }
}
