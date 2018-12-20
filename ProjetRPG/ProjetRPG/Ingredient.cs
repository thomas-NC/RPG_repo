using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Ingredient : Item
    {
        public string description;

        public Ingredient(string name, string description) : base(name)
        {
            this.description = description;
        }
    }
}
