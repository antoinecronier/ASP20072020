using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Module2_P1
{
    public class GenericExample<T, K, L > where T : new() where K : User
    {
        public T DoT()
        {
            return new T();
        }

        public void GetOtherT(T item)
        {
            Console.WriteLine(item);
        }

        //public T SpecialTKL(K kItem, L lItem)
        //{
        //}

        //public M DoSMT<M>()
        //{

        //}
    }
}
