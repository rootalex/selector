using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Helper<T> where T: IComparable
    {
        public IEnumerable<int> random(int size) {
            List<int> result = new List<int>();
            Random rd = new Random();
            for(int i = 0; i < size; i++)
            {
                result.Add(rd.Next());
            }
            return result;
        }
        public IEnumerable<T> Select<T>(IEnumerable<T> sequence, Func<T, bool> condition) where T: IComparable
        {
            //List<T> result = new List<T>();
            SplayTree<T> stree = new SplayTree<T>();

            foreach (T iter in sequence)         
            {
                if (condition(iter))
                {
                    stree.Insert(iter);
                }
            }

            IEnumerable<T>  result = stree.OrderTraversal();
            return result;
        }

        Func<int, bool> evenn = (elem => elem % 2 == 0);
    }
}
