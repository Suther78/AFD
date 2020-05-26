using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FSM_Simple
{
    internal class Program{
        
      public static void Main(string[] args){
           
            int contador = 0;
            int contador2 = 0;
            int contador3 = 0;
            int contador4 = 0;
            Console.Write("Ingrese la cantidad de estados: ");
            contador=int.Parse(Console.ReadLine());
            
            if (contador >= 10)
            {
                Console.Write("Numero de estados muy alto");
            }
            else
            {
                var Q = new List<string>();
                for (int i = 0; i < contador; i++)
                {
                    
                    Console.Write("Ingresa el estado: ");
                    string estado = Console.ReadLine();
                    Console.WriteLine(@"    -     ");
                    Console.WriteLine(@"  /   \   ");
                    Console.WriteLine(@" |  q"+i.ToString()+" |");
                    Console.WriteLine(@"  \   /   ");
                    Console.WriteLine(@"    -     ");
                    Q.Add(estado);
                }
                
                var Sigma = new List<char>();
                Console.Write("Ingrese la cantidad de simbolos de alfabeto: ");
                contador3 = int.Parse(Console.ReadLine());
                for (int i = 0; i < contador3; i++)
                {
                    Console.Write("Ingresa el simbolo del alfabeto: ");
                    char letras = char.Parse(Console.ReadLine());
                    Sigma.Add(letras);
                    
                }
                Console.Clear();
                Console.Write("Ingrese la cantidad de transiciones: ");
                contador2 = int.Parse(Console.ReadLine());
                var Delta = new List<Transition>();
                for (int i = 0; i < contador2; i++)
                {
                    Console.Write("Ingresa tu origen: ");
                    string origen = Console.ReadLine();
                    Console.Write("Ingresa con que te moveras: ");
                    char tok = char.Parse(Console.ReadLine());
                    if (Sigma.Contains(tok))
                    {
                        Console.Write("Ingresa el destino: ");
                        string Destino = Console.ReadLine();
                        Delta.Add(new Transition(origen, tok, Destino));
                        Console.WriteLine(@"---------->| " + origen + " |" + "-----------------------------" + tok + "------------------> " + "| " + Destino + " |");

                    }
                    else
                    {
                        Console.Write("No se cuenta con ese simbolo del alfabeto");
                        Environment.Exit(0);
                    }

                }
                Console.Clear();
                var Q0 = "q0";
                Console.Write("Ingresa la cantidad de estados de finalizacion: ");
                contador4 = int.Parse(Console.ReadLine());
                var F = new List<string>();
                for (int i = 0; i < contador4; i++)
                {
                    Console.Write("Ingresa los estados de aceptacion(q+numero): ");
                    string estado_fin = Console.ReadLine();
                    F.Add(estado_fin);
                }
                
                Console.Write("Ingrese la cantidad de cadenas a evaluar: ");
                int cadenas = int.Parse(Console.ReadLine());
                var dFSM = new AFD(Q, Sigma, Delta, Q0, F);
                for (int i = 0; i < cadenas; i++)
                {
                    Console.Write("Ingresa la cadena a evaluar: ");
                    string palabra = Console.ReadLine();
                    dFSM.Acepta(palabra);
                }

                Console.ReadKey();
            }

      }

      
   }
}