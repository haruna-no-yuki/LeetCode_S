#   858. Mirror Reflection
  
  
  
##  [题目地址](https://leetcode.com/problems/mirror-reflection/ )
  
  
  
##  题目描述
给一个边长为p的正方形，，其四个顶点坐标分别为(0, 0), (p, 0), (p, p), (0, p)
除第一个顶点外，其余三个顶点标记为0，1，2
现从(0, 0)向坐标(p, q)的位置发射一道激光，判断最后激光所击打的顶点是标记的哪个店。
输出保证最后激光会打在某一个非原点的顶点上

  
>
>示例:
>Example 1:
>![](https://s3-lc-upload.s3.amazonaws.com/uploads/2018/06/18/reflection.png )
>输出: 2
>Example 2:
>p = 3, q = 1
>输出: 1
  
  
##  思路
初始想法是模拟激光实时的轨迹，计算出每一次击打的点与反射光向量，后发现颇为繁琐。
从两个输出中获得启示：将由(0, 0) 与 (p, q)组成的射线无限延长，其最后会打在某个点(p1,q1)，其中p1，q1都整除p，且由他们能直接判断最后击打点的位置
例：
![](https://assets.leetcode.com/users/images/c77ce1cd-d6cc-4b2c-93b3-07708e001810_1659572389.3219862.png )
  
  
##  关键点
最小公倍数，最大公约数
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int MirrorReflection(int p, int q) {
        int maxO = p*q/GCD(p, q);
        int[] endPos = new int[]{p * maxO / q , maxO};
        int[] endPoint = new int[2];
        endPoint[0] = ((maxO / q) % 2 == 1)? p:0;
        endPoint[1] = ((maxO / p) % 2 == 1)? p:0;
        if (endPoint[0] == 0){
            return 2;
        }
        if (endPoint[1] == 0){
            return 0;
        }
        else
            return 1;
    }

    private int GCD(int a,int b){
        int temp = 1;
        while(b > 0){
            temp = a % b;
            a = b;
            b = temp;
        }
        return a;
    }
}
```
  
  