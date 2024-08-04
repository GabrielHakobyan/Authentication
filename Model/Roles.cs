namespace Authentication.Model
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public ICollection<Persons> Persons { get; set; } = null!;
    }
}
