using System;
using System.Collections;
using System.Text;

namespace GenericList
{
    // Простий однозв'язний список. Може зберігати значення довільних типів.
    // Узагальнення за рахунок використання типу object.
    // Ітератор отримуємо оператором yield.
    class TList: IEnumerable
    {
        private Node head;
        public Node Head { get { return head; } }
        private Node tail;
        public Node Tail { get { return tail; } }
        public Node AddLast(object obj)
        {
            Node node = new Node(obj, null);
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
        public IEnumerator GetEnumerator()
        {
            Node current = head;

            while (current != null)
            {
                yield return current.Value;
                current = current.next;
            }
        }
    }
    class Node
    {
        public Node(object obj, Node n)
        {
            this.value = obj;
            this.next = n;
        }
        private object value;
        public object Value
        {
            get { return value; }
        }
        public Node next;
        public override string ToString()
        {
            return "Node(" + value.ToString() + ')';
        }
    }

}
