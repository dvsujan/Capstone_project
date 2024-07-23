﻿using System.ComponentModel.DataAnnotations;

namespace CofeeStoreManagement.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User User { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }
}
