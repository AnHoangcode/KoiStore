﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Rating
    {
        public int Rating_Id { get; set; }
        public int? User_Id { get; set; }
        public int? Order_Detail_Id { get; set; }
        public double? Rating_Value { get; set; }
        public string Description { get; set; }
        public DateTime? Create_At { get; set; }
        public string Status { get; set; }

        public virtual OrderDetail Order_Detail { get; set; }
        public virtual User User { get; set; }
    }
}