using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_NEW.Models
{
    public class Category
    {
        [Key]
       
        [DisplayName("Category ID")]
        public int ID { get; set; }

        [DisplayName("Category Name")]
        public string Name { get; set; }
    }
}