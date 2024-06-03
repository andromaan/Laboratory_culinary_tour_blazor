using System.ComponentModel.DataAnnotations;

namespace culinary_tour.Core.Entities
{
    public class Cuisine : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GastroFacility> GastroFacilities { get; set; } = new HashSet<GastroFacility>();
    }
}