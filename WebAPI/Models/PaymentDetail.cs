using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class PaymentDetail
    {
        [Key]
        public int PMId { get; set; }
        [Required]
        [MaxLength (100)]
        public string CardOwnerName { get; set; }
        [Required]
        [MaxLength(16)]
        public string CardNumber { get; set; }
        [Required]
        [MaxLength(5)]
        public string ExpirationDate { get; set; }
        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }
    }
}