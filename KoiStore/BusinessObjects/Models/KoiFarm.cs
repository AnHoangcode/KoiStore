﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class KoiFarm
    {
        public KoiFarm()
        {
            KoiProfiles = new HashSet<KoiProfile>();
        }

        public int Farm_Id { get; set; }
        public string Farm_Name { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public virtual ICollection<KoiProfile> KoiProfiles { get; set; }
    }
}