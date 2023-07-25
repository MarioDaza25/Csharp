
using System;
using System.Collections.Generic;

 //------------------------------------------ CLASE PARA CREAR UN OBJETO POR CADA CONTACTO ----------------------------------\\
//----------------------------------------------------------------------------------------------------------------------------\\

class LibretaTelefonica
{   
    //------------PROPIEDADES DE LA CLASE -----------
    public string nombrePersona { get; set; }
    public string telefono { get; set; }
    public bool esImportante { get; set; }
    
    public LibretaTelefonica(string nombre, string numeroTelefono)
    {
        nombrePersona = nombre;
        telefono = numeroTelefono;
        esImportante = false;
    }
}
    //-------------------------------------------------------- CLASE PRINCIPAL ------------------------------------------------\\
    //---------------------------------------------------------------------------------------------------------------------------\\
class Program
{
    static List<LibretaTelefonica> directorioTel = new List<LibretaTelefonica>();

    static void Main()
    {
        bool ejecutar = true;
        while (ejecutar)
        { 
            Console.Clear();
            Console.WriteLine("------- Libreta Telefónica -------\n");
            Console.WriteLine("1. Agregar Contacto\n2. Mostrar todos los Contactos\n3. Marcar Contacto como Favorito\n4. Eliminar Contacto\n0. Salir");
            Console.Write("Elija una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Clear();
                    nuevoContacto();
                    break;
                case 2:
                    Console.Clear();
                    mostrarContactos();
                    continuar();
                    break;
                case 3:
                    Console.Clear();
                    contactosFavoritos();
                    break;
                case 4:
                    Console.Clear();
                    eliminarContacto();
                    break;
                case 0:
                    Console.Clear();
                    Console.WriteLine("           ---------------------------");
                    Console.WriteLine("----------| Saliste del Programa..... |----------");
                    Console.WriteLine("           ---------------------------");
                    ejecutar = false;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }   

    //-------------------------------------------------- METODOS DE LA CLASE PROGRAM ------------------------------------------\\
    //--------------------------------------------------------------------------------------------------------------------------\\
    

                       //----------------------------------- AGREGAR CONTACTOS -----------------------------------

    static void nuevoContacto()
    {
        Console.WriteLine("------- Agregar Nuevo Contacto -------\n");
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Ingrese el número de teléfono: ");
        string numeroTelefono = Console.ReadLine();

        directorioTel.Add(new LibretaTelefonica(nombre, numeroTelefono));
        Console.WriteLine("Contacto agregado correctamente.");
    }

                      //----------------------------------- MOSTRAR CONTACTOS -----------------------------------

    static void mostrarContactos()
    {
        if (directorioTel.Count == 0)
        {
            Console.WriteLine("La libreta telefónica está vacía.");
        }
        else
        {   
            int contador = 1;
            Console.WriteLine("------- Todas los Contactos -------\n");
            foreach (var Contacto in directorioTel)
            {
                string importante = Contacto.esImportante ? "★" : " ";
                Console.WriteLine($"{contador++}) Nom: {Contacto.nombrePersona}  | Fav: {importante} |\n    ☎ : {Contacto.telefono}");
                Console.WriteLine("-----------------------------------");
            }
        }
    }

                      //----------------------------------- CONTACTOS IMPORTANTES -----------------------------------

    static void contactosFavoritos()
    {
        mostrarContactos();
        Console.Write("\nIngrese el índice del Contacto Importante: ");
        int indice = int.Parse(Console.ReadLine());

        if (indice >= 1 && indice-1 < directorioTel.Count)
        {
            directorioTel[indice-1].esImportante = true;
            Console.WriteLine("\n***Contacto marcado como importante.***");
            continuar();
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

                      //----------------------------------- ELIMINAR CONTACTO -----------------------------------

    static void eliminarContacto()
    {
        Console.WriteLine("------- Eliminar Contacto -------\n");
        Console.Write("Ingrese el índice del  contacto a eliminar: ");
        int indice = int.Parse(Console.ReadLine());

        if (indice >= 0 && indice < directorioTel.Count)
        {
            directorioTel.RemoveAt(indice);
            Console.WriteLine("Contacto eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("Índice inválido.");
        }
    }

                      //----------------------------------- METODO CONTINUAR -----------------------------------
    static void continuar()
    {
      Console.Write("\nPresiones Cualquier tecla para Salir ");
      Console.ReadLine();
    }
}


