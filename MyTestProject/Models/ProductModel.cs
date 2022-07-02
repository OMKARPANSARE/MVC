using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyTestProject.Models
{
    public class ProductModel
    {
        public int ID { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        
        [DisplayName("Description")]
        public string Description { get; set; }
        public double Quntity { get; set; }
        public double Price { get; set; }
        [DisplayName("Supplier Name")]
        public string SupplierName { get; set; }
        public int IsActive { get; set; }


    }
}