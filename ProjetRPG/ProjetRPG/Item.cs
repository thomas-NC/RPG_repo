using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    abstract class Item
    {
        protected string name;

        public Item(string name)
        {
            this.name = name;
        }

        //getters setters
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

        //public void SetTypeObject(string type)
        //{
        //    this.typeObject = type;
        //}
        //public string GetTypeObject()
        //{
        //    return this.typeObject;
        //}
    }
}
