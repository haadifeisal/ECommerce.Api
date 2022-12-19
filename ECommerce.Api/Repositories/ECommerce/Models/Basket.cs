using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Repositories.ECommerce.Models
{
    public class Basket
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new ();
    }
}
