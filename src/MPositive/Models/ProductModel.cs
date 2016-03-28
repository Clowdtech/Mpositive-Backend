using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPositive.Models
{
    public class ProductModel
    {
        public AccountModel Account { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
}