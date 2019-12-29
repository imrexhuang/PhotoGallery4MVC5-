﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace photoGallery.Models
{
    public class Photo
    {
        [Key]
        public int ID { get; set; }
        
        public string Title{get;set;}

        [ScaffoldColumn(false)]
        public string ImageName { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("Inserted Date ")]
        public DateTime? InsertedDateTime { get; set; }

        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LastUpdatedDatetime { get; set; }

        [ScaffoldColumn(false)]
        public string InsertedBy { get; set; }
        [ScaffoldColumn(false)]
        public string LastUpdatedBy { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        [Display(Name = "Browse File")]
        [ScaffoldColumn(false)]
        [NotMapped]
        public HttpPostedFileBase[] files { get; set; }

    }
}