using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Test1
    {
        #region 找2位数求和的索引

        /// <summary>
        /// 暴力遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TowSum(int[] nums,int target)
        {
            for (int i= 0;i< nums.Length;i++)
            {
                for (int j=0;j<nums.Length;j++)
                {
                    if (target - nums[i] == nums[j])
                        return new int[] { i, j };
                }
            }
            throw new AggregateException("没有2位数求和数值");
        }

        /// <summary>
        /// 两遍哈希
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TowSum2(int[] nums,int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            System.Collections.Hashtable table = new System.Collections.Hashtable();
            
            for(int i = 0; i < nums.Length; i++)
            {
                dic.Add(i, nums[i]);
            }
            for (int j=0;j<nums.Length;j++)
            {
                int comp = target - nums[j];
                if(dic.ContainsValue(comp) && dic.Where(m => m.Value == comp).FirstOrDefault().Key != j)
                {
                    return new int[] { j, dic.Where(m => m.Value == comp).FirstOrDefault().Key };
                }
            }
            throw new AggregateException("没有2位数求和数值");
        }

        public int[] TowSum3(int[] nums,int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int comp = target - nums[i];
                if(dic.ContainsValue(comp))
                {
                    return new int[] { i, dic.Where(m => m.Value == comp).FirstOrDefault().Key };
                }
                dic.Add(i, nums[i]);
            }
            throw new AggregateException("没有2位数求和数值");



        }

        #endregion



        #region 无重复字符的最长子串长度

        /// <summary>
        /// 暴力破解法
        /// 时间复杂度：O(n³)   
        /// 
        /// 空间复杂度：O(min(n,m))
        /// 我们需要 O(k)O(k) 的空间来检查子字符串中是否有重复字符，其中 kk 表示 Set 的大小。而 Set 的大小取决于字符串 nn 的大小以及字符集/字母 mm 的大小。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {
            int n = s.Length;
            int ans = 0;
            for (int i=0;i<n;i++)
            {
                for (int j=i+1;j<=n;j++)
                {
                    if (allUnique(s, i, j))
                        ans = Math.Max(ans, j - i);
                }
            }
            return ans;
        }

        public bool allUnique(string s,int start,int end)
        {
            HashSet< Char> set = new HashSet<Char>();
            for (int i = start; i < end; i++)
            {
                char ch = s[i];
                if (set.Contains(ch)) return false;
                set.Add(ch);
            }

            
            return true;
        }

        /// <summary>
        /// 滑动窗口
        /// 时间复杂度：O(2n) = O(n)O(2n)=O(n)，在最糟糕的情况下，每个字符将被 ii 和 jj 访问两次
        /// 空间复杂度：O(min(m, n))O(min(m,n))，与之前的方法相同。滑动窗口法需要 O(k)O(k) 的空间，其中 kk 表示 Set 的大小。而Set的大小取决于字符串 nn 的大小以及字符集/字母 mm 的大小
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring2(string s)
        {
            int n = s.Length;
            int i = 0, j = 0, ans = 0;
            HashSet<char> set = new HashSet<char>();
            while (i < n && j < n)
            {
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j++]);
                    ans = Math.Max(ans, j - i);
                }
                else
                    set.Remove(s[i++]);
            }
            return ans;
        }
        #endregion

        /// <summary>
        /// 返回非val值的数组长度
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int[] removeDistance(int[] arr , int val)
        {
            int x = 0;
            for (int i=0;i<arr.Length;i++)
            {
                if(val!=arr[i])
                {
                    arr[x] = arr[i];
                    x++;
                }
            }
            return arr;
        }

        /// <summary>
        /// A对于B中数字排列的最优解
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public int[] advantageCount(int[] A,int[] B)
        {
            Dictionary<int, int> sortB = new Dictionary<int, int>();
            A = A.OrderBy(m => m).ToArray();
            List<int> assigned = new List<int>();//需要的
            List<int> remaining = new List<int>();//弃掉的
            Dictionary<int, int> answer = new Dictionary<int, int>();
            for (int i = 0; i < B.Length; i++)
            {
                sortB.Add(i, B[i]);
            }
            var sortValB = sortB.OrderBy(m => m.Value).ToList();//值按升序排列
            int j = 0;
            for (int i=0;i<sortValB.Count;i++)
            {
                var itm = sortValB[i];//B中从最小依次循环比对

                for (; j<A.Length;)
                {
                    if(A[j]>itm.Value)
                    {
                        assigned.Add(A[j]);
                        j++;
                        break;
                    }
                    else
                    {
                        remaining.Add( A[j]);
                        j++;
                    }
                }

            }
            assigned = assigned.Concat(remaining).ToList();
            for(int i = 0; i < sortValB.Count; i++)
            {
                answer.Add(sortValB[i].Key, assigned[i]);
            }
            return answer.OrderBy(m => m.Key).ToList().Select(m => m.Value).ToArray();
            

        }

        public int GetBSCodeLength(int n)
        {
            var a = 0;
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    a++;
                }
                //n &= (n - 1);
                n >>= 1;
            }
            return a;
            
        }
        public int GetBSCodeLength2(int n)
        {
            int n1 = n & 0xFFFF;
            int n2 = (n >> 16) & 0xFFFF;
            var i = GetBSCodeLength(n1) + GetBSCodeLength(n2);
            return i;
        }

        public int BinarySearch(int[] arr, int low, int high, int target)
        {
            if (low > high) return -1;
            var mid = arr.Length / 2;
            if (arr[mid] == target) return mid;
            if(arr[mid]>target)
            {
                return BinarySearch(arr, low, mid - 1, target);
            }
            else
            {
                return BinarySearch(arr, mid + 1, high, target);
            }
        }

        public double Sqrt(int a)
        {
            double x1 = a / 2;
            return SqrtDetail(a, x1);
        }

        /// <summary>
        /// 牛顿迭代法算平方根
        /// </summary>
        /// <param name="a"></param>
        /// <param name="xn"></param>
        /// <returns></returns>
        private double SqrtDetail(double a,double xn)
        {
            double uxi = 0.001;//迭代误差系数
            double x2 = (xn + a / xn) / 2;
            if (Math.Abs(xn - x2) > uxi) return SqrtDetail(a, x2);
            return x2;
        }

        public void HashM()
        {
            var s1 = "";
            var hs1= s1.GetHashCode();
            HashSet<KeyValuePair< int,int>> hs = new HashSet<KeyValuePair<int, int>>();
            var a1 = hs.Add(new KeyValuePair<int, int>(11,21));
            var a2 = hs.Add(new KeyValuePair<int, int>(11, 22));
            var a3 = hs.Add(new KeyValuePair<int, int>(11, 23));
            //hs 长度始终为1

            List<int> lst = new List<int>();
            lst.Add(11);
            lst.Add(11);
            lst.Add(11);
            lst.Add(11);
            lst.Add(11);//lst长度为5
        }

        

    }
}
