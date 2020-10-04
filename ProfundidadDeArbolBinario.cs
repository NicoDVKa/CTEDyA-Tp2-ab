using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tp2
{
    public class ProfundidadDeArbolBinario
    {
        ArbolBinario<int> arbolBinario;

        public ProfundidadDeArbolBinario(ArbolBinario<int> arbolBinario)
        {
            this.arbolBinario = arbolBinario; 
        }

        public int sumaElementosProfundidad(int p) //Uso recorrido entre niveles.
        {
			Cola<ArbolBinario<int>> cola = new Cola<ArbolBinario<int>>();
			ArbolBinario<int> arbolAuxiliar;
			int contProfundidad = 0;
			int suma = 0;
			
			cola.encolar(arbolBinario); //Encolamos el arbol
			cola.encolar(null); //Separador de niveles
			while (!cola.esVacia())
			{
				arbolAuxiliar = cola.desencolar();

				if (arbolAuxiliar != null)
				{
					if (contProfundidad==p)
					{
						suma += arbolAuxiliar.getDatoRaiz();
					}
					if (arbolAuxiliar.getHijoIzquierdo() != null)
					{
						cola.encolar(arbolAuxiliar.getHijoIzquierdo());
					}
					if (arbolAuxiliar.getHijoDerecho() != null)
					{
						cola.encolar(arbolAuxiliar.getHijoDerecho());
					}

				}
				else
				{
					contProfundidad++;
					if (!cola.esVacia())
					{
						cola.encolar(null); //Encolamos el separador
					}
				}

			}
			
			return suma;
        }
    }
}
