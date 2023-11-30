namespace BookStore_WebApi.Models
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public string Despription { get; set; }
        public int Amount { get; set; }
        public int page { get; set; }
    }
}
