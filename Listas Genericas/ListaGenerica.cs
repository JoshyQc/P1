/*
Inserta un nodo en la posición (pos) y con la información que hay en el parámetro x.

    void Insertar(int pos, int x)
Extrae la información del nodo de la posición indicada (pos). Se debe eliminar el nodo.

    int Extraer(int pos)
Borra el nodo de la posición (pos).

    void Borrar(int pos)
Intercambia las informaciones de los nodos de las posiciones pos1 y pos2.

   
    void Intercambiar(int pos1,int pos2)
Retorna el valor del nodo con mayor información.

    int Mayor()
Retorna la posición del nodo con mayor información.

    int PosMayor()
Retorna la cantidad de nodos de la lista.

    int Cantidad()
Debe retornar true si la lista está ordenada de menor a mayor, false en caso contrario.

    bool Ordenada()
Debe retornar true si existe la información que llega en el parámetro, false en caso contrario.

    bool Existe(int info)
El método vacía debe retornar true si está vacía y false si no lo está.

    bool Vacia()
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaGenerica1
{
    class ListaGenerica
    {
        class Nodo
        {
            public int info;
            public Nodo sig;
        }

        private Nodo raiz;

        public ListaGenerica()
        {
            raiz = null;
        }

        void Insertar(int pos, int x)
        {
            if (pos <= Cantidad() + 1)
            {
                Nodo nuevo = new Nodo();
                nuevo.info = x;
                if (pos == 1)
                {
                    nuevo.sig = raiz;
                    raiz = nuevo;
                }
                else
                    if (pos == Cantidad() + 1)
                    {
                        Nodo reco = raiz;
                        while (reco.sig != null)
                        {
                            reco = reco.sig;
                        }
                        reco.sig = nuevo;
                        nuevo.sig = null;
                    }
                    else
                    {
                        Nodo reco = raiz;
                        for (int f = 1; f <= pos - 2; f++)
                            reco = reco.sig;
                        Nodo siguiente = reco.sig;
                        reco.sig = nuevo;
                        nuevo.sig = siguiente;
                    }
            }
        }

        public int Extraer(int pos)
        {
            if (pos <= Cantidad())
            {
                int informacion;
                if (pos == 1)
                {
                    informacion = raiz.info;
                    raiz = raiz.sig;
                }
                else
                {
                    Nodo reco;
                    reco = raiz;
                    for (int f = 1; f <= pos - 2; f++)
                        reco = reco.sig;
                    Nodo prox = reco.sig;
                    reco.sig = prox.sig;
                    informacion = prox.info;
                }
                return informacion;
            }
            else
                return int.MaxValue;
        }

        public void Borrar(int pos)
        {
            if (pos <= Cantidad())
            {
                if (pos == 1)
                {
                    raiz = raiz.sig;
                }
                else
                {
                    Nodo reco;
                    reco = raiz;
                    for (int f = 1; f <= pos - 2; f++)
                        reco = reco.sig;
                    Nodo prox = reco.sig;
                    reco.sig = prox.sig;
                }
            }
        }

        public void Intercambiar(int pos1, int pos2)
        {
            if (pos1 <= Cantidad() && pos2 <= Cantidad())
            {
                Nodo reco1 = raiz;
                for (int f = 1; f < pos1; f++)
                    reco1 = reco1.sig;
                Nodo reco2 = raiz;
                for (int f = 1; f < pos2; f++)
                    reco2 = reco2.sig;
                int aux = reco1.info;
                reco1.info = reco2.info;
                reco2.info = aux;
            }
        }

        public int Mayor()
        {
            if (!Vacia())
            {
                int may = raiz.info;
                Nodo reco = raiz.sig;
                while (reco != null)
                {
                    if (reco.info > may)
                        may = reco.info;
                    reco = reco.sig;
                }
                return may;
            }
            else
                return int.MaxValue;
        }

        public int PosMayor()
        {
            if (!Vacia())
            {
                int may = raiz.info;
                int x = 1;
                int pos = x;
                Nodo reco = raiz.sig;
                while (reco != null)
                {
                    if (reco.info > may)
                    {
                        may = reco.info;
                        pos = x;
                    }
                    reco = reco.sig;
                    x++;
                }
                return pos;
            }
            else
                return int.MaxValue;
        }

        public int Cantidad()
        {
            int cant = 0;
            Nodo reco = raiz;
            while (reco != null)
            {
                reco = reco.sig;
                cant++;
            }
            return cant;
        }

        public bool Ordenada()
        {
            if (Cantidad() > 1)
            {
                Nodo reco1 = raiz;
                Nodo reco2 = raiz.sig;
                while (reco2 != null)
                {
                    if (reco2.info < reco1.info)
                    {
                        return false;
                    }
                    reco2 = reco2.sig;
                    reco1 = reco1.sig;
                }
            }
            return true;
        }

        public bool Existe(int x)
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                if (reco.info == x)
                    return true;
                reco = reco.sig;
            }
            return false;
        }

        public bool Vacia()
        {
            if (raiz == null)
                return true;
            else
                return false;
        }

        public void Imprimir()
        {
            Nodo reco = raiz;
            while (reco != null) {
                Console.Write (reco.info + "-");
                reco = reco.sig;
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            ListaGenerica lg=new ListaGenerica();
            lg.Insertar (1, 10);
            lg.Insertar (2, 20);
            lg.Insertar (3, 30);
            lg.Insertar (2, 15);
            lg.Insertar (1, 115);
            lg.Imprimir ();
            Console.WriteLine ("Luego de Borrar el primero");
            lg.Borrar (1);
            lg.Imprimir ();
            Console.WriteLine ("Luego de Extraer el segundo");
            lg.Extraer (2);
            lg.Imprimir ();
            Console.WriteLine ("Luego de Intercambiar el primero con el tercero");
            lg.Intercambiar (1, 3);
            lg.Imprimir ();
            if (lg.Existe(10)) 
                Console.WriteLine("Se encuentra el 20 en la lista");
            else
                Console.WriteLine("No se encuentra el 20 en la lista");
            Console.WriteLine("La posición del mayor es:"+lg.PosMayor());
            if (lg.Ordenada())
                Console.WriteLine("La lista está ordenada de menor a mayor");
            else
                Console.WriteLine("La lista no está ordenada de menor a mayor");
            Console.ReadKey();
        }
    }
}