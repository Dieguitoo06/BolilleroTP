using System;
using System.Collections.Generic;
using System.Linq;

public class Bolillero : ICloneable
{
    private List<int> bolitas;
    private List<int> bolillasFuera;
    private Random random;

    public Bolillero(int rango)
    {
        bolitas = Enumerable.Range(0, rango).ToList();
        bolillasFuera = new List<int>();
        random = new Random();
    }

    public int SacarBolilla()
    {
        int indice = random.Next(bolitas.Count);
        int bolilla = bolitas[indice];
        bolitas.RemoveAt(indice);
        bolillasFuera.Add(bolilla);
        return bolilla;
    }

    public void ReIngresar()
    {
        bolitas.AddRange(bolillasFuera);
        bolillasFuera.Clear();
    }

    public bool Jugar(List<int> jugada)
    {
        ReIngresar();
        foreach (var numero in jugada)
        {
            if (SacarBolilla() != numero)
                return false;
        }
        return true;
    }

    public long JugarNVeces(List<int> jugada, int cantidad)
    {
        long aciertos = 0;
        for (int i = 0; i < cantidad; i++)
        {
            if (Jugar(jugada))
                aciertos++;
        }
        return aciertos;
    }

    public object Clone()
    {
        var clon = new Bolillero(0)
        {
            bolitas = new List<int>(this.bolitas),
            bolillasFuera = new List<int>(this.bolillasFuera),
            random = new Random()
        };
        return clon;
    }
}
