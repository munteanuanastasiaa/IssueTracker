using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Product
    {
        public int Id {  get; set; }
        public string Name {  get; set; }
        public int Units {  get; set; }
        public double Price{  get; set; }
        public int CategoryId{  get; set; }


        public Product (int Id, string Name,  int Units, double Price, int CategoryId)
        {
            this.Id = Id;
            this.Name = Name;
            this.Units = Units;
           this.Price = Price;
            this.CategoryId = CategoryId;
        }
    }
}
