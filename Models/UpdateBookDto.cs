namespace BookStore_WebApi.Models
{
    public class UpdateBookDto
    {
        public string Title { get; set; }
        public string Despription { get; set; }
        public int Amount { get; set; }
        public int page { get; set; }
    }
}