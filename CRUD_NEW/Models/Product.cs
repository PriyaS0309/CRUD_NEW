using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_NEW.Models
{
    public class Product
    {
        [Key]

        [DisplayName("Product ID")]
        public int ID { get; set; }

        [DisplayName("Product Name")]
        public string Name { get; set; }

   
        public virtual int Category_ID { get; set; }
        [ForeignKey("Category_ID")]

        public virtual Category Category { get; set; }
    }
}