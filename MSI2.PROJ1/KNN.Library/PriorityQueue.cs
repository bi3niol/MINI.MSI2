using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library
{
    public class PriorityQueue<T> where T: IComparable
    {
        private T[] tab;      // wewnętrzna tablica do pamiętania elementów
        private int count = 0;  // liczba elementów kontenera - metody Put i Get powinny (muszą) to aktualizować
                                // nie wolno dodawać żadnych pól ani innych składowych

        public PriorityQueue(int n = 2)
        {
            tab = new T[n > 2 ? n : 2];
        }

        public void Put(T x)
        {
            if (count == Size)
            {
                var tab1 = new T[count << 1];
                for (int i = 0; i < count; i++)
                    tab1[i] = tab[i];
                tab = tab1;
            }
            tab[count] = x;
            count++;

            UpHeap(count - 1);

        }
        public void UpHeap(int i)
        {
            T v = tab[i];
            while (i > 0 && tab[(i & 1) == 0 ? (i >> 1) - 1 : (i >> 1)].CompareTo(v) < 0)  //z lewej czy z prawej strony
            {
                if ((i & 1) == 0)
                    tab[i] = tab[(i >> 1) - 1];
                else
                    tab[i] = tab[i >> 1];

                if ((i & 1) == 0)
                    i = (i >> 1) - 1;
                else
                    i = i >> 1;
            }
            tab[i] = v;
        }

        public void DownHeap(int i, int n)
        {
            T val = tab[i];
            int k = (i << 1) + 1; //lewy "następnik"
            while (k <= n)
            {
                if ((k + 1) <= n && tab[k + 1].CompareTo(tab[k]) > 0)
                    k++;
                if (tab[k].CompareTo(val) > 0)
                {
                    tab[i] = tab[k];
                    i = k;
                    k = (i << 1) + 1;
                }
                else break;
            }
            tab[i] = val;
        }

        public T Get()
        {
            if (0 == count) throw new Exception("Queue is empty");

            T max = tab[0];
            tab[0] = tab[count - 1];
            count--;
            DownHeap(0, count - 1);
            return max;

        }

        public T Peek()
        {
            if (0 == count) throw new Exception("Queue is empty");
            return tab[0];
        }

        public int Count => count;

        public int Size => tab.Length;

        public List<T> Items
        {
            get
            {
                return new List<T>(this.tab);
            }
        }
    } 
}
