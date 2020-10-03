using System;
using System.Security.Cryptography;

namespace Tp2
{
	public class ArbolBinario<T>
	{
		
	
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
	
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo=hijo;
		}
	
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho=hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo=null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho=null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo==null && this.hijoDerecho==null;
		}
		
		public void inorden() {
			//Primero el hijo izquierdo luego la raiz y por ultimo el hijo derecho
			
			
			
			if(getHijoIzquierdo()!=null){
				
				this.getHijoIzquierdo().inorden();
				
			}
			Console.Write(this.getDatoRaiz()+" ");
			if(this.getHijoDerecho()!=null){
				
				this.getHijoDerecho().inorden();
				
			}
			
					
		}
		
		public void preorden() {
			//Primero la raiz y luego los hijos izquierdos y derechos
			
			Console.Write(this.getDatoRaiz()+" ");
			if(this.getHijoIzquierdo()!=null){
				
				this.getHijoIzquierdo().preorden();
				
			}
			if(this.getHijoDerecho()!=null){
				this.getHijoDerecho().preorden();
				
			}
			
			
		}
		
		public void postorden() {
			//Primero los hijos, izquierdo y derecho, y luego la raiz
			
			
			if(getHijoIzquierdo()!=null){
				this.getHijoIzquierdo().postorden();
				
			}
			if(this.getHijoDerecho()!=null){
				
				this.getHijoDerecho().postorden();
				
				
			}
			Console.Write(this.getDatoRaiz()+" ");
		
			
		}
		
		//Recorrido por niveles
		public void recorridoPorNiveles() {
			Cola <ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			cola.encolar(this);
			while(!cola.esVacia()){
				ArbolBinario<T> nodo =cola.desencolar();
				Console.Write(nodo.getDatoRaiz()+" ");
				if(nodo.getHijoIzquierdo()!=null){
					cola.encolar(nodo.getHijoIzquierdo());
				}
				if(nodo.getHijoDerecho()!=null){
					cola.encolar(nodo.getHijoDerecho());
				}
			}
		}


		//Contar Hojas
		public int contarHojas(int hoja) {
			
			if(this.getHijoIzquierdo()==null && this.getHijoDerecho()==null){
				
				hoja++;
			}
			
			if(this.getHijoIzquierdo()!=null){
				
				hoja=this.getHijoIzquierdo().contarHojas(hoja);
			}
			
			if(this.getHijoDerecho()!=null){
				
				hoja=this.getHijoDerecho().contarHojas(hoja);
				
			}
			
			return hoja;
			
		}
		//Incluye
		public bool incluye(T dato)
        {
			bool verificar = true;

			if (this.getDatoRaiz().ToString()==dato.ToString())
            {
				return true;
            }
            
			if (this.getHijoIzquierdo()!=null)
            {
                if (verificar == this.getHijoIzquierdo().incluye(dato))
                {
					return verificar;
                }
			}
            
			if (this.getHijoDerecho()!=null)
            {
				if(verificar == this.getHijoDerecho().incluye(dato))
                {
					return verificar;
                }
            }

			return false;
		}

		//Agregar
		public void agregarNodo(ArbolBinario<T> nodoNuevo)
        {
			Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			cola.encolar(this);
			while (!cola.esVacia())
			{
				ArbolBinario<T> nodo = cola.desencolar();
				
				if (nodo.getHijoIzquierdo() != null) //Verifico que el elemento encolado tenga hijo izquierdo
				{
					cola.encolar(nodo.getHijoIzquierdo());
                }
                else                                //En caso de no tener, coloco al nodo nuevo alli.
                {
                    if (nodoNuevo != null) {                //Sirve para no colocar al nodo nuevo en todos los espacios vacios
						nodo.agregarHijoIzquierdo(nodoNuevo);
						nodoNuevo = null;                   //Una vez colocado lo pongo nulo para no colocarlo en otros lados
					}
					
                }
				
				if (nodo.getHijoDerecho() != null) //Verifico que el elemento encolado tenga hijo derecho
				{
					cola.encolar(nodo.getHijoDerecho());
                }
				else                               //En caso de no tener, coloco al nodo nuevo alli.
				{
					if (nodoNuevo != null)         //Sirve para no colocar al nodo nuevo en todos los espacios vacios
					{
						nodo.agregarHijoDerecho(nodoNuevo);
						nodoNuevo = null;        //Una vez colocado lo pongo nulo para no colocarlo en otros lados
					}
				}
			}
		}
		
		public void recorridoEntreNiveles(int n,int m) {

			Cola<ArbolBinario<T>> cola = new Cola<ArbolBinario<T>>();
			ArbolBinario<T> arbolAuxiliar;
			int contNivel = 0; 
			cola.encolar(this);	//Encolamos el arbol
			cola.encolar(null); //Separador de niveles
			while (!cola.esVacia())
			{
				arbolAuxiliar = cola.desencolar(); 
                
				if (arbolAuxiliar!=null)
                {
					if (contNivel >= n && contNivel <= m){
						Console.Write(arbolAuxiliar.getDatoRaiz() + " ");
					}
					if (arbolAuxiliar.getHijoIzquierdo() != null){
						cola.encolar(arbolAuxiliar.getHijoIzquierdo());
					}
					if (arbolAuxiliar.getHijoDerecho() != null){
						cola.encolar(arbolAuxiliar.getHijoDerecho());
					}
					
				}else{
					contNivel++;
                    if (!cola.esVacia()) 
                    {
						cola.encolar(null); //Encolamos el separador
                    }
                }
				
			}

		}
	}
}
