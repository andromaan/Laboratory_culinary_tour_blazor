namespace culinary_tour_blazor.ClientSide.Entities
{
    public class FacilityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GastroFacility> GastroFacilities { get; set; } = new HashSet<GastroFacility>();
    }
}
