using System;

namespace juego
{
    class Program
    {
       static char[,] opciones = {
                {'1', '2', '3'},
                {'4', '5', '6'},
                {'7', '8', '9'}
            };
        static void Main(string[] args)
        {
            bool terminado = false;
            char opcion;
            do
            {
                
                do
                {
                    imprimir();
                    Console.WriteLine("Por favor ingrese su opción válida.");
                    opcion = Console.ReadLine().ToString()[0];
                } while (!marcar(opcion));

                terminado = evaluar('X');
                if(!terminado)
                {
                    computadora();
                    terminado = evaluar('O');
                    if(terminado)
                    {
                        imprimir();
                        Console.WriteLine("Haz perdido");
                    }
                } else
                {
                    imprimir();
                    Console.WriteLine("Haz ganado!");
                }
            } while (!terminado);

            Console.WriteLine("-------------------");
            Console.WriteLine("Presione enter");
            Console.Read();
            
        }

        static void imprimir()
        {
            Console.Clear();
            Console.WriteLine("Jose Villasmil.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("| {0} | {1} | {2} |", opciones[i,0], opciones[i,1], opciones[i,2]);
            }
            
            Console.WriteLine("Bienvenido al juego de tres rallas.");
            
        }

        static bool marcar(char c)
        {
            for(int i = 0; i < 3; i++)
            {
                // Linea
                for(int j = 0; j < 3; j++)
                {
                    // Celda
                    if(opciones[i,j].Equals(c))
                    {
                        opciones[i, j] = 'X'; 
                        return true;
                    }
                }
            }

            return false;
        }

        static void computadora()
        {
            Random r = new Random();
            int x = 0;
            int y = 0;

            do
            {
                x = r.Next(0, 3);
                y = r.Next(0, 3);

            } while (opciones[x, y].Equals('X') || opciones[x, y].Equals('O'));

            opciones[x, y] = 'O';

            
        }

        static bool evaluar(char c)
        {
            int[,,] evaluaciones =
            {
                {
                    {0, 0},
                    {0, 1},
                    {0, 2}
                },
                {   
                    {1, 0},
                    {1, 1},
                    {1, 2}
                },
                {   
                    {2, 0},
                    {2, 1},
                    {2, 2}
                },
                {
                    {0, 0},
                    {1, 0},
                    {2, 0}
                },
                {
                    {0, 1},
                    {1, 1},
                    {2, 1}
                },
                {
                    {0, 2},
                    {1, 2},
                    {2, 2}
                },
                {
                    {0, 0},
                    {1, 1},
                    {2, 2}
                },
                {
                    {2, 0},
                    {1, 1},
                    {0, 2}
                }
            };

            for(int i = 0; i < 8; i ++)
            {
                if(opciones[evaluaciones[i, 0 , 0], evaluaciones[i, 0, 1] ].Equals(c))
                {
                    if (opciones[evaluaciones[i, 1, 0], evaluaciones[i, 1, 1]].Equals(c))
                    {
                        if (opciones[evaluaciones[i, 2, 0], evaluaciones[i, 2, 1]].Equals(c))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
