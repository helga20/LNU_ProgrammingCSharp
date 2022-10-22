/*
 * Ватсон Б.С. C# 4.0 на примерах. 2011. с. 138
 * Створено власну узагальнену колекцію - двійкове дерево
 * Вона реалізує стандартні інтерфейси ICollection, IEnumerable
 * ICollection: property - Count, IsReadOnly
 *                method - Add, Clear, Contains, CopyTo, Remove
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TreeIterator
{
    class BinaryTree<T> : ICollection<T>, IEnumerable<T>
        where T:IComparable<T>
    {
        //this inner class is private because only the tree needs to know about it
        private class Node<T>
        {
            public T Value;
            //these are public fields so that we can use "ref" to simplify
            //the algorithms
            public Node<T> LeftChild;
            public Node<T> RightChild;

            public Node(T val) 
            { this.Value = val; this.LeftChild = this.RightChild = null; }
            public Node(T val, Node<T> left, Node<T> right) 
            { this.Value = val; this.LeftChild = left; this.RightChild = right; }
        }

        private Node<T> _root;
        private int _count = 0;

        public void Add(T item)
        {
            AddImpl(new Node<T>(item), ref _root);
        }

        //a convenience method for adding multple items at once
        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                Add(item);
            }
        }

        private void AddImpl(Node<T> newNode, ref Node<T> parentNode)
        {
            if (parentNode == null)
            {
                parentNode = newNode;
                _count++;
            }
            else
            {
                if (newNode.Value.CompareTo(parentNode.Value) < 0)
                {
                    AddImpl(newNode, ref parentNode.LeftChild);
                }
                else
                {
                    AddImpl(newNode, ref parentNode.RightChild);
                }
            }
        }

        public void Clear()
        {
            _root = null;
            _count = 0;
        }

        public bool Contains(T item)
        {
            foreach (T val in this)
            {
                if (val.CompareTo(item) == 0)
                    return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int index = arrayIndex;
            foreach(T val in InOrder)
            {
                array[index++] = val;
            }
        }

        public int Count { get { return _count; } }

        public bool IsReadOnly { get { return false; } }

        public bool Remove(T item)
        {
            bool removed;
            RemoveImpl(item, ref _root, out removed);
            if (removed)
            {
                _count--;
            }
            return removed;
        }
        
        private Node<T> RemoveImpl(T item, ref Node<T> node, out bool removed)
        {
            if (node != null)
            {
                if (node.Value.CompareTo(item) > 0)
                {
                    node.LeftChild = RemoveImpl(item, ref node.LeftChild, out removed);
                }
                else if (node.Value.CompareTo(item) < 0)
                {
                    node.RightChild = RemoveImpl(item, ref node.RightChild, out removed);
                }
                else
                {
                    if (node.LeftChild == null)
                    {
                        node = node.RightChild;
                        removed = true;
                    }
                    else if (node.RightChild == null)
                    {
                        node = node.LeftChild;
                        removed = true;
                    }
                    else
                    {
                        Node<T> successor = FindSuccessor(node);
                        node.Value = successor.Value;
                        node.RightChild = RemoveImpl(successor.Value, ref node.RightChild, out removed);
                    }
                }
                return node;
            }
            else
            {
                removed = false;
                return null;
            }
        }

        // Find the next node after the passed-in node,
        // while will be the left-most node on the right branch
        private Node<T> FindSuccessor(Node<T> node)
        {
            Node<T> currentNode = node.RightChild;
            while (currentNode.LeftChild != null)
            {
                currentNode = currentNode.LeftChild;
            }
            return currentNode;

        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //Here are the iterators, each represented by a public property 
        //and a recursive function that does all the actual work
        public IEnumerable<T> PreOrder
        {
            get
            {
                return IteratePreOrder(_root);
            }
        }

        private IEnumerable<T> IteratePreOrder(Node<T> parent)
        {
            if (parent != null)
            {
                yield return parent.Value;

                foreach(T item in IteratePreOrder(parent.LeftChild))
                {
                    yield return item;
                }
                foreach(T item in IteratePreOrder(parent.RightChild))
                {
                    yield return item;
                }
            }
        }

        public IEnumerable<T> PostOrder
        {
            get
            {
                return IteratePostOrder(_root);
            }
        }

        private IEnumerable<T> IteratePostOrder(Node<T> parent)
        {
            if (parent != null)
            {
                foreach (T item in IteratePostOrder(parent.LeftChild))
                {
                    yield return item;
                }
                foreach (T item in IteratePostOrder(parent.RightChild))
                {
                    yield return item;
                }

                yield return parent.Value;
            }
        }

        public IEnumerable<T> InOrder
        {
            get
            {
                return IterateInOrder(_root);
            }
        }

        private IEnumerable<T> IterateInOrder(Node<T> parent)
        {
            if (parent != null)
            {
                foreach (T item in IterateInOrder(parent.LeftChild))
                {
                    yield return item;
                }
                
                yield return parent.Value;

                foreach (T item in IterateInOrder(parent.RightChild))
                {
                    yield return item;
                }
            }
        }

        public void WriteStruct()
        {
            WriteStruct(this._root, 0);
        }
        private void WriteStruct(Node<T> root, int shift)
        {
            if (root.LeftChild != null) WriteStruct(root.LeftChild, shift + 3);
            string spaces = new string(' ', shift);
            Console.WriteLine(spaces + root.Value.ToString());
            if (root.RightChild != null) WriteStruct(root.RightChild, shift + 3);
        }
    }
}
