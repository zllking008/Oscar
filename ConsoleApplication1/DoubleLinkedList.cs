using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class DoubleLinkedList<T>
    {
        public DLinkedNode<T> First { get; set; }

        public DoubleLinkedList()
        {
            First = null;
        }

        public int Length()
        {
            var p = First;
            var len = 0;
            while (p != null)
            {
                ++len;
                p = p.Tail;
            }
            return len;
        }
        public void Clear()
        {
            First = null;
        }

        public bool IsEmpty()
        {
            return First == null;
        }

        public DLinkedNode<T> Select(int index)
        {
            if (index < 1 || index > Length()) return new DLinkedNode<T>();
            var p = new DLinkedNode<T>();
            p = First;
            int i = 1;
            while (i < index)
            {
                i++;
                p = p.Tail;
            }
            return p;
        }

        public void Append(T item)
        {
            if (First == null)
            {
                First = new DLinkedNode<T>(item, null,null);
                return;
            }

            var p = new DLinkedNode<T>();
            p = First;
            while (p.Tail != null)
            {
                p = p.Tail;
            }
            p.Tail = new DLinkedNode<T>(item, p, null);
        }

        public void Insert(T item,int i)
        {
            if (IsEmpty() || i < 1)
                return;
            if (i > Length()) { 
                Append(item);
                return;
            }
            if (i == 1)
            {
                DLinkedNode<T> p = new DLinkedNode<T>(item, null, First);
                First.Prev = p;
                First = p;
                return;
            }
            int j = 1;
            DLinkedNode<T> left = new DLinkedNode<T>();
            DLinkedNode<T> newNode = new DLinkedNode<T>(item,null,null);
            DLinkedNode<T> current = new DLinkedNode<T>();
            current = First;
            while(current!=null && j < i)
            {
                ++j;
                left = current;
                current = current.Tail;
            }
            left.Tail = newNode;
            newNode.Prev = left;
            newNode.Tail = current;
            current.Prev = newNode;

        }

        public void Delete(T item)
        {
            if (IsEmpty()) return;
            var current = new DLinkedNode<T>();
            current = First;
            if (First.Data.Equals(item))
            {
                First = current.Tail;
                First.Prev = null;
                return;
            }
            while (current != null && !current.Data.Equals(item))
            {
                current = current.Tail;
            }
            if (current.Tail != null)//最后一个元素不进入
                current.Tail.Prev = current.Prev;
            current.Prev.Tail = current.Tail;
        }

        public void Delete(uint i)
        {
            if (IsEmpty() || i < 1 || i > Length()) return;

            var current = new DLinkedNode<T>();
            current = First;
            if (i == 1)
            {
                First = current.Tail;
                First.Prev = null;
                return;
            }
            int j = 1;
            while (current!=null && j<i)
            {
                ++j;
                current = current.Tail;
            }
            if (current.Tail != null)//最后一个元素不进入
                current.Tail.Prev = current.Prev;
            current.Prev.Tail = current.Tail;
            
        }
    }

    public class DLinkedNode<T>
    {
        private T data;
        private DLinkedNode<T> prev;
        private DLinkedNode<T> tail;

        public DLinkedNode(T data,DLinkedNode<T> prev,DLinkedNode<T> tail)
        {
            this.data = data;
            this.prev = prev;
            this.tail = tail;
        }
        public DLinkedNode()
        {
            data = default(T);
            this.prev = null;
            this.tail = null;
        }

        public T Data
        {
            get { return data; }
            set { this.data = value; }
        }

        public DLinkedNode<T> Prev
        {
            get { return prev; }
            set { this.prev = value; }
        }

        public DLinkedNode<T> Tail
        {
            get { return tail; }
            set { this.tail = value; }
        }
    }
}
