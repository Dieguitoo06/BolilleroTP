using Bolillerito;
using System.Collections.Generic;
using Xunit;

namespace Bolillerito.Tests
{
    public class SimulacionTests
    {
        private Bolillero CrearBolillero() => new Bolillero(10);

        private List<int> CrearJugadaGanadoraPosible() => new List<int> { 0, 1, 2 };

        [Fact]
        public void SimularSinHilos_DeberiaRetornarNumeroDeGanadas()
        {
            var bolillero = CrearBolillero();
            var jugada = CrearJugadaGanadoraPosible();
            var simulacion = new Simulacion();
            int cantidadSimulaciones = 1000;

            long ganadas = simulacion.SimularSinHilos(bolillero, jugada, cantidadSimulaciones);

            Assert.InRange(ganadas, 0, cantidadSimulaciones);
        }

        [Fact]
        public void SimularConHilos_DeberiaRetornarNumeroDeGanadas()
        {
            var bolillero = CrearBolillero();
            var jugada = CrearJugadaGanadoraPosible();
            var simulacion = new Simulacion();
            int cantidadSimulaciones = 1000;
            int cantidadHilos = 4;

            long ganadas = simulacion.SimularConHilos(bolillero, jugada, cantidadSimulaciones, cantidadHilos);

            Assert.InRange(ganadas, 0, cantidadSimulaciones);
        }

        [Fact]
        public void Simulaciones_ConYSinHilos_DebenSerSimilares()
        {
            var bolillero1 = CrearBolillero();
            var bolillero2 = CrearBolillero();
            var jugada = CrearJugadaGanadoraPosible();
            var simulacion = new Simulacion();
            int cantidadSimulaciones = 10000;

            long sinHilos = simulacion.SimularSinHilos(bolillero1, jugada, cantidadSimulaciones);
            long conHilos = simulacion.SimularConHilos(bolillero2, jugada, cantidadSimulaciones, 4);

            Assert.InRange(sinHilos, conHilos - 100, conHilos + 100);
        }
    }
}
