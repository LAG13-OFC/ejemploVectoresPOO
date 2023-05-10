using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploVectoresPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector objCP = new Vector();
            objCP.VectorPrincipal  = new Int32[] { 11, 22, 33, 44, 55 };
            objCP.VectorSecundario = new Double[] { 23, 10, 3, 20, 4 };
            Int32[] AS = new Int32[5];
            Int32 x = 0, j = 0, Pos, Venta = 1, pp = 0;
            char S = 'j';
            Boolean existe = true, pase= false;
            Int32 primerPas = 1;

            do
            {
                if (pase == false) { 
                Console.Write("Ingrese el codigo del producto a vender o '0' para cerrar sistema de ventas: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    pase = true;
                }
                if (x == 0) { break; }
                Pos = objCP.BuscarVectorInt32(x);
                if (Pos == -1)
                {
                    
                    Console.Write("No se encontro! Ingrese otro codigo: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    
                }

                else
                {
                    while (objCP.VectorSecundario[Pos] > 0)
                    {
                        if (S != 's' && existe == false || primerPas == 1)
                        {
                            primerPas = 0;
                            Console.Write("Stock disponible: " + objCP.VectorSecundario[Pos] + " \nSeleccione la cantidad que desee vender: ");
                            Venta = Convert.ToInt32(Console.ReadLine());

                            objCP.Validacion(Venta,ref x, ref Pos, ref pp);
                        }
                        if(pp==1){
                            primerPas = 0;
                            Console.Write("Stock disponible: " + objCP.VectorSecundario[Pos] + " \nSeleccione la cantidad que desee vender: ");
                            Venta = Convert.ToInt32(Console.ReadLine());

                            objCP.Validacion(Venta,ref x, ref Pos, ref pp);
                        }

                        if (Venta <= objCP.VectorSecundario[Pos])
                        {
                            objCP.VectorSecundario[Pos] = objCP.VectorSecundario[Pos] - Venta;
                            Console.WriteLine("¡VENTA EXITOSA! Se actualizo el stock del articulo: " + objCP.VectorPrincipal[Pos] + "\nCantidad de articulos disponibles: " + objCP.VectorSecundario[Pos]);
                            Console.Write("¿Desea realizar otra venta? ¿S/N? ");
                            S = Convert.ToChar(Console.ReadLine());
                            char.ToLower(S);
                            while (S != 's' && S != 'n')
                            {
                                Console.Write("OPCION INCORRECTA! INGRESE S/N: ");
                                S = Convert.ToChar(Console.ReadLine());
                                char.ToLower(S);
                            }
                        }


                       Console.Clear();

                        if (S == 's')
                        {
                            if (objCP.VectorSecundario[Pos] == 0)
                            {                   
                                Console.Write("Ingrese el codigo de otro articulo para vender o '0' para cerrar las ventas: ");
                                x = Convert.ToInt32(Console.ReadLine());
                                Pos = objCP.BuscarVectorInt32(x);
                                if (x == 0) { break; }
                                existe = false;
                            }
                            else
                            {
                                if (x == 0) { break; }
                                Console.Write("Stock disponible: " + objCP.VectorSecundario[Pos] + " \nSeleccione la cantidad que desee vender: ");
                                Venta = Convert.ToInt32(Console.ReadLine());

                                objCP.Validacion(Venta,ref x, ref Pos, ref pp);

                                objCP.VectorSecundario[Pos] = objCP.VectorSecundario[Pos] - Venta;
                            }

                        }
                        if (S == 'n')
                        {
                            Console.Write("Ingrese el codigo del producto a vender o '0' para cerrar sistema de ventas: ");
                            x = Convert.ToInt32(Console.ReadLine());
                            if (x == 0) { break; }
                            Pos = objCP.BuscarVectorInt32(x);
                            Console.Write("Stock disponible: " + objCP.VectorSecundario[Pos] + " \nSeleccione la cantidad que desee vender: ");
                            Venta = Convert.ToInt32(Console.ReadLine());
                            objCP.Validacion(Venta,ref x, ref Pos, ref pp);
                            if (x == 0) { break; }
                            objCP.VectorSecundario[Pos] = objCP.VectorSecundario[Pos] - Venta;

                        }

                    }//fin while stock > 0    
                }//fin else

            } while(x!=0);

            Console.Write("\nTiene: " + objCP.Generar(AS) + " articulos con menos de 10 en stock\n");
            for (j = 0; j < objCP.Generar(AS); j++)
            {
                Console.WriteLine(AS[j]);
            }


            Console.ReadKey();
        }
    }
}
