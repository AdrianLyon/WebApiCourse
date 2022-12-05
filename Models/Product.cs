namespace Curso.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? Description {get; set;}
        public DateTime DateIn {get; set;}
        public Decimal Price {get; set;}
        public bool Active {get; set;}
    }
}