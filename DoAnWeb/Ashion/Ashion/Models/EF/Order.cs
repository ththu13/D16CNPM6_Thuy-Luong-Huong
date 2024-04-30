﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ashion.Models.EF
{
    [Table("tb_Order")]
    public class Order:Common
    {
        public Order() { 
            this.OrderDetails = new HashSet<OrderDetail>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required(ErrorMessage ="Tên không được để trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "SDT không được để trống")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Đại chỉ không được để trống")]
        public string Address { get; set; }

        public string Email { get; set; }
        public decimal TotalAmount { get; set; }

        public int Quantity { get; set; }

        public int TypePayment{ get; set; }

        public int Status { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}