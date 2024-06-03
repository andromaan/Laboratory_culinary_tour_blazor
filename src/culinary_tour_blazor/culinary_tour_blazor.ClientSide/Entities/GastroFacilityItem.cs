﻿using System.ComponentModel.DataAnnotations.Schema;

namespace culinary_tour_blazor.ClientSide.Entities
{
    public class GastroFacilityItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey(nameof(Type))]
        public int TypeId { get; set; }
        public FacilityTypeItem? Type { get; set; }
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "decimal(2, 1)")]
        public double? RatingAvg { get; set; } = 0;
        public string? Description { get; set; } = string.Empty;
        public string? ImagePath { get; set; }
        public byte[]? Photo { get; set; }

        public virtual ICollection<CuisineItem> Cuisines { get; set; } = new HashSet<CuisineItem>();
    }
}
