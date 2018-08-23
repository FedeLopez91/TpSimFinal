using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simlib
{
    public class RndValor<T>
    {
        public double Random { get;protected set; }
        public T Valor  { get;protected set; }
        public RndValor(double rnd, T valor)
        {
            this.Valor = valor;
            this.Random = rnd;
        }
    }
}
