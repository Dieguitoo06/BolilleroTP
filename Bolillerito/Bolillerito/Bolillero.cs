using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillerito
{
    public class Bolillero
    {
        public List<int> dentro;
        public List<int> fuera;
        public IAzar azar;

        public Bolillero(int cantidad, IAzar azar)
        {
            this.azar = azar;
            dentro = Enumerable.Range(0, cantidad).ToList();
            fuera = new List<int>();
        }

        public int SacarBolilla()
        {
            int index = azar.ObtenerIndice(dentro.Count);
            int bolilla = dentro[index];
            dentro.RemoveAt(index);
            fuera.Add(bolilla);
            return bolilla;
        }

        public void ReIngresar()
        {
            dentro.AddRange(fuera);
            fuera.Clear();
        }

        public bool Jugar(List<int> jugada)
        {
            ReIngresar();
            foreach (int esperado in jugada)
            {
                int sacada = SacarBolilla();
                if (sacada != esperado)
                    return false;
            }
            return true;
        }

        public int JugarNVeces(List<int> jugada, int cantidad)
        {
            int ganadas = 0;
            object candado = new object();
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < cantidad; i++)
            {
                var t = new Thread(() =>
                {
                    var bolilleroLocal = new Bolillero(10, new Primero());

                    if (bolilleroLocal.Jugar(jugada))
                    {
                        lock (candado)
                        {
                            ganadas++;
                        }
                    }
                });
                threads.Add(t);
                t.Start();
            }

            foreach (var t in threads)
            {
                t.Join();
            }

            return ganadas;
        }
        public int CantidadDentro() => dentro.Count;
        public int CantidadFuera() => fuera.Count;
    }

}
