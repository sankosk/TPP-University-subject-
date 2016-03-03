using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colletions
{
    public class Set<T> : LinkedList<T>
    {

        public Set() : base() { }

        public override void add(T value)
        {
            if (!base.contains(value)) base.add(value);
        }

        public static Set<T> operator + (Set<T> set, T elem)
        {
            set.add(elem);
            return set;
        }

        public static Set<T> operator -(Set<T> set, T elem)
        {
            set.remove(elem);
            return set;
        }

        //indizadores
        public T this[int i]
        {
            get { return get(i); }
            set { set(i, get(i)); }
        }

        public static Set<T> operator |(Set<T> s1, Set<T> s2){
            for (int i=0; i<s2.size(); i++) {
                if (!s1.contains(s2.get(i))) s1.add(s2.get(i));
            }
            return s1;
        }

        public static Set<T> operator &(Set<T> s1, Set<T> s2) {
            Set<T> s = new Set<T>();
            for (int i=0; i<s1.size(); i++) {
                if (s2.contains(s1.get(i)))  s.add(s1.get(i));
            }
            return s;
        }

        public static Set<T> operator -(Set<T> s1, Set<T> s2) {
            for (int i=0; i<s1.size(); i++) {
                if (s2.contains(s1.get(i)))
                    s1.remove(s1.get(i));
            }
            return s1;
        }

    }
}
