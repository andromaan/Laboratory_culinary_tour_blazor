using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace culinary_tour.Core.Entities
{
    public class Review : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey(nameof(GastroFacility))]
        public Guid GastroFacilityId { get; set; }
        public GastroFacility GastroFacility { get; set; }
        public string Coment {  get; set; }

        [Column(TypeName = "decimal(2, 1)")]
        public double Rating { get; set; }
        public DateTime DateTime { get; set; }
        public string VideoFilePath { get; set; }
        public virtual ICollection<ReviewImages> ReviewImages { get; set; } = new HashSet<ReviewImages>();
    }
}
