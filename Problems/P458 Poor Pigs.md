#   458. Poor Pigs

  
  
  
##  [题目地址](https://leetcode.com/problems/poor-pigs/ )
  
  
  
##  题目描述
有 buckets 桶液体，其中 正好有一桶 含有毒药，其余装的都是水。它们从外观看起来都一样。为了弄清楚哪只水桶含有毒药，你可以喂一些猪喝，通过观察猪是否会死进行判断。不幸的是，你只有 minutesToTest 分钟时间来确定哪桶液体是有毒的。

喂猪的规则如下：

选择若干活猪进行喂养
可以允许小猪同时饮用任意数量的桶中的水，并且该过程不需要时间。
小猪喝完水后，必须有 minutesToDie 分钟的冷却时间。在这段时间里，你只能观察，而不允许继续喂猪。
过了 minutesToDie 分钟后，所有喝到毒药的猪都会死去，其他所有猪都会活下来。
重复这一过程，直到时间用完。
给你桶的数目 buckets ，minutesToDie 和 minutesToTest ，返回 在规定时间内判断哪个桶有毒所需的 最小 猪数 。

>
>示例:
>Example 1:
>buckets = 1000, minutesToDie = 15, minutesToTest = 60
>输出: 5
>
>Example 2:
>buckets = 4, minutesToDie = 15, minutesToTest = 15
>输出: 2
  
  
##  思路
最初接触这道题是因为P50 Pow(x,y)中有提到此题在位运算上有类似之处。实际做起来发现，只能说有点牵强附会。
易知可实验次数times = minutesToTest / minutesToDie，对最简单的times = 1的情况，我发现对每一桶水，存在被每一只猪喝掉的可能性，进一步的，如果每一桶水都能确定是被哪些猪喝下，那么有毒的水就能分辨出来。
等价的，每桶水被哪些猪喝掉化为二进制数，那么n头猪最多能分辨$2^n$个水桶，times = 1到此解决。
但是在接下来分析times > 1时我陷入了误区，开始纠结如何分组与猪喝下水后死亡而导致的下一次实验中猪数量的变化，最后没能解出通用解。
查阅他人评论后，发现对应times > 1的情况，可以将每桶水根据第i头猪对其的行为标记为：，没有被喝——0，第一轮实验喝下——1，第二轮实验喝下——2....以此类推，最后我们得到一个(times + 1)进制的序列，在这个序列下，每桶水都有唯一标号，也就能确认哪桶水有毒了。
  
  
  
##  关键点
x进制
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int PoorPigs(int buckets, int minutesToDie, int minutesToTest) {
        int times = minutesToTest / minutesToDie;
        return (int)(Math.Ceiling(Math.Log(buckets, (times + 1))));
    }
}
```
  
  