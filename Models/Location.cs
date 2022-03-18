public class Location
{
    public int Id { get; set; }
    public string Country { get; set; }
    public string Continent { get; set; }
    public string Climate { get; set; }
    public ICollection<Salt> Salts { get; set; }
}
