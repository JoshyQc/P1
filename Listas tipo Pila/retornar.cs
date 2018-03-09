 public int Retornar()
        {
            if (raiz != null)
            {
                int informacion = raiz.info;
                return informacion;
            }
            else
            {
                return int.MaxValue;
            }
        }