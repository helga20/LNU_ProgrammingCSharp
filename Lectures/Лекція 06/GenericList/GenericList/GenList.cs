using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericList
{
    // Узагальнений аналог списку TList. Зберігає значення одного типу - типу Т.
    // Щоб реалізувати узагальнений інтерфейс, доведеться визначити два методи:
    // узагальнений і звичайний.
    class TList<T> : IEnumerable<T>
    {
        private Node<T> head;
        public Node<T> Head { get { return head; } }
        private Node<T> tail;
        public Node<T> Tail { get { return tail; } }
        public Node<T> AddLast(T obj)
        {
            Node<T> node = new Node<T>(obj, null);
            if (head == null)
            {
                head = node; tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
            return node;
        }
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Node<T>
    {
        public Node(T obj, Node<T> n)
        {
            this.value = obj;
            this.next = n;
        }
        private T value;
        public T Value
        {
            get { return value; }
        }
        public Node<T> next;
    }
}