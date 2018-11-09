using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class MYLinkList<T>
    {
        public Node<T> Head { get; set; }
        private int len;

        public MYLinkList()
        {
            Head = null;
            len = 0;
        }

        public int Length
        {
           get { return len; }
        }

        public void Clear()
        {
            Head = null;
            len = 0;
        }

        public bool IsEmpty()
        {
            return Head == null;
        }

        public void Append(T item)
        {
            if (Head == null)
            {
                Head = new Node<T>(item, null);
                ++len;
                return;
            }

            var p = new Node<T>();
            p = Head;
            while (p.Next != null)
            {
                p = p.Next;
            }
            p.Next = new Node<T>(item, null);
            ++len;
        }

        public void Insert(T item,int i)
        {
            if(IsEmpty() || i<1 || i>Length)
            {
                return;
            }
            //如果在第一个位置插入 则只需要将该节点的next 指向head即可
            if (i == 1)
            {
                var first = new Node<T>(item, null);
                first.Next = Head;
                Head = first;
                ++len;
                return;
            }
            var p = new Node<T>();
            p = Head;
            var left = new Node<T>();
            var right = new Node<T>();
            int j = 1;
            while (p.Next!=null && j<i)
            {
                left = p;
                right = p.Next;
                p = p.Next;
                ++j;
            }
            var q = new Node<T>(item, null);
            left.Next = q;
            q.Next = right;
            ++len;
        }

        public void Delete(T item)
        {
            if (IsEmpty()) return;
            var curr = new Node<T>();
            curr = Head;
            //如果第一个元素就匹配上了
            if (curr.Data.Equals(item))
            {
                Head = curr.Next;
                --len;
                return;
            }
            while (curr.Next!=null && !curr.Next.Data.Equals(item))
            {
                curr = curr.Next;
            }
            if(curr.Next!=null)
            { 
                curr.Next = curr.Next.Next;
                --len;
            }
        }

        public void Delete(uint i)
        {
            if (IsEmpty() || i<1 || i>Length) return;
            var curr = new Node<T>();
            curr = Head;
            if (i == 1)
            {
                Head = curr.Next;
                --len;
                return;
            }

            var prev = new Node<T>();
            int j = 1;
            while (curr.Next!=null && j<i)
            {
                ++j;
                prev = curr;
                curr = curr.Next;
            }

            prev.Next = curr.Next;
            --len;
        }
    }

    public class Node<T>
    {
        private T data;
        private Node<T> next;

        public Node(T item, Node<T> next)
        {
            data = item;
            this.next = next;
        }

        public Node()
        {
            data = default(T);
            this.next = null;
        }

        public Node<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }

        public T Data
        {
            get { return this.data; }
            set { this.data = value; }
        }
    }
}
