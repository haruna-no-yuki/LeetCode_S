#   50. Pow(x, n)
  
  
  
##  [题目地址](https://leetcode.com/problems/powx-n/ )
  
  
  
##  题目描述
算x^n
已知返回结果在int范围内，n可取到 int.Max和int.Min
  
  
##  思路
一眼就知线性循环求解一定会超时。所以我们用取对数的方式求解。
求解过程中，可以直接对n进行分治，这样会对n的奇偶有要求。
也可以直接用基底逐层网上叠，但这样需要注意int的上下界导致的比较出错。
更要注意int.Min的绝对值会超过int的范围

在分治的过程中，我们注意到，对局部n为奇数时，其乘以的底数时中间值midVal，而非最初的x
这是因为在拆分过程中，我们将n化为了: (((...)*2)+1)*2)*（...）类似这种形式
注意到这里与二进制的拆分十分接近
于是我们便联想到用位运算解决。
将n化为二进制数，则对应的结果为n = 2^i1 + 2^i2 + .... ,对应二进制向量(i1, i2, i3, ....)
则由线性循环即可得到最终解
每一次循环内，n右移一位，对应2的阶层加一，乘以的系数x也做平方，$对应(x^{2^i})^2$
下面所给的代码，方法1为自己最原始的解法，方法2参考了他人做法直接对n取2除，方法3是自己在利用位运算的提示下的思考，方法4为位运算的最终形态。

  
##  关键点
int.Max,int.Min 2^31
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public double MyPow(double x, int n) {
        if (n == int.MinValue){
            return 1/(PowForNSquare(x, int.MaxValue, x, 1) * x);
        }
        int nIndex = Math.Abs(n);
        return n >= 0 ? PowForNSquare(x, nIndex, x, 1) : 1/(PowForNSquare(x, nIndex, x, 1));
    }
    

    private double PowForNSquare(double x, int n, double midVal, int index){
        if (n == 0){return 1;}
        if (n == 1){ return midVal;}
        midVal *= midVal;
        bool flag = index >= (1 << 29);
        if (!flag){
            index *= 2;
        } 
        if (index == n){return midVal;}
        else if (flag || index > n) {
            return Math.Sqrt(midVal) * PowForNSquare(x, n - (flag ? index : index / 2), x, 1);
        }
        else if (index < n){
            return PowForNSquare(x, n, midVal, index);
        }
        return 0;
    }
}
```

* **方法2**
```c
public class Solution {
    public double MyPow(double x, int n) {
        if (n == int.MinValue){
            return 1/(PowForNSquare(x, int.MaxValue, x) * x);
        }
        int nIndex = Math.Abs(n);
        return n >= 0 ? PowForNSquare(x, nIndex, x) : 1/(PowForNSquare(x, nIndex, x));
    }
    

    private double PowForNSquare(double x, int n, double midVal){
        if (n == 0){return 1;}
        if (n == 1){ return midVal;}
        int temp = n / 2;
        if (n % 2 == 1) {
            return PowForNSquare(x, n - 1, midVal) * midVal;
        }
        else{
            return PowForNSquare(x, temp, midVal * midVal);
        }
    }
}
```


* **方法3**
```c
public class Solution {
    public double MyPow(double x, int n) {
        bool flag = n == int.MinValue;
        int nIndex = flag ? int.MaxValue : Math.Abs(n);
        List<int> list = new List<int>();
        while (nIndex > 0){
            list.Add(nIndex % 2);
            nIndex /= 2;
        }
        double recentVal,ans;
        ans = recentVal = 1;
        for (int i = 0; i < list.Count; i++)
        {
            double temp = i == 0 ? x : recentVal * recentVal;
            ans *= list[i] == 0 ? 1 : temp;
            recentVal = temp;
        }
        if (flag){
            return 1/ (ans * x);
        }
        else if (n < 0){
            return 1/ ans;
        }
        else{
            return ans;
        }
    }
}
```

* **方法4**
```c
public class Solution {
    public double MyPow(double x, int n) {
        if (n < 0){
            if (n == int.MinValue){
                return 1/(MyPow(x, int.MaxValue) * x);
            }
            else{
                return 1/MyPow(x, -n);
            }
        }
        double ans;
        ans = 1;
        while (n > 0){
            if ((n & 1) == 1){
                ans *= x;
            }
            x *= x;
            n = n >> 1;
        }
        return ans;
    }
}
```
  