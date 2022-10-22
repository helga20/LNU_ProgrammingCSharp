using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace TreeIterator
{
    // Двійкове дерево пошуку містить цілі значення, не обов'язково різні
    // ліворуч від кореня - вершини з меншими значеннями, а праворуч - з більшими
    // Додатково дерево реалізує інтерфейс "Перелік": приклад використання yield return

    class BinaryTree : IEnumerable
    {
        // вершину дерева моделює клас Node
        // він об'єднує значення, кількість повторень цього значення і вказівники на піддерева
        // всі поля відкриті, бо клас не використовується ніде поза межами дерева
        private class Node
        {
            public int value;
            public int count;
            public Node left;
            public Node right;
            public Node(int v, Node l, Node r)
            {
                value = v; count = 1; left = l; right = r;
            }
            public Node(int v) : this(v, null, null) { }
        }
        
        // --- Прихована частина --------------------------------------------------------------------
        // містить корінь дерева
        // і реалізацію всіх рекурсивних методів обходу дерева
        // всі обходи - симетричні лівосторонні (left inorder)
        private Node root;

        // вставити значення х в піддерево з коренем root
        private void Insert(int x, ref Node root)
        {
            if (root == null) root = new Node(x);               // на порожньому дереві виріс листок
            else if (x < root.value) Insert(x, ref root.left);  // менші - ліворуч від кореня
            else if (x > root.value) Insert(x, ref root.right); // більші - праворуч
            else ++(root.count);                                // рівні - тут, збільшуєм лічильник
        }

        // вилучити значення х з піддерева з коренем root
        private bool Delete(int x, ref Node root)
        {
            bool success = false;             // свідчить про те, чи знайшли вершину зі значенням х
            if (root != null)
            {                                 // пошук тільки в непорожньому дереві
                if (x < root.value) success = Delete(x, ref root.left);
                else if (x > root.value) success = Delete(x, ref root.right);
                else
                {                             // не менше & не більше - значить рівне, знайшли
                    success = true;
                    if (root.count > 1) --(root.count);
                    else                      // вилучити вершину дерева
                    {                         // виконується просто для листків і вершин з одним нащадком
                        if (root.left == null) root = root.right;
                        else if (root.right == null) root = root.left;
                        else                  // вершину з двома нащадками замінюємо
                        {                     // крайнім правим листком лівого піддерева
                            Node node = root.left;
                            if (node.right == null)
                            {
                                root.value = node.value; root.count = node.count;
                                root.left = node.left;
                            }
                            else
                            {
                                while (node.right.right != null) node = node.right;
                                root.value = node.right.value; root.count = node.right.count;
                                node.right = node.right.left;
                            }
                        }
                    }
                }
            }
            return success;
        }

        // визначити кількість входження елемента х в піддерево з коренем root
        int OccurencesOf(int x, Node root)
        {
            if (root == null) return 0;
            else if (x < root.value) return OccurencesOf(x, root.left);
            else if (x > root.value) return OccurencesOf(x, root.right);
            else return root.count;
        }

        // надрукувати вміст дерева в рядок зліва направо
        private void WriteOut(Node root)
        {
            if (root.left != null) WriteOut(root.left);
            for (int i = 0; i < root.count; ++i) Console.Write(" {0}", root.value);
            Console.WriteLine();
            if (root.right != null) WriteOut(root.right);
        }

        // відобразити структуру дерева за допомогою відступів від лівого краю екрана
        private void WriteStruct(Node root, int shift)
        {
            if (root.left != null) WriteStruct(root.left, shift + 5);
            string spaces = new string(' ', shift);
            Console.WriteLine(spaces + "{0}x{1}", root.value, root.count);
            if (root.right != null) WriteStruct(root.right, shift + 5);
        }

        // ітератор перебору реалізовано за допомогою yield return
        private IEnumerable IterateInOrder(Node root)
        {
            if (root != null)
            {
                foreach (int x in IterateInOrder(root.left)) yield return x;
                for (int i = 0; i < root.count; ++i)
                    yield return root.value;
                foreach (int x in IterateInOrder(root.right)) yield return x;
            }
            else
                yield break;
        }
        
        // --- Відкрита частина ---------------------------------------------------------------
        // містить "парадні" методи для зручного виклику "робочих конячок"

        public void Insert(int x)
        {
            Insert(x, ref this.root);
        }
        // додатковий метод для швидкого вставляння в дерево послідовності цілих (масив чи через кому)
        public void Add(params int[] items)
        {
            foreach(int x in items) Insert(x);
        }
        public bool Delete(int x)
        {
            return Delete(x, ref this.root);
        }
        public int OccurencesOf(int x)
        {
            return OccurencesOf(x, this.root);
        }
        public void WriteOut()
        {
            WriteOut(this.root);
        }
        public void WriteStruct()
        {
            WriteStruct(this.root, 0);
        }

        // реалізація інтерфейсу
        public IEnumerator GetEnumerator()
        {
            return InOrder.GetEnumerator();
        }
        public IEnumerable InOrder
        {
            get { return IterateInOrder(this.root); }
        }

        // методи додано для тестування швидкодії рекурсивного та ітерованого перебору дерева
        public long SumRec()
        {
            return Sum(root);
        }
        private long Sum(Node node)
        {
            if (node == null) return 0;
            else
            {
                long S = Sum(node.left);
                for (int i = 0; i < node.count; ++i) S += node.value;
                return S + Sum(node.right);
            }
        }
        public long SumIter()
        {
            long S = 0;
            foreach (int x in InOrder) S += x;
            return S;
        }
    }
}
