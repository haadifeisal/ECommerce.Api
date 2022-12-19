using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Api.Repositories.ECommerce.Models
{
    [Table("BasketItems")]
    public class BasketItem
    {
        [Key]
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}
