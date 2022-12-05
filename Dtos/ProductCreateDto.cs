namespace Curso.Dtos
{
    public class ProductCreateDto
    {
        public string? Name {get; set;}
        public string? Description {get; set;}
        public Decimal Price {get; set;}
        public DateTime DateIn {get; set;}
        public bool Active{get; set;}

        public ProductCreateDto()
        {
            DateIn = DateTime.Now;
            Active = true;
        }
    }
}