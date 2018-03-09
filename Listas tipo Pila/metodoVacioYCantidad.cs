public bool Vacia()
        {
            if (raiz == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

 public int Cantidad()
        {
            int cant = 0;
            Nodo reco = raiz;
            while (reco != null)
            {
                cant++;
                reco = reco.sig;
            }
            return cant;
        }