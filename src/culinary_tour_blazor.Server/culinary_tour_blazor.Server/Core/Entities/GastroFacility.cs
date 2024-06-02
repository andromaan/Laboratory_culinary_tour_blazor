using Microsoft.AspNetCore.Mvc.ViewEngines;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace culinary_tour_blazor.Server.Core.Entities
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
