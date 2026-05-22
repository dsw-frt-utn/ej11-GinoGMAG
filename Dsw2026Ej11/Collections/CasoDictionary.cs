namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave


using Dsw2026Ej11.Domain;
using System;
using System.Collections.Generic;


public class CasoDictionary
{
    private Dictionary<int, Alumno> _diccionarioAlumnos = new Dictionary<int, Alumno>();

    public bool AgregarAlumno(int legajo, Alumno alumno)
    {
        // Si el legajo ya existe en el diccionario, no hace nada y devuelve 'false' 
        return _diccionarioAlumnos.TryAdd(legajo, alumno);
    }

    public Alumno BuscarPorClave(int legajo)
    {
        if (_diccionarioAlumnos.TryGetValue(legajo, out Alumno alumnoEncontrado))
        {
            return alumnoEncontrado;
        }
        return null;
    }

    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        return _diccionarioAlumnos;
    }

    public bool EliminarAlumno(int legajo)
    {
        return _diccionarioAlumnos.Remove(legajo);
    }

}