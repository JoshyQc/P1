/*
Plantear una clase para administrar una lista genérica doblemente encadenada implementando los siguientes métodos:
a) Insertar un nodo al principio de la lista.
b) Insertar un nodo al final de la lista.
c) Insertar un nodo en la segunda posición. Si la lista está vacía no se inserta el nodo.
d) Insertar un nodo en la ante última posición.
e) Borrar el primer nodo.
f) Borrar el segundo nodo.
g) Borrar el último nodo.
h) Borrar el nodo con información mayor.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaGenericaDoble2
{
    class ListaGenericaDoble
    {
        class Nodo
        {
            public int info;
            public Nodo ant, sig;
        }

        private Nodo raiz;

        public ListaGenericaDoble()
        {
            raiz = null;
        }

        void InsertarPrimero(int x)
        {
            Nodo nuevo = new Nodo();
            nuevo.info = x;
            nuevo.sig = raiz;
            if (raiz != null)
                raiz.ant = nuevo;
            raiz = nuevo;
        }

        public void InsertarUtlimo(int x)
        {
            Nodo nuevo = new Nodo();
            nuevo.info = x;
            if (raiz == null)
                raiz = nuevo;
            else
            {
                Nodo reco = raiz;
                while (reco.sig != null)
                {
                    reco = reco.sig;
                }
                reco.sig = nuevo;
                nuevo.ant = reco;
            }
        }

        public void InsertarSegundo(int x)
        {
            if (raiz != null)
            {
                Nodo nuevo = new Nodo();
                nuevo.info = x;
                if (raiz.sig == null)
                {
                    //Hay un solo nodo.
                    raiz.sig = nuevo;
                    nuevo.ant = raiz;
                }
                else
                {
                    Nodo tercero = raiz.sig;
                    nuevo.sig = tercero;
                    tercero.ant = nuevo;
                    raiz.sig = nuevo;
                    nuevo.ant = raiz;
                }
            }
        }

        public void InsertarAnteUltimo(int x)
        {
            if (raiz != null)
            {
                Nodo nuevo = new Nodo();
                nuevo.info = x;
                if (raiz.sig == null)
                {
                    //Hay un solo nodo.
                    nuevo.sig = raiz;
                    raiz = nuevo;
                }
                else
                {
                    Nodo reco = raiz;
                    while (reco.sig != null)
                    {
                        reco = reco.sig;
                    }
                    Nodo anterior = reco.ant;
                    nuevo.sig = reco;
                    nuevo.ant = anterior;
                    anterior.sig = nuevo;
                    reco.ant = nuevo;
                }
            }
        }

        public void BorrarPrimero()
        {
            if (raiz != null)
            {
                raiz = raiz.sig;
            }
        }

        public void BorrarSegundo()
        {
            if (raiz != null)
            {
                if (raiz.sig != null)
                {
                    Nodo tercero = raiz.sig;
                    tercero = tercero.sig;
                    raiz.sig = tercero;
                    if (tercero != null)
                        tercero.ant = raiz;
                }
            }
        }

        public void BorrarUltimo()
        {
            if (raiz != null)
            {
                if (raiz.sig == null)
                {
                    raiz = null;
                }
                else
                {
                    Nodo reco = raiz;
                    while (reco.sig != null)
                    {
                        reco = reco.sig;
                    }
                    reco = reco.ant;
                    reco.sig = null;
                }
            }

        }
        public void Imprimir()
        {
            Nodo reco = raiz;
            while (reco != null)
            {
                Console.Write(reco.info + "-");
                reco = reco.sig;
            }
            Console.WriteLine();
        }

        public void BorrarMayor()
        {
            if (raiz != null)
            {
                Nodo reco = raiz;
                int may = raiz.info;
                while (reco != null)
                {
                    if (reco.info > may)
                    {
                        may = reco.info;
                    }
                    reco = reco.sig;
                }
                reco = raiz;
                while (reco != null)
                {
                    if (reco.info == may)
                    {
                        if (reco == raiz)
                        {
                            raiz = raiz.sig;
                            if (raiz != null)
                                raiz.ant = null;
                            reco = raiz;
                        }
                        else
                        {
                            Nodo atras = reco.ant;
                            atras.sig = reco.sig;
                            reco = reco.sig;
                            if (reco != null)
                                reco.ant = atras;
                        }
                    }
                    else
                    {
                        reco = reco.sig;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            ListaGenericaDoble lg=new ListaGenericaDoble();
            lg.InsertarPrimero (10);
            lg.InsertarPrimero(45);
            lg.InsertarPrimero(23);
            lg.InsertarPrimero(89);
            lg.Imprimir();
            Console.WriteLine("Insertamos un nodo al final:");
            lg.InsertarUtlimo(160);
            lg.Imprimir();
            Console.WriteLine("Insertamos un nodo en la segunda posición:");
            lg.InsertarSegundo(13);
            lg.Imprimir();
            Console.WriteLine("Insertamos un nodo en la anteultima posición:");
            lg.InsertarAnteUltimo(600);
            lg.Imprimir();
            Console.WriteLine("Borramos el primer nodo de la lista:");
            lg.BorrarPrimero();
            lg.Imprimir();        
            Console.WriteLine("Borramos el segundo nodo de la lista:");
            lg.BorrarSegundo();
            lg.Imprimir();
            Console.WriteLine("Borramos el ultimo nodo de la lista:");
            lg.BorrarUltimo();
            lg.Imprimir();                
            Console.WriteLine("Borramos el mayor de la lista:");
            lg.BorrarMayor();
            lg.Imprimir();
            Console.ReadKey();
        }
    }
}