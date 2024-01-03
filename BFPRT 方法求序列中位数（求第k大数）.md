#   BFPRT 方法求序列中位数（求第k大数）
  
  
  
##  [参考文章](https://blog.csdn.net/a3192048/article/details/82055183)
  
  
  
##  题目描述
给定 n 个整数，要求返回其中位数，并要求时间复杂度不超过O(n)

  
##  思路
对序列求中位数，即求第（n + 1）/2大的数。更普遍的，我们将其转换为对任一序列，求第k大数，若是求第k小数，则等价为求第（n - k + 1）大数。

因为基于比较法的排序算法的时间复杂的至少为O(nlog<sub>2</sub>n)，所以直接进行排序是不合要求的。且我们只关心第k大数，对整个序列的大小顺序并不关注。

在各种排序算法中，我们发现快速排序的主要思想和题目比较契合：选取一个参考数，将大于它以及小于它的至于它的两侧，后续对左右两边的序列继续进行这种操作。
如果我们能够找到一个合适的参考数，使之在整个序列中的大小位置接近于k，在经过一轮快速排序后，我们就能筛选出需要继续进行快排的序列，从而达到节省计算的效果。

在快速排序中，平均情况下数组被划分成相等的两部分，则时间复杂度为T(n)=2*T(n/2)+O(n)，可以解得T(n)=nlogn
而在快速选择中，平均情况下数组也是分成相等的两部分，但只处理其中一部分，于是T(n)=T(n/2)+O(n)，可以解得T(n)=O(n)。


但是两者在最坏情况下的时间复杂度均为O(n^2)，出现在每次划分之后左右总有一边为空的情况下。为了避免这个问题，需要谨慎地选取划分的主元。
一般的方法有：

固定选择首元素或尾元素作为主元。

随机选择一个元素作为主元。

三数取中，选择三个数的中位数作为主元。一般是首尾数，再加中间的一个数或者随机的一个数。

随后，我们进行一遍快速排序，将比主元小的放在左边，比主元大的放在右边，这个过程也称为Partion。对于Partion过程，通常有两种方法：一种为两个指针从首尾向中间扫描；
另一种是一个指针向后逐步扫描。

![双向Partion]("https://images.cnitblog.com/blog/571227/201412/151304116409231.png")

![双向Partion结果，以72为主元]("https://images.cnitblog.com/blog/571227/201412/151313038754600.png")

在BFPTR算法中，仅仅是改变了快速排序Partion中的主元(pivot)值的选取，在快速排序中，我们始终选择第一个元素或者最后一个元素作为pivot，而在BFPTR算法中，每次选择五分中位数的中位数作为pivot，这样做的目的就是使得划分比较合理，从而避免了最坏情况的发生。算法步骤如下：

（1）将输入数组的个元素划分为Mathf.Ceil(n / 5)组，每组5个元素，且至多只有一个组由剩下的n % 5个元素组成。

（2）寻找每一个组的中位数，首先对每组的元素进行排序，然后从排序过的序列中选出中位数。

（3）对于（2）中找出的个中位数，递归进行步骤（1）和（2），直到只剩下一个数即为这个元素的中位数，找到中位数后并找到在原序列中对应的下标p。

（4）进行Partion划分过程，Partion划分中的pivot元素下标为partionIndex。

（5）进行高低区判断即可。

对于Partion过程，双向相比单向耗时更少。


##  关键点
快速排序，快速选择
  
  
##  代码
  
  
```c
public class Solution
 {
    private static void Swap(List<int> list, int a, int b)
    {
       int temp = list[a];
       list[a] = list[b];
       list[b] = temp;      
    }

    //单向partion过程
    public static int Partion(int l, int r, List<int> list, int partionIndex = -1)
    {
        int pivot = partionIndex < 0 ? list[r] : list[partionIndex];
        int index = l - 1;
        if (partionIndex >= 0)
        Swap(list, r, partionIndex);
        for (int i = l; i < r; i++)
        {
            if (list[i] <= pivot)
            {
                index++;
                Swap(list, index, i);
            }
        }

        Swap(list, index + 1, r);
        return index + 1;
    }

    //双向Partion过程
    public static int PartionForTwoSides(int l, int r, List<int> list, int partionIndex = -1)
    {
        int pivot = partionIndex < 0 ? list[l] : list[partionIndex];
        if (partionIndex >= 0)
        {
            Swap(list, l, partionIndex);
        }

        while (l < r)
        {
            while (list[r] >= pivot && r > l)
                r--;
            list[l] = list[r];
            while (list[l] <= pivot && r > l)
                l++;
            list[r] = list[l];
        }

        list[l] = pivot;
        return l;
    }

    public static void QuickSort(List<int> list, int l, int r, int partionIndex = -1)
    {
        if (l < r)
        {
            //int index = partionIndex > 0 ? partionIndex : Partion(l, r, list);
            int index = partionIndex > 0 ? partionIndex : PartionForTwoSides(l, r, list);
            QuickSort(list, l, index - 1);
            QuickSort(list, index + 1, r);
        }
    }

    //寻找Mathf.Ceil(n / 5)个序列中的总中位数
    public static int FindTotalMid(List<int> list, int l, int r)
    {
        int count = list.Count;
        if (count == 1)
        {
            return list[0];
        }
        int lastIndex = r - l + 1 > 5 ? r + 1 - (r - l + 1) % 5  : l;
        var midList = new List<int>();
        for (int i = l; i < r - 4; i += 5)
        {
            var subList = new List<int>();
            for (int j = 0; j < 5; j++)
            {
                subList.Add(list[i + j]);
            }

            QuickSort(subList, 0, 4);
            midList.Add(subList[2]);
        }

        QuickSort(list, lastIndex, r);
        midList.Add(list[(lastIndex + r) / 2]);
        return FindTotalMid(midList, 0, midList.Count- 1);
    }


    //参数k: 求解序列list中第k大的数
    public static int BFPRT(List<int> list, int l, int r, int k)
    {
        int num = FindTotalMid(list, l, r);
        int index = -1;
        for (int i = l; i < r + 1; i++)
        {
            if (list[i] == num)
            {
                index = i;
                break;
            }
        }

        //int partionIndex = Partion(l, r, list, index);
        int partionIndex = PartionForTwoSides(l, r, list, index);
        int targetIndex = partionIndex - l + 1;

        if (targetIndex == k)
            return list[partionIndex];
        else if (targetIndex > k)
        {
            return BFPRT(list, l, partionIndex - 1, k);
        }
        else
        {
            return BFPRT(list, partionIndex + 1, r, k - targetIndex);
        }
    }
 }
```
  
  