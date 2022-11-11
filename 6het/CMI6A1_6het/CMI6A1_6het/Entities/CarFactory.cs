using CMI6A1_6het.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMI6A1_6het.Entities
{
    public class CarFactory :IToyFactory
    {
        public Toy CreateNew()
        {
            return new Ball();
        }
    }
}
