﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class KoiType
    {
        public KoiType()
        {
            KoiProfiles = new HashSet<KoiProfile>();
        }

        public int Type_Id { get; set; }
        public string Type_Name { get; set; }
        public string Description { get; set; }
        public DateTime? Create_At { get; set; }
        public DateTime? Update_At { get; set; }
        public string Status { get; set; }

        public virtual ICollection<KoiProfile> KoiProfiles { get; set; }
    }
}