using System.ComponentModel.DataAnnotations;

namespace culinary_tour_blazor.Server.Core.Entities
{
    public interface IEntity<T>
    {
        [Key]
        T Id { get; set; }
    }
}
