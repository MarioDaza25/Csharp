using System;

namespace CaballoAjedrez
{
    internal class Program
    {
        static void Main(string[] args)
        {
          // Definimos el tablero con un tamaño de 8x8
          int filas = 8;
          int columnas = 8;
          char[,] tablero = new char[filas, columnas];

          //Llenamos el tablero con Cuadros para todas las posiciones
          for (int i = 0; i < filas; i++)
          {
              for (int j = 0; j < columnas; j++)
              {
                  tablero[i, j] = (i + j) % 2 == 0 ?'⬜':'⬛';
              }
          }
          
          //Posicion del Caballo entre 1-8 (fila, columna) 
          int cabFila = 4;
          int cabColumna = 4;

          // Marcamos la posición del caballo en el tablero con una "X"
          tablero[(cabFila-1), (cabColumna-1)] = '❌';

          // Array de los posibles movimientos del caballo
          int[] movFila = { 2, 1, -1, -2, -2, -1, 1, 2 };
          int[] movColm = { 1, 2, 2, 1, -1, -2, -2, -1 };

          // Buscamos los posibles movimientos del caballo
          for (int i = 0; i < filas; i++)
          {
            int newRow = (cabFila-1) + movFila[i];
            int newCol = (cabColumna-1) + movColm[i];

            // Verificamos si el movimiento está dentro del tablero
            if (newRow >= 0 && newRow < filas && newCol >= 0 && newCol < columnas)
            {
              // Marcamos los posibles movimientos del Caballo
              tablero[newRow, newCol] = '❎';
            }
          }

          // Mostramos el tablero Final
          for (int i = 0; i < filas; i++)
          {
            for (int j = 0; j < columnas; j++)
            {
              Console.Write( tablero[i, j]);
            }
              Console.WriteLine();
          }
        }
    }
};
