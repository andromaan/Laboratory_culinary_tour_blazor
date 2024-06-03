using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace culinary_tour.Core.Entities
{
    public class Image : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Path { get; set; }

        [ForeignKey(nameof(GastroFacility))]
        public Guid GastroFacilityId { get; set; }
        public GastroFacility GastroFacility { get; set; }
    }
}
