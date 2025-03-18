namespace BookMVC.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public Category Kategori { get; set; }

    }
}
