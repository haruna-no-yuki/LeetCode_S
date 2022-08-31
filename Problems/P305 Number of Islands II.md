#   305. Number of Islands II
  
  
  
##  [题目地址](https://leetcode.cn/problems/number-of-islands-ii/ )
  
  
  
##  题目描述
给你一个大小为 m x n 的二进制网格 grid 。网格表示一个地图，其中，0 表示水，1 表示陆地。最初，grid 中的所有单元格都是水单元格（即，所有单元格都是 0）。

可以通过执行 addLand 操作，将某个位置的水转换成陆地。给你一个数组 positions ，其中 positions[i] = [ri, ci] 是要执行第 i 次操作的位置 (ri, ci) 。

返回一个整数数组 answer ，其中 answer[i] 是将单元格 (ri, ci) 转换为陆地后，地图中岛屿的数量。

岛屿 的定义是被「水」包围的「陆地」，通过水平方向或者垂直方向上相邻的陆地连接而成。你可以假设地图网格的四边均被无边无际的「水」所包围。
  
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2021/03/10/tmp-grid.jpg )
>输出: [1,1,2,3]
>
>Example 2:
>m = 1, n = 1, positions = [ [0,0] ]
>输出: [1]
  
  
##  思路
此题是基于 P200 Number of Islands 的变种而来，在P200中，我们使用了DFS对每块陆地进行了搜索，同时将已经遍历过的陆地设为水，在这里，我们尝试类似的做法。
初始状态下，正片区域全都是水。每当我们加入一块陆地，我们向四周寻找其是否与其他陆地接壤。如果四周都是水，那么岛屿数+1，如果不是，则岛屿数保持不变甚至减少，具体取决于其与多少块岛屿相连。

我们构造这样一种数据结构：

    一个由字典组成的HashSet，每个字典代表一块岛屿。其中我们希望字典能够存储岛屿内部所有陆地的坐标。考虑到我们需要经常遍历字典去寻找是否有与待插入的陆地相接壤的陆地，字典的键为int， 值为int集合的HashSet。
    这样的数据结构能够有效的存储岛屿内部的坐标： 字典键为横坐标，值为在该横坐标下岛屿包含的纵坐标
    这样一来，我们便可每次插入陆地时去遍历哪些岛屿与之接壤。

    知道了接壤具体细节，我们进一步讨论它对岛屿数量的影响：
        1.零接壤，岛屿+1；
        2.1接壤，岛屿不变；
        3.2接壤：如果两边接壤的陆地同属一个岛屿，那么岛屿数量不变，否则岛屿数量 -1
        4.3 或 4 接壤，与第三种条件类似

    值得注意的是，不存在一个陆地被复数个岛屿包含，因为在插入陆地的过程中我们保证了独一性
    另外，在计算岛屿数量——也就是Hashset中的字典数时，需注意合并岛屿的过程中可能会把联合岛屿本身移除，所以需要加一个判断在移除操作后联合岛屿是否存在于HashSet内
    最后，由于字典与HashSet的特性，我们可以在一次遍历中找到四个与待插入陆地相邻的格子的具体细节，而不是分别遍历4次


  
  
##  关键点
DFS, HashSet
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public IList<int> NumIslands2(int m, int n, int[][] positions) {
        HashSet<Dictionary<int, HashSet<int>>> islands = new HashSet<Dictionary<int, HashSet<int>>>();
        List<int> ansList = new List<int>();
        for (int j = 0; j < positions.Length; j++)
        {
            CheckInsertIsland(islands, positions[j]);
            ansList.Add(islands.Count);
        }
        return ansList;
    }


    private void CheckInsertIsland(HashSet<Dictionary<int, HashSet<int>>> islands, int[] positions){
        int x = positions[0];
        int y = positions[1];
        Dictionary<int, HashSet<int>>[] dicArr = CheckIsIsland(islands,x,y);
        if (dicArr == null) return;
        int index = -1;
        for (int i = 0; i < dicArr.Length; i++)
        {
            if (dicArr[i] != null){
                index = i;
                if (dicArr[i].ContainsKey(x))
                    dicArr[i][x].Add(y);
                else
                {
                    HashSet<int> newInsertHash = new HashSet<int>();
                    newInsertHash.Add(y);
                    dicArr[i].Add(x, newInsertHash);                
                }
                break;
            }
        }
        if (index < 0){
            Dictionary<int, HashSet<int>> newDic = new Dictionary<int, HashSet<int>>();
            HashSet<int> hash = new HashSet<int>();
            hash.Add(y);
            newDic.Add(x,hash);
            islands.Add(newDic);
            return;
        }
        else
        {
            for (int i = 0; i < dicArr.Length; i++)
            {
                if (i != index && dicArr[i] != null){
                    foreach (int xPos in dicArr[i].Keys)
                    {
                        if (dicArr[index].ContainsKey(xPos))
                            dicArr[index][xPos].UnionWith(dicArr[i][xPos]);
                        else
                        {
                            dicArr[index].Add(xPos, dicArr[i][xPos]);
                        }
                    }
                    islands.Remove(dicArr[i]);
                }
            }
            if (!islands.Contains(dicArr[index]))
                islands.Add(dicArr[index]);
        }
    }

    private Dictionary<int, HashSet<int>>[] CheckIsIsland(HashSet<Dictionary<int, HashSet<int>>> islands, int x, int y){
        Dictionary<int, HashSet<int>>[] dicArr = new Dictionary<int, HashSet<int>>[4];
        foreach (var item in islands)
        {
            if(item.ContainsKey(x) && item[x].Contains(y)){
                return null;
            }
            else if (item.ContainsKey(x + 1) && item[x + 1].Contains(y)){
                dicArr[0] = item;
            }
            else if (item.ContainsKey(x - 1) && item[x - 1].Contains(y)){
                dicArr[1] = item;
            }
            else if (item.ContainsKey(x) && item[x].Contains(y + 1)){
                dicArr[2] = item;
            }
            else if (item.ContainsKey(x) && item[x].Contains(y - 1))
            {
                dicArr[3] = item;
            }
        }
        return dicArr;
    }
}
```
  
  