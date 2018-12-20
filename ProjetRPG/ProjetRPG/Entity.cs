using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetRPG
{
    class Entity
    {
        protected string name;
        public int posX;
        public int posY;

        public Entity(string name)
        {
            this.name = name;
        }

        public Entity(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;
        }

        //getter setter
        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }

    }
}
