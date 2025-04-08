using Bolillero;

namespace TestBolillero
{
    public class TestBolillero
    {
        public Bolillerox Bolillero;

        public TestBolillero()
        {
            Bolillero = new Bolillerox(10, new Primero());
        }

        [Fact]
        public void SacarBolilla()
        {
            int bolilla = Bolillero.SacarBolilla();
            Assert.Equal(0, bolilla);
            Assert.Equal(9, Bolillero.CantidadAdentro);
            Assert.Equal(1, Bolillero.CantidadAfuera);
        }

        [Fact]
        public void ReIngresar()
        {
            Bolillero.SacarBolilla();
            Bolillero.ReIngresar();
            Assert.Equal(10, Bolillero.CantidadAdentro);
            Assert.Equal(0, Bolillero.CantidadAfuera);
        }

        [Fact]
        public void JugarGana()
        {
            var jugada = new List<int> { 0, 1, 2, 3 };
            var bolillero = new Bolillerox(10, new Secuencia());
            Assert.True(bolillero.Jugar(jugada));
        }

        [Fact]
        public void JugarPierde()
        {
            var jugada = new List<int> { 4, 2, 1 };
            Assert.False(Bolillero.Jugar(jugada));
        }

        [Fact]
        public void GanarNVeces()
        {
            var jugada = new List<int> { 0, 1, };
            var bolillero = new Bolillerox(10, new Secuencia());
            int ganadas = bolillero.JugarNVeces(jugada, 1);
            Assert.Equal(1, ganadas);
        }
    }


}