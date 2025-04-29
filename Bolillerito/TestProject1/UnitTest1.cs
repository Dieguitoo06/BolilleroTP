using Xunit;
using System.Collections.Generic;

namespace Bolillerito;

public class UnitTest1
{
    private Bolillero bolillero;
    private List<int> jugada;
    private Simulacion simulacion;

    public UnitTest1()
    {
        bolillero = new Bolillero(10);
        jugada = new List<int> { 0, 1, 2, 3 };
        simulacion = new Simulacion();
    }

    [Fact]
    public void SimularSinHilos()
    {
        int cantidadSimulaciones = 1000;
        long ganadas = simulacion.SimularSinHilos(bolillero, jugada, cantidadSimulaciones);
        Assert.InRange(ganadas, 0, cantidadSimulaciones);
    }

    [Fact]
    public void SimularConHilos()
    {
        int cantidadSimulaciones = 1000;
        int cantidadHilos = 4;
        long ganadas = simulacion.SimularConHilos(bolillero, jugada, cantidadSimulaciones, cantidadHilos);
        Assert.InRange(ganadas, 0, cantidadSimulaciones);
    }

    [Fact]
    public void Simulaciones_ConySinHilos()
    {
        var bolillero1 = new Bolillero(10);
        var bolillero2 = new Bolillero(10);
        int cantidadSimulaciones = 10000;

        long sinHilos = simulacion.SimularSinHilos(bolillero1, jugada, cantidadSimulaciones);
        long conHilos = simulacion.SimularConHilos(bolillero2, jugada, cantidadSimulaciones, 4);

        Assert.InRange(sinHilos, conHilos - 100, conHilos + 100);
    }
}
