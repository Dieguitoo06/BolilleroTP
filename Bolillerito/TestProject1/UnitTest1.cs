using Bolillerito;

namespace TestProject1
{
    public class BolilleroTests
    {
        public Bolillero bolillero;

        public BolilleroTests()
        {
            bolillero = new Bolillero(10, new Primero());
        }

        [Fact]
        public void SacarBolilla()
        {
            int bolilla = bolillero.SacarBolilla();
            Assert.Equal(0, bolilla);
            Assert.Equal(9, bolillero.CantidadDentro());
            Assert.Equal(1, bolillero.CantidadFuera());
        }

        [Fact]
        public void ReIngresar()
        {
            bolillero.SacarBolilla();
            bolillero.ReIngresar();
            Assert.Equal(10, bolillero.CantidadDentro());
            Assert.Equal(0, bolillero.CantidadFuera());
        }

        [Fact]
        public void JugarGana()
        {
            var jugada = new List<int> { 0, 1, 2, 3 };
            bool gano = bolillero.Jugar(jugada);
            Assert.True(gano);
        }

        [Fact]
        public void JugarPierde()
        {
            var jugada = new List<int> { 4, 2, 1 };
            bool gano = bolillero.Jugar(jugada);
            Assert.False(gano);
        }

        [Fact]
        public void GanarNVeces()
        {
            var jugada = new List<int> { 0, 1 };
            int ganadas = bolillero.JugarNVeces(jugada, 1);
            Assert.Equal(1, ganadas);
        }

        [Fact]
        public void GanarNVecesConThreads()
        {
            var jugada = new List<int> { 0, 1 };
            int ganadas = bolillero.JugarNVeces(jugada, 3);
            Assert.Equal(3, ganadas);
        }
    }

}