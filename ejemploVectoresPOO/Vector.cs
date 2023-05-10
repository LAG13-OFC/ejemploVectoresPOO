using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploVectoresPOO
{
    internal class Vector
    {
        private Int32[] vectorPrincipal;
        private Double[] vectorSecundario;


        public int[] VectorPrincipal { get => vectorPrincipal; set => vectorPrincipal = value; }
        public double[] VectorSecundario { get => vectorSecundario; set => vectorSecundario = value; }


        public Vector()
        {
        }

        public Int32 BuscarVectorInt32(Int32 x)
        {
            int i = 0, k = 0;
            while (k == 0 && i < vectorPrincipal.Length)
            {
                if (vectorPrincipal[i] == x)
                {
                    k = 1;
                }
                else
                {
                    i++;
                }
            }
            if (k == 0)
            {
                i = -1;
            }
            return i;


        }
        public void Validacion(Int32 Venta, ref Int32 x, ref Int32 Pos, ref Int32 pp)
        {
            //VALIDACION DE INGRESO DE VENTA
            // int[] CP = new int[Stock.Length];
            pp = 0;
            while (Venta == 0 || Venta > vectorSecundario[Pos] || vectorSecundario[Pos] == 0)
            {
                if (Venta == 0)
                {
                    Console.Write("NO SE SELECCIONARON VENTAS! Seleccione la cantidad de articulos a vender: ");
                    Venta = Convert.ToInt32(Console.ReadLine());
                }
                if (Venta > vectorSecundario[Pos])
                {
                    Console.WriteLine("STOCK INSUFICIENTE! CONTACTE A SU PROVEDOR");
                    Console.Write("Ingrese el codigo del producto a vender o '0' para cerrar sistema de ventas: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x != 0) { Pos = BuscarVectorInt32(x); }
                   

                }
                if (x == 0) { break; }
                if (vectorSecundario[Pos] == 0)
                {
                    Console.Write("Sin stock! Ingrese el codigo de otro articulo para vender o '0' para cerrar las ventas: ");
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x == 0) { break; }
                }


                else
                {
                    Venta = -1;
                    pp = 1;
                }

            }
        }

        public Int32 Generar(Int32[] v3)
        {
            Int32 i = 0, j = 0;

            for (i = 0; i < vectorSecundario.Length; i++)
            {
                if (vectorSecundario[i] < 10)
                {
                    v3[j] = vectorPrincipal[i];
                    j++;
                }
            }
            return j;

        }
    }
}
