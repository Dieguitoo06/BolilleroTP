using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillerito
{
    public class RandomAzar : IAzar
    {
        public Random random = new Random();
        public int ObtenerIndice(int maximo) => random.Next(maximo);
    }

    public class Primero : IAzar
    {
        public int ObtenerIndice(int maximo) => 0;
    }

}
