using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matriz
{
    class Matriz
    {
        const int MAXF = 100;
        const int MAXC = 100;
        private int[,] x;
        private int f, c;


        public Matriz()
        {
            x = new int[MAXF, MAXC];
            f = 0; c = 0;
        }

        public void cargar(int nf, int nc, int a, int b)
        {
            f = nf; c = nc;
            int f1, c1;
            Random r = new Random();
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    x[f1, c1] = r.Next(a, b);
                }
            }
        }
        public string descargar()
        {
            string s = "";
            int f1, c1;
            for (f1 = 1; f1 <= f; f1++)
            {
                for (c1 = 1; c1 <= c; c1++)
                {
                    //s = s + x[f1, c1] + "\x09";
                    s = s + x[f1, c1] + " | ";
                }
                s = s + "\x0d" + "\x0a";
            }
            return s;
        }
      
       
         int frecuenciaFil(int f1, int ele)
         {
             int fr = 0;
             for (int c1 = 1; c1 <= c; c1++)
             {
                 if (x[f1, c1] == ele)
                 {
                     fr++;
                 }
             }
             return fr;
         }
         public void pregunta1()
         {
             int may = 0;
             int elemay=0;
            for (int f1 = 1; f1 <= f; f1++)
            {
                may = 0;
                for (int c1 = 1; c1 <= c; c1++)
                 {
                    int ele = x[f1, c1];
                    int fr=frecuenciaFil(f1,ele);
                    if (fr > may)
                    {
                        may = fr;
                        elemay = ele;
                    }
                 }
                x[f1, c+1] = elemay;
                x[f1, c+2] = may;
             }
             c = c + 2;
         }
         void cargarcol(int ele)
         {
             c++;
             x[1, c] = ele;
         }
         void ordenarCol()
         {
             for (int c1 = 1; c1 <= c-1; c1++)
             {
                 for (int c2 = c1+1; c2 <= c; c2++)
                 {
                     if (x[1, c1] > x[1, c2])
                     {
                         int aux = x[1, c1];
                         x[1, c1] = x[1, c2];
                         x[1, c2] = aux;
                     }
                 }
             }
         }

        //--------------
        public void ordenar1()
        {
            int j;
            int ff = f;

            for (int c1 = 2; c1 <= c; c1++)
            {

                for (int f1 = f; f1 >= ff; f1--)
                {
                    for (int cd = c1; cd <= c; cd++)
                    {
                        if (cd == c1)
                        {
                            j = f1;
                        }
                        else
                        {
                            j = f;
                        }
                        for (int fd = j; fd >= ff; fd--)
                        {
                            if (frec(x[f1, c1]) > frec(x[fd, cd]))
                            {
                                inter(f1, c1, fd, cd);
                            }
                        }
                    }
                }
                ff--;
            }

        }

        public int frec(int ele)
        {
            int frec = 0;
            int ff = f;
            for (int c1 = 2; c1 <= c; c1++)
            {
                for (int f1 = f; f1 >= ff; f1--)
                {
                    if (x[f1, c1] == ele)
                    {
                        frec++;
                    }
                }
                ff--;
            }
            return frec;
        }
        public void inter(int f1, int c1, int f2, int c2)
        {
            int aux = x[f1, c1];
            x[f1, c1] = x[f2, c2];
            x[f1, c1] = aux;
        }


    }
}
