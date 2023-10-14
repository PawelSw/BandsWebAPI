namespace BandsWebAPI.Entities
{
    public class Description
    {
        public int Id { get; set; }

        public string Genres { get; set; }
        public Band Band { get; set; }
 
    }
}
