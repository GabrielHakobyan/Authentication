namespace Authentication.Model
{
    public class Persons
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password {  get; set; }= string.Empty;
        public int RolesId {  get; set; }
        public Roles roles { get; set; } = null!;
    }
}
