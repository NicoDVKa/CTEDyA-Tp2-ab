/*
 * Creado por SharpDevelop.
 * Usuario: User
 * Fecha: 12/09/2020
 * Hora: 05:20 p.m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;

namespace Tp2
{
	class Program
	{
		public static void Main(string[] args)
		{
			ArbolBinario<int> arbolBinarioA = new ArbolBinario<int>(1);

			ArbolBinario<int> hijoIzquierdo=new ArbolBinario<int>(2);
			
			hijoIzquierdo.agregarHijoIzquierdo(new ArbolBinario<int>(3));
			hijoIzquierdo.agregarHijoDerecho(new ArbolBinario<int>(4));

			ArbolBinario<int> hijoDerecho=new ArbolBinario<int>(5);
			
			hijoDerecho.agregarHijoIzquierdo(new ArbolBinario<int>(6));
			hijoDerecho.agregarHijoDerecho(new ArbolBinario<int>(7));

			arbolBinarioA.agregarHijoIzquierdo(hijoIzquierdo);
			arbolBinarioA.agregarHijoDerecho(hijoDerecho);

			//*************************************************************************************************************
			Console.Write("Preorden: ");
			arbolBinarioA.preorden();//Funciona
			Console.WriteLine();
			Console.Write("Inorden: ");
			arbolBinarioA.inorden();//Funciona
			Console.WriteLine();
			Console.Write("Postorden: ");
			arbolBinarioA.postorden();//Funciona
			Console.WriteLine();
			Console.Write("Recorrido por niveles: ");
			arbolBinarioA.recorridoPorNiveles();//Funciona
			Console.WriteLine();
			int hoja=0;
			Console.WriteLine("La cantidad de hojas que tiene el Arbol Binario es de: {0}",arbolBinarioA.contarHojas(hoja));
			//*************************************************************************************************************
			int dato=6;
			Console.WriteLine("El dato {0} esta en el ab? {1}",dato,arbolBinarioA.incluye(dato));

			
			arbolBinarioA.agregarNodo(new ArbolBinario<int>(100));
			Console.Write("Recorrido por niveles, despues de la insercion,: "); arbolBinarioA.recorridoPorNiveles();//Funciona
			Console.WriteLine();

			Console.Write("Recorrido entre niveles:"); arbolBinarioA.recorridoEntreNiveles(0,3); //Funciona
			Console.WriteLine();

			Console.WriteLine("El retardo de reenvio maximo es de: {0}", arbolBinarioA.retardoReenvio());

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
		
	}
}