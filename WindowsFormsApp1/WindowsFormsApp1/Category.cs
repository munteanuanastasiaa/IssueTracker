using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public Category(int Id, string name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}
