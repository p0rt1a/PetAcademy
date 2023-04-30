using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Training
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
    }
}
