using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace culinary_tour.Core.Entities
{
    public class FacilityType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GastroFacility> GastroFacilities { get; set; } = new HashSet<GastroFacility>();
    }
}
