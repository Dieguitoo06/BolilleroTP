using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bolillerito
{
    public class Simulacion
    {
        public long SimularSinHilos(Bolillero bolillero, List<int> jugada, int cantidad)
        {
            long ganadas = 0;
            for (int i = 0; i < cantidad; i++)
            {
                if (bolillero.Jugar(jugada)) ganadas++;
            }
            return ganadas;
        }
        private static long EjecutarSimulaciones(Bolillero bolillero, List<int> jugada, int cantidad)
        {
            long ganadas = 0;
            var clon = (Bolillero)bolillero.Clone();
            for (int j = 0; j < cantidad; j++)
            {
                if (clon.Jugar(jugada)) ganadas++;
            }
            return ganadas;
        }

        public long SimularConHilos(Bolillero bolillero, List<int> jugada, int cantidad, int cantidadHilos)
        {
            int simulacionesPorHiloBase = cantidad / cantidadHilos;
            int simulacionesExtra = cantidad % cantidadHilos;
            var tareas = new List<Task<long>>();

            for (int i = 0; i < cantidadHilos; i++)
            {
                int simulacionesEsteHilo = simulacionesPorHiloBase + (i < simulacionesExtra ? 1 : 0);
                tareas.Add(Task.Run(() =>
                {
                    return EjecutarSimulaciones(bolillero, jugada, simulacionesEsteHilo);
                }));
            }

            Task.WaitAll(tareas.ToArray());
            return tareas.Sum(t => t.Result);
        }

        public async Task<long> SimularConHilosAsync(Bolillero bolillero, List<int> jugada, int cantidad, int cantidadHilos)
        {
            int simulacionesPorHiloBase = cantidad / cantidadHilos;
            int simulacionesExtra = cantidad % cantidadHilos;

            var tareas = Enumerable.Range(0, cantidadHilos)
                .Select(i =>
                {
                    int repeticiones = simulacionesPorHilosBase + (i < simulacionesExtra ? 1 : 0);
                    return Task.Run(() => EjecutarSimulaciones(bolillero, jugada, repeticiones));
                })
                .ToArray();

            var resultados = await Task.WhenAll(tareas);
            return resultados.Sum();
        }
    }
}