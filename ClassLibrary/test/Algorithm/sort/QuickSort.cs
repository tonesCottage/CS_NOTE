using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test.test.Algorithm
{
    public class QuickSort
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="array">要排序的数组</param>
        /// <param name="low">下标开始位置，向右查找</param>
        /// <param name="high">下标开始位置，向左查找</param>
        public static void Sort(int[] array, int low, int high)
        {
            if (low >= high)
                return;
            //完成一次单元排序
            int index = SortUnit(array, low, high);
            //递归调用，对左边部分的数组进行单元排序
            Sort(array, low, index - 1);
            //递归调用，对右边部分的数组进行单元排序
            Sort(array, index + 1, high);
        }

        /// <summary>
        /// 单元排序
        /// </summary>
        /// <param name="array">要排序的数组</param>
        /// <param name="low">下标开始位置，向右查找</param>
        /// <param name="high">下标开始位置，向右查找</param>
        /// <returns>每次单元排序的停止下标</returns>
        public static int SortUnit(int[] array, int low, int high)
        {
            int key = array[low];//基准数
            while (low < high)
            {
                //从high往前找小于或等于key的值
                while (low < high && array[high] > key)
                    high--;
                //比key小开等的放左边
                array[low] = array[high];
                //从low往后找大于key的值
                while (low < high && array[low] <= key)
                    low++;
                //比key大的放右边
                array[high] = array[low];
            }
            //结束循环时，此时low等于high，左边都小于或等于key，右边都大于key。将key放在游标当前位置。 
            array[low] = key;
            return high;
        }
    }
}
