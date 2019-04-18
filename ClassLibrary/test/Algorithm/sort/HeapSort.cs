using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Algorithm
{
    public class HeapSort
    {
        /// <summary>  
        /// 堆排序方法。  
        /// </summary>  
        /// <param name="a">  
        /// 待排序数组。  
        /// </param>  
        private void Heapsort(int[] a)
        {
            HeapSort_BuildMaxHeap(a); // 建立大根堆。  
            Console.WriteLine("Build max heap:");
            foreach (int i in a)
            {
                Console.Write(i + " "); // 打印大根堆。  
            }

            Console.WriteLine("\r\nMax heap in each iteration:");
            for (int i = a.Length - 1; i > 0; i--)
            {
                HeapSort_Swap(ref a[0], ref a[i]); // 将堆顶元素和无序区的最后一个元素交换。  
                HeapSort_MaxHeaping(a, 0, i); // 将新的无序区调整为大根堆。  

                // 打印每一次堆排序迭代后的大根堆。  
                for (int j = 0; j < i; j++)
                {
                    Console.Write(a[j] + " ");
                }

                Console.WriteLine(string.Empty);
            }
        }

        /// <summary>  
        /// 由底向上建堆。由完全二叉树的性质可知，叶子结点是从index=a.Length/2开始，所以从index=(a.Length/2)-1结点开始由底向上进行大根堆的调整。  
        /// </summary>  
        /// <param name="a">  
        /// 待排序数组。  
        /// </param>  
        private static void HeapSort_BuildMaxHeap(int[] a)
        {
            for (int i = (a.Length / 2) - 1; i >= 0; i--)
            {
                HeapSort_MaxHeaping(a, i, a.Length);
            }
        }

        /// <summary>  
        /// 将指定的结点调整为堆。  
        /// </summary>  
        /// <param name="a">  
        /// 待排序数组。  
        /// </param>  
        /// <param name="i">  
        /// 需要调整的结点。  
        /// </param>  
        /// <param name="heapSize">  
        /// 堆的大小，也指数组中无序区的长度。  
        /// </param>  
        private static void HeapSort_MaxHeaping(int[] a, int i, int heapSize)
        {
            int left = (2 * i) + 1; // 左子结点。  
            int right = 2 * (i + 1); // 右子结点。  
            int large = i; // 临时变量，存放大的结点值。  

            // 比较左子结点。  
            if (left < heapSize && a[left] > a[large])
            {
                large = left;
            }

            // 比较右子结点。  
            if (right < heapSize && a[right] > a[large])
            {
                large = right;
            }

            // 如有子结点大于自身就交换，使大的元素上移；并且把该大的元素调整为堆以保证堆的性质。  
            if (i != large)
            {
                HeapSort_Swap(ref a[i], ref a[large]);
                HeapSort_MaxHeaping(a, large, heapSize);
            }
        }

        /// <summary>  
        /// 交换两个整数的值。  
        /// </summary>  
        /// <param name="a">整数a。</param>  
        /// <param name="b">整数b。</param>  
        private static void HeapSort_Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
