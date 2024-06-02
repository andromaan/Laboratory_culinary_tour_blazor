namespace culinary_tour_blazor.Server.Core.Entities
{
    public class FacilityType : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GastroFacility> GastroFacilities { get; set; } = new HashSet<GastroFacility>();
    }
}
