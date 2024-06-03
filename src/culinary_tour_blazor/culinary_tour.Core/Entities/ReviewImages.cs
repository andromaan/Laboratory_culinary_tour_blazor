using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace culinary_tour.Core.Entities
{
    public class ReviewImages : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Path { get; set; }

        [ForeignKey(nameof(Review))]
        public Guid ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
