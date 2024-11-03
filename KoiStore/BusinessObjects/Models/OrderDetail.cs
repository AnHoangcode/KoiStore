﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            Feedbacks = new HashSet<Feedback>();
            Ratings = new HashSet<Rating>();
        }

        public int Order_Detail_Id { get; set; }
        public int? Order_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Koi_Id { get; set; }
        public int? Quantity { get; set; }
        public string Order_Detail_Type { get; set; }
        public double? Total { get; set; }
        public DateTime? Create_At { get; set; }
        public DateTime? Update_At { get; set; }
        public DateTime? Start_At { get; set; }
        public DateTime? End_At { get; set; }
        public string Status { get; set; }

        public virtual KoiProfile Koi { get; set; }
        public virtual Order Order { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}