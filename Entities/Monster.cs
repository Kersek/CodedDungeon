using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedDungeon.Entities
{
    public class Monster : Entity
    {


        public Monster()
        {
            Health = 50;
            Strenght = 5;
            Exp = 10;
        }
    }
}
