using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    // Lista de tareas
    static List<string> tareas = new List<string>();

    // Método principal que maneja el menú
    static void Main(string[] args)
    {
        while (true)
        {
            MostrarMenu();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    MostrarTareas();
                    break;
                case "3":
                    GuardarTareasEnArchivo();
                    break;
                case "4":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción no válida. Por favor, elija una opción entre 1 y 4.");
                    break;
            }
        }
    }

    // Muestra el menú
    static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("Gestión de Tareas");
        Console.WriteLine("1. Agregar tarea");
        Console.WriteLine("2. Mostrar tareas");
        Console.WriteLine("3. Guardar tareas en archivo");
        Console.WriteLine("4. Salir");
        Console.Write("Elija una opción: ");
    }

    // Permite agregar una tarea a la lista
    static void AgregarTarea()
    {
        Console.Clear();
        Console.Write("Ingrese la descripción de la nueva tarea: ");
        string tarea = Console.ReadLine();
        tareas.Add(tarea);
        Console.WriteLine("Tarea agregada exitosamente. Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Muestra todas las tareas en la lista
    static void MostrarTareas()
    {
        Console.Clear();
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas en la lista.");
        }
        else
        {
            Console.WriteLine("Tareas:");
            for (int i = 0; i < tareas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tareas[i]}");
            }
        }
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    // Guarda las tareas en un archivo de texto
    static void GuardarTareasEnArchivo()
    {
        Console.Clear();
        Console.Write("Ingrese el nombre del archivo para guardar las tareas: ");
        string nombreArchivo = Console.ReadLine();

        try
        {
            File.WriteAllLines(nombreArchivo, tareas);
            Console.WriteLine($"Tareas guardadas exitosamente en el archivo {nombreArchivo}. Presione cualquier tecla para continuar...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al guardar el archivo: {ex.Message}");
        }
        Console.ReadKey();
    }
}
