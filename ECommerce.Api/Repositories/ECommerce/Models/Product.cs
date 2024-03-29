﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Repositories.ECommerce.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long Price { get; set; }

        public string PictureUrl { get; set; }

        public string Brand { get; set; }

        public string Type { get; set; }

        public int QuantityInStock { get; set; }
    }
}
