using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab3
{
    class SplayTree<T>  where T : IComparable
    {
        Node<T> root;

        public SplayTree()
        {
            root = null;
        }
        void Splay(T sKey)
        {
            Node<T> lNode, rNode, tNode, y;
            Node<T> header = new Node<T>(default(T));
            lNode = rNode = header;
            tNode = root;
            header.left = header.right = null;
            while (true)
            {
                if(sKey.CompareTo(tNode.key) < 0)
                {
                    if (tNode.left == null) break;
                    if(sKey.CompareTo(tNode.left.key ) < 0)
                    {
                        y = tNode.left;
                        tNode.left = y.right;
                        y.right = tNode;
                        tNode = y;
                        if (tNode.left == null) break;
                    }
                    rNode.left = tNode;
                    rNode = tNode;
                    tNode = tNode.left;
                }
                else
                {
                    if(sKey.CompareTo(tNode.key ) > 0)
                    {
                        if (tNode.right == null) break;
                        if(sKey.CompareTo(tNode.right.key ) > 0)
                        {
                            y = tNode.right;
                            tNode.right = y.left;
                            y.left = tNode;
                            tNode = y;
                            if (tNode.right == null) break;
                        }
                        lNode.right = tNode;
                        lNode = tNode;
                        tNode = tNode.right;

                    }
                    else { break; }
                }

            }
            lNode.right = tNode.left;
            rNode.left = tNode.right;
            tNode.left = header.left;
            root = tNode;
        }

        public void Insert(T theKey)
        {
            Node<T> tNode = new Node<T>(theKey);
            if(root == null)
            {
                root = tNode;
                return;
            }
            
            Splay(theKey);
            if(tNode.key.CompareTo(root.key) < 0)
            {
                tNode.left = root.left;
                tNode.right = root;
                root.left = null;
            }
            else
            {
                tNode.right = root.right;
                tNode.left = root;
                root.left = null;
            }
            root = tNode;
        }

        void Remove(T theKey)
        {
            Node<T> tNode;
            Splay(theKey);
            if (theKey.CompareTo(root.key) != 0)
            {
                return;
            }
            if(root.left == null)
            {
                root = root.right;
            }
            else
            {
                tNode = root.left;
                Splay(theKey);
                root.right = tNode;
            }
        }

        public T findMin()
        {
            Node<T> tNode = root;
            if (root == null) return default(T);
            while (tNode.left != null) tNode = tNode.left;
            Splay(tNode.key);
            return tNode.key;
        }

        public T findMax()
        {
            Node<T> tNode = root;
            if (root == null) return default(T);
            while (tNode.right != null) tNode = tNode.right;
            Splay(tNode.key);
            return tNode.key;
        }

        public T find( T theKey)
        {
            if (root == null) return default(T);
            Splay(theKey);
            if(theKey.CompareTo(root.key) != 0) return default(T);
            return root.key;
        }

        public bool isEmpty()
        {
            return root == null;
        }

        void OrderedTraversal(Node<T> tKey, List<T> list)
        {
            if (tKey != null)
            {
                OrderedTraversal(tKey.left, list);
                list.Add(tKey.key);
                OrderedTraversal(tKey.right, list);
            }

        }
        public IEnumerable<T> OrderTraversal(Node<T> theKey)
        {
            List<T> result = new List<T>();
            OrderedTraversal(theKey, result);

            return result;

        }
        public IEnumerable<T> OrderTraversal()
        {
            List<T> result = new List<T>();
            OrderedTraversal(root, result);

            return result;

        }





    }

}
