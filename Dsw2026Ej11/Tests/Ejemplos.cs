namespace Dsw2026Ej11.Tests;


using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;
using global::Dsw2026Ej11.Collections;
using global::Dsw2026Ej11.Domain;
using System;
using System.Collections.Generic;

internal class Ejemplos
{
    public static void EjemploList()
    {
        Console.WriteLine("=== EJEMPLO LIST ===");
        CasoList casoList = new CasoList();

        Alumno alumno1 = new Alumno(1, "Martina", 8.5);
        Alumno alumno2 = new Alumno(2, "Pablo", 6.0);
        Alumno alumno3 = new Alumno(3, "Lucia", 9.2);

        casoList.AgregarAlumno(alumno1);
        casoList.AgregarAlumno(alumno2);
        casoList.AgregarAlumno(alumno3);

        Console.WriteLine("Lista de alumnos:");
        foreach (var a in casoList.ObtenerLista()) Console.WriteLine(a);

        Console.WriteLine("\nBuscando a 'Pablo':");
        Alumno encontrado = casoList.BuscarPorNombre("Pablo");
        Console.WriteLine(encontrado != null ? encontrado.ToString() : "No existe");

        Console.WriteLine("\nBuscando a 'Carlos':");
        Alumno noEncontrado = casoList.BuscarPorNombre("Carlos");
        Console.WriteLine(noEncontrado != null ? noEncontrado.ToString() : "No existe");

        Console.WriteLine("\nEliminando a 'Marta'...");
        casoList.EliminarAlumno(alumno1);
        foreach (var a in casoList.ObtenerLista()) Console.WriteLine(a);

        Console.WriteLine("\nEliminando el primer elemento (Posición 0)...");
        casoList.EliminarEnPosicion(0);
        foreach (var a in casoList.ObtenerLista()) Console.WriteLine(a);
    }

    public static void EjemploDictionary()
    {
        Console.WriteLine("\n=== EJEMPLO DICTIONARY ===");
        CasoDictionary casoDict = new CasoDictionary();
        casoDict.AgregarAlumno(1001, new Alumno(1001, "Sofia", 7.5));
        casoDict.AgregarAlumno(1002, new Alumno(1002, "Diego", 8.0));
        casoDict.AgregarAlumno(1003, new Alumno(1003, "Ana", 9.8));

        Console.WriteLine("Lista de alumnos en diccionario:");
        foreach (var kvp in casoDict.ObtenerDiccionario())
        {
            // kvp.Value es el Alumno, se imprime con el formato de ToString()
            Console.WriteLine($"- Clave: {kvp.Key} | Dato: {kvp.Value}");
        }

        Console.WriteLine("\nBuscando legajo 1002:");
        Alumno encontrado = casoDict.BuscarPorClave(1002);
        Console.WriteLine(encontrado != null ? encontrado.ToString() : "No existe");

        Console.WriteLine("\nBuscando legajo 9999:");
        Alumno noEncontrado = casoDict.BuscarPorClave(9999);
        Console.WriteLine(noEncontrado != null ? noEncontrado.ToString() : "No existe");

        Console.WriteLine("\nEliminando legajo 1001...");
        casoDict.EliminarAlumno(1001);
        foreach (var kvp in casoDict.ObtenerDiccionario())
        {
            Console.WriteLine($"- Clave: {kvp.Key} | Dato: {kvp.Value}");
        }
    }

    public static void EjemploLinq()
    {
        Console.WriteLine("\n=== EJEMPLO LINQ ===");

        List<Libro> catalogo = Libro.CrearLista();
        CasoLinq casoLinq = new CasoLinq(catalogo);

        Console.WriteLine($"1. Primer libro: {casoLinq.GetPrimero()?.Titulo}");
        Console.WriteLine($"2. Último libro: {casoLinq.GetUltimo()?.Titulo}");
        Console.WriteLine($"3. Total precios: {casoLinq.GetTotalPrecios():C2}");
        Console.WriteLine($"4. Promedio de precios: {casoLinq.GetPromedioPrecios():C2}");

        Console.WriteLine("5. Libros con Id > 15:");
        foreach (var libro in casoLinq.GetListById()) Console.WriteLine($"   - [{libro.Id}] {libro.Titulo}");

        Console.WriteLine("6. Lista formateada:");
        foreach (var item in casoLinq.GetLibros()) Console.WriteLine($"   - {item}");

        Console.WriteLine($"7. Mayor precio: {casoLinq.GetMayorPrecio()?.Titulo} ({casoLinq.GetMayorPrecio()?.Precio:C2})");
        Console.WriteLine($"8. Menor precio: {casoLinq.GetMenorPrecio()?.Titulo} ({casoLinq.GetMenorPrecio()?.Precio:C2})");

        Console.WriteLine("9. Libros por encima del promedio:");
        foreach (var libro in casoLinq.GetMayorPromedio()) Console.WriteLine($"   - {libro.Titulo}");

        Console.WriteLine("10. Libros ordenados (Z-A) (Mostrando los primeros 5 para no saturar la consola):");

        var ordenados = casoLinq.GetOrdenadosPorTituloDescendente();
        for (int i = 0; i < Math.Min(5, ordenados.Count); i++)
        {
            Console.WriteLine($"   - {ordenados[i].Titulo}");
        }
    }
}