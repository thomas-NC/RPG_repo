using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Herb : Item
    {
        public string effect;
        public Herb(string name, string effect) : base(name)
        {
            this.effect = effect;
        }

        
    }
}
