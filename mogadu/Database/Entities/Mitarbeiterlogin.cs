namespace mogadu.Database.Entities
{
    public class Mitarbeiterlogin
    {
        public virtual long MitarbeiterloginId { get; set; }
        public virtual long MitarbeiterId { get; set; }
        public virtual string Passwort { get; set; }
    }
}
