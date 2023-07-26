using System;
using System.Collections.Generic;

class Persona
{
  //------------PROPIEDADES DE LA CLASE -----------
  public string NombrePersona { get; set; }
  public string EdadPersona { get; set; }
  public List<string> HobbiePersona { get; set; }

  public Persona(string nombre, string edad, List<string> hobbies)
  {
    NombrePersona = nombre;
    EdadPersona = edad;
    HobbiePersona = hobbies;
  }
}
class Program
{

  private static Dictionary<string, Persona> miDiccionario = new Dictionary<string, Persona>();

  private const string separador = "----------------------------------------------------------";
  private const string registroVacio = "\nEl Registro está Vacío... ";
  private const string opcionInvalida = "\nOpción inválida. Intente nuevamente... ";
  private const string noExiste = "\nPersona no existe... ";
  private const string usuarioAgregado = "\nUsuario agregado correctamente... ";
  private const string usuarioEliminado = "\nUsuario eliminado correctamente... ";

  static void Main()
  {

    bool ejecutar = true;
    while (ejecutar)
    {
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.Clear();
      Console.WriteLine("------- SISTEMA DE REGISTRO DE USUARIOS -------\n");
      Console.WriteLine("1. Agregar Usuario\n2. Mostrar Usuario por Id\n3. Mostrar todos los Usuarios\n4. Eliminar Usuario\n0. Salir");
      Console.Write("\nElija una opción: ");
      Console.ResetColor();
      string opcion = Console.ReadLine() ?? "";

      if (!string.IsNullOrEmpty(opcion))
      {

        Console.ForegroundColor = ConsoleColor.Blue;
        switch (opcion)
        {
          case "1":
            Console.Clear();
            agregarUsuario();
            break;
          case "2":
            Console.Clear();
            mostrarUsuarioPorId();
            break;
          case "3":
            Console.Clear();
            mostrarTodosLosUsuarios();
            break;
          case "4":
            Console.Clear();
            eliminarUsuario();
            break;
          case "0":
            Console.Clear();
            Console.WriteLine("           ---------------------------");
            Console.WriteLine("----------| Saliste del Programa..... |----------");
            Console.WriteLine("           ---------------------------");
            ejecutar = false;
            break;
          default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(opcionInvalida);
            Thread.Sleep(1500);
            break;
        }

      }
      else
      {
        Console.Write(opcionInvalida);
        Thread.Sleep(1500);
      }
    }
  }
  static void agregarUsuario()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("----------------------- NUEVO USUARIO ----------------------\n");
    Console.Write("Número Identificacion: ");
    Console.ResetColor();
    string id = Console.ReadLine() ?? "";

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Nombre Completo: ");
    Console.ResetColor();
    string nombre = Console.ReadLine() ?? "";

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Edad: ");
    Console.ResetColor();
    string edad = Console.ReadLine() ?? "";

    if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(edad))
    {

      List<string> hobbies = new List<string>();
      bool agregarHobby = true;

      do
      {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Hobbies: ");
        Console.ResetColor();
        hobbies.Add(Console.ReadLine() ?? "");

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("\n¿Agregar otro hobbie? (N/n para cancelar)  ");

        if ((Console.ReadLine() ?? "").ToUpper() == "N")
        {
          agregarHobby = false;
        }
      } while (agregarHobby);

      miDiccionario.Add(id, new Persona(nombre, edad, hobbies));
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(usuarioAgregado);
      Thread.Sleep(1500);

    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write("Alguos Campos Estan Vacios");
      Thread.Sleep(1500);
    }

  }


  static void mostrarUsuarioPorId()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("----------------------- USUARIO POR ID ----------------------\n");
    if (miDiccionario.Count != 0)
    {

      Console.Write("Id Persona a Mostrar: ");
      string idM = Console.ReadLine() ?? "";

      if (!string.IsNullOrEmpty(idM))
      {
        if (miDiccionario.ContainsKey(idM ??= ""))
        {

          Console.WriteLine("\nID\tNombre\t\tEdad\t\tHobbies");
          Console.WriteLine(separador);
          string hobbies = string.Join(" - ", miDiccionario[idM ??= ""].HobbiePersona);
          Console.WriteLine($"{idM}\t{miDiccionario[idM].NombrePersona}\t{miDiccionario[idM].EdadPersona} años\t\t{hobbies}");
          Console.WriteLine(separador);
          continuar();

        }
        else
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.Write(noExiste);
          Thread.Sleep(1500);
        }

      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(opcionInvalida);
        Thread.Sleep(1500);
      }
    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(registroVacio);
      Thread.Sleep(1500);
    }
  }


  static void mostrarTodosLosUsuarios()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("----------------------- TODOS LOS USUARIOS ----------------------\n");
    if (miDiccionario.Count != 0)
    {
      Console.WriteLine("ID\tNombre\t\tEdad\t\tHobbies");
      Console.WriteLine("__________________________________________________________");

      Console.ResetColor();
      foreach (var usuario in miDiccionario)
      {
        string hobbies = string.Join(" - ", usuario.Value.HobbiePersona);
        Console.WriteLine($"{usuario.Key}\t{usuario.Value.NombrePersona}\t{usuario.Value.EdadPersona} años\t\t{hobbies}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(separador);
        Console.ResetColor();

      }

      continuar();

    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(registroVacio);
      Thread.Sleep(1500);
    }
  }


  static void eliminarUsuario()
  {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("Id Persona Eliminar: ");
    string idRemove = Console.ReadLine() ?? "";

    if (!string.IsNullOrEmpty(idRemove) && miDiccionario.Remove(idRemove))
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine(usuarioEliminado);
      Thread.Sleep(1500);
    }
    else
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.Write(noExiste);
      Thread.Sleep(1500);
    }
  }

  static void continuar()
  {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("\nPresione Una tecla para Continuar  ");
    Console.ReadKey();
  }
}