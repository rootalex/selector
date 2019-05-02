using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Nodes<T> where T: IComparable
    {
        public Nodes<T> LeftChild { get; set; }
        public Nodes<T> RightChild { get; set; }
        public Nodes<T> Parent { get; set; }
        public T Key { get; set; }
        public bool IsLeftChild => Parent != null && Parent.LeftChild != null && Parent.LeftChild.Key.Equals(Key);
        public Nodes(T key , Nodes<T> left = null, Nodes<T> right = null, Nodes<T> parent = null)
        {
            this.LeftChild = left;
            this.RightChild = right;
            this.Parent = parent;
            this.Key.Equals(key);
        }
        public Nodes(Nodes<T> Copy)
        {
            LeftChild = Copy.LeftChild;
            RightChild = Copy.RightChild;
            Parent = Copy.Parent;
            Key = Copy.Key;
        }
        public Nodes<T> root = null; //protected
        public Nodes<T> Select(T key) // TravelDown
        {
            Nodes<T> PrevNode = null;
            Nodes<T> z = root;
            while (z != null)
            {
                PrevNode = z;
                if (key.CompareTo( z.Key) > 0)
                    z = z.RightChild;
                else if (key.CompareTo(z.Key) < 0)
                    z = z.LeftChild;
                else if (key.CompareTo(z.Key) == 0)
                {
                    Splay(z);
                    return z;
                }

            }
            if (PrevNode != null)
            {
                Splay(PrevNode);
                return null;
            }
            return null;
        }
        private void Splay(Nodes<T> x)
        {
            if (x == null)
            {
                //x = root; //     
                return;

            }
                

            while (x.Parent != null)
            {
                Nodes<T> Parent = x.Parent;
                Nodes<T> GrandParent = Parent.Parent;
                if (GrandParent == null)
                {
                    if (x == Parent.LeftChild)
                        ZigR(x, Parent);
                    else
                        ZigL(x, Parent);
                }
                else
                {
                    if (x == Parent.LeftChild)
                    {
                        if (Parent == GrandParent.LeftChild)
                        {
                            ZigR(Parent, GrandParent);
                            ZigR(x, Parent);
                        }
                        else
                        {
                            ZigR(x, x.Parent);
                            ZigL(x, x.Parent);
                        }
                    }
                    else
                    {
                        if (Parent == GrandParent.LeftChild)
                        {
                            ZigL(x, x.Parent);
                            ZigR(x, x.Parent);
                        }
                        else
                        {
                            ZigL(Parent, GrandParent);
                            ZigL(x, Parent);
                        }
                    }
                }
            }
            root = x;
        }
        public void ZigR(Nodes<T> c, Nodes<T> p)
        {
            if ((c == null) || (p == null) || (p.LeftChild != c) || (c.Parent != p))
                return;

            if (p.Parent != null)
            {
                if (p == p.Parent.LeftChild)
                    p.Parent.LeftChild = c;
                else
                    p.Parent.RightChild = c;
            }
            if (c.RightChild != null)
                c.RightChild.Parent = p;

            c.Parent = p.Parent;
            p.Parent = c;
            p.LeftChild = c.RightChild;
            c.RightChild = p;
        }
        public void ZigL(Nodes<T> c, Nodes<T> p)
        {
            if ((c == null) || (p == null) || (p.RightChild != c) || (c.Parent != p))
                return;
            if (p.Parent != null)
            {
                if (p == p.Parent.LeftChild)
                    p.Parent.LeftChild = c;
                else
                    p.Parent.RightChild = c;
            }
            if (c.LeftChild != null)
                c.LeftChild.Parent = p;
            c.Parent = p.Parent;
            p.Parent = c;
            p.RightChild = c.LeftChild;
            c.LeftChild = p;
        }

        public void Insert(Nodes<T> current, T key)
        {
            Nodes<T> z = root;
            Nodes<T> p = null;
            while (z != null)
            {
                p = z;
                if ( key.CompareTo(p.Key) > 0) //key > p.Key
                    z = z.RightChild;
                else
                    z = z.LeftChild;
            }
            z = new Nodes<T>(key);
            z.Key = key;
            z.Parent = p;
            if (p == null)
                root = z;
            else if (key.CompareTo(p.Key) > 0)
                p.RightChild = z;
            else
                p.LeftChild = z;
            Splay(z);
        }
        public void Delete(Nodes<T> node)
        {
            if (node == null)
                return;

            Splay(node);
            if ((node.LeftChild != null) && (node.RightChild != null))
            {
                Nodes<T> min = node.LeftChild;
                while (min.RightChild != null)
                    min = min.RightChild;

                min.RightChild = node.RightChild;
                node.RightChild.Parent = min;
                node.LeftChild.Parent = null;
                root = node.LeftChild;
            }
            else if (node.RightChild != null)
            {
                node.RightChild.Parent = null;
                root = node.RightChild;
            }
            else if (node.LeftChild != null)
            {
                node.LeftChild.Parent = null;
                root = node.LeftChild;
            }
            else
            {
                root = null;
            }
            node.Parent = null;
            node.LeftChild = null;
            node.RightChild = null;
            node = null;
        }


    }
}
