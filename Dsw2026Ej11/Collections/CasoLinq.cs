namespace Dsw2026Ej11.Collections;

/*
 * Para cada punto crear un método que permita:
 * 1. Obtener el primer libro (GetPrimero)
 * 2. Obtener el último libro (GetUltimo)
 * 3. Obtener la suma de precios (GetTotalPrecios)
 * 4. Obtener el promedio de precios (GetPromedioPrecios)
 * 5. Obtener la lista de libros con Id mayor a 15 (GetListById)
 * 6. Obtener una lista de cada libro con su título y precio en formato moneda (GetLibros) (debe retornar una lista de string)
 * 7. Obtener el libro con el precio más alto (GetMayorPrecio)
 * 8. Obtener el libro con el precio más bajo (GetMenorPrecio)
 * 9. Obtener los libros cuyo precio sea mayor al promedio (GetMayorPromedio)
 * 10. Obtener los libros ordenados por título de forma descendente
 * En todos los casos debe aplicarse LINQ
 */

using Dsw2026Ej11.Domain;
using System;
using System.Collections.Generic;
using System.Linq;



public class CasoLinq
{
    private List<Libro> _libros;

    public CasoLinq(List<Libro> libros)
    {
        _libros = libros ?? new List<Libro>();
    }

    // 1. Obtener el primer libro
    public Libro GetPrimero()
    {
        return _libros.FirstOrDefault();
    }

    // 2. Obtener el último libro
    public Libro GetUltimo()
    {
        return _libros.LastOrDefault();
    }

    // 3. Obtener la suma de precios
    public decimal GetTotalPrecios()
    {
        return _libros.Sum(libro => libro.Precio);
    }

    // 4. Obtener el promedio de precios
    public decimal GetPromedioPrecios()
    {
        return _libros.Any() ? _libros.Average(libro => libro.Precio) : 0;
    }

    // 5. Obtener la lista de libros con Id mayor a 15
    public List<Libro> GetListById()
    {
        return _libros.Where(libro => libro.Id > 15).ToList();
    }

    // 6. Obtener una lista de cada libro con su título y precio en formato moneda
    public List<string> GetLibros()
    {
        //C2 es usada para el formato moneda.
        return _libros.Select(libro => $"{libro.Titulo} - {libro.Precio:C2}").ToList();
    }

    // 7. Obtener el libro con el precio más alto
    public Libro GetMayorPrecio()
    {
        return _libros.OrderByDescending(libro => libro.Precio).FirstOrDefault();
    }

    // 8. Obtener el libro con el precio más bajo
    public Libro GetMenorPrecio()
    {
        return _libros.OrderBy(libro => libro.Precio).FirstOrDefault();
    }

    // 9. Obtener los libros cuyo precio sea mayor al promedio
    public List<Libro> GetMayorPromedio()
    {
        decimal promedio = GetPromedioPrecios();
        return _libros.Where(libro => libro.Precio > promedio).ToList();
    }

    // 10. Obtener los libros ordenados por título de forma descendente
    public List<Libro> GetOrdenadosPorTituloDescendente()
    {
        return _libros.OrderByDescending(libro => libro.Titulo).ToList();
    }

}

