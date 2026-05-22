namespace Dsw2026Ej11.Collections;

//Crear un campo que represente una lista de alumnos (List<>)
//Incluir un método para agregar alumnos a la lista
//Incluir un método para retornar la lista
//Incluir un método para buscar un alumno por nombre
//Incluir un método para eliminar un alumno (debe recibir un alumno)
//Incluir un método para eliminar un alumno en una determinada posición de la lista

using Dsw2026Ej11.Domain;
using System;
using System.Collections.Generic;
using System.Linq;


public class CasoList
{
    private List<Alumno> _alumnos = new List<Alumno>();

    public void AgregarAlumno(Alumno alumno)
    {
        _alumnos.Add(alumno);
    }

    public List<Alumno> ObtenerLista()
    {
        return _alumnos;
    }

    public Alumno BuscarPorNombre(string nombre)
    {
        return _alumnos.FirstOrDefault(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    public bool EliminarAlumno(Alumno alumno)
    {
        return _alumnos.Remove(alumno);
    }

    public void EliminarEnPosicion(int indice)
    {
        //verifica que el índice sea válido antes de intentar eliminar
        if (indice >= 0 && indice < _alumnos.Count)
        {
            _alumnos.RemoveAt(indice);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(indice), "La posición indicada no existe en la lista.");
        }
    }

}