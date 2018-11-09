using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test1 t1 = new Test1();
            var rlt = t1.TowSum2(new int[] { 2, 3, 5, 6 }, 11);
            Console.WriteLine(string.Join(",", rlt));

            Console.WriteLine($"无重复最长字符串长度：{t1.LengthOfLongestSubstring2("pwoyt8wkew")}");
            Console.WriteLine($"数组长度过滤之后：{string.Join(",", t1.removeDistance(new int[] { 1, 2, 3, 4, 5, 5, 7 }, 5))}");

            Console.WriteLine($"A组对B组的最优排序：{string.Join(",", t1.advantageCount(new int[] { 12, 24, 8, 32 }, new int[] { 13, 25, 32, 11 }))}");
            

            MYLinkList<string> list = new MYLinkList<string>();
            list.Append("abc");
            list.Append("123");
            list.Append("链表数据");
            list.Append("老妈肥肠面");
            list.Append(" ");
            list.Insert("插入数据", 4);//这里的i不是索引
            //list.Delete(" ");
            list.Delete(0);
            Console.WriteLine($"链表总长度为:{list.Length}");
            
            //list.Clear();
            Node<string> current = list.Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }

            DoubleLinkedList<string> dlinked = new DoubleLinkedList<string>();
            dlinked.Append("双向1");
            dlinked.Append("双向2");
            dlinked.Append("双向3");
            dlinked.Append("双向4");
            //dlinked.Insert("插入双向44", 4);
            Console.WriteLine($"双向链表总长度为:{dlinked.Length()}");
            dlinked.Delete("双向4");
            DLinkedNode<string> d = dlinked.First;
            while (d!=null)
            {
                Console.WriteLine(d.Data);
                d = d.Tail;
            }

            Console.WriteLine($"查找目标：{dlinked.Select(34).Data}");

            Console.WriteLine($"求16的平方根{t1.Sqrt(16)}");

            int t = 2;
            int tail = 3;
            Console.WriteLine(t != (t = tail));

            t1.HashM();
            Console.ReadLine();
        }
    }
}
