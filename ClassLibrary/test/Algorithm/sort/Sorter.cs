using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Algorithm
{
    public class Sorter
    {
        /// <summary>
        /// 插入排序  O(n二次方)
        /// </summary>
        /// <param name="vs">待排序的数据(int 类型)</param>
        /// <param name="n">数组长度</param>
        public T[] InsertSort<T>(T[] vs) where T:IComparable
        {
            int i,j;
            T temp;int n = vs.Length;
            for (i = 0; i < n-1; i++)
            {
                temp = vs[i + 1];
                j = i;
                while (j > -1 && temp.CompareTo(vs[j]) <= 0)
                {
                    vs[j + 1] = vs[j];
                    j--;
                }
                vs[j + 1] = temp;
            }
            return vs;
        }

        public T[] ShellSort<T>(T[] array) where T : IComparable
        {
            int length = array.Length;
            for (int h = length / 2; h > 0; h = h / 2)
            {
                for (int i = h; i < length; i++)
                {
                    T temp = array[i];
                    if (temp.CompareTo(array[i - h]) < 0)
                    {
                        for (int j = 0; j < i; j += h)
                        {
                            if (temp.CompareTo(array[j]) < 0)
                            {
                                temp = array[j];
                                array[j] = array[i];
                                array[i] = temp;
                            }
                        }
                    }
                }
            }
            return array;
        }
        /// <summary>
        /// n*n
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public T[] DirectSelectSort<T>(T[] arr) where T:IComparable
        {
            T temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                T minVal = arr[i];
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (minVal.CompareTo(arr[i])>0)
                    {
                        minVal = arr[j];
                        minIndex = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }
            return arr;
        }
        //maopao4
        public static void BubbleSort<T>(T[] array, Comparison<T> comparison)
        {
            bool hasExchagend = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = array.Length - 1; j > i; j--)
                {
                    hasExchagend = false;
                    if (comparison(array[j - 1], array[j]) > 0)
                    {
                        T temp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = array[j];
                        hasExchagend = true;
                    }
                }
                if (!hasExchagend)
                {
                    return;
                }
            }
        }

    }
}
