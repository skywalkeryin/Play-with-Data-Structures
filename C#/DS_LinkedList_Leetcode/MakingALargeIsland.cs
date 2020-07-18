using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DS_LinkedList_Leetcode
{
    class MakingALargeIsland
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[][] a = new int[][] {
                new int[]{1},
                //new int[]{1, 0},
            };
            s.LargestIsland(a);
        }
        public class Solution
        {

            int counter = 0;
            int[][] move = new int[][]{
            new int[]{-1, 0 },
            new int[]{ 0, 1 },
            new int[]{ 1, 0 },
            new int[]{ 0, -1 },
            };
            Dictionary<int, int> dict = new Dictionary<int, int>();
            public int LargestIsland(int[][] grid)
            {

                // Mark Islands
                int n = 2;
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == 1)
                        {
                            counter = 0;
                            MarkIsland(grid, n, i, j);
                            if (!dict.ContainsKey(n))
                            {
                                dict.Add(n, counter);
                            }
                            n++;
                        }

                    }
                }
                //SortedDictionary<int, Tuple<int, int>> areaDict = new SortedDictionary<int, Tuple<int, int>>((x, y) => { x > y; });

                int maxArea = 0;
                //
                for (int i = 0; i < grid.Length; i++)
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (grid[i][j] == 0)
                        {
                            int area = ConnectedIsland(grid, i, j);
                            if (area >= maxArea)
                            {
                                maxArea = area;
                            }
                            //if (area > 0)
                            //{
                            //    if (!areaDict.ContainsKey(area))
                            //    {
                            //        areaDict.Add(area, new Tuple<int, int>(i, j));
                            //    }
                            //}
                        }
                    }
                }

                if (maxArea == 0)
                {
                    int temp = 0;
                    foreach (int key in dict.Keys)
                    {
                        if (dict[key] >= temp)
                        {
                            temp = dict[key];
                        }
                    }
                    return temp;
                }
                return maxArea;
                //if (areaDict.Count > 0)
                //{
                //    (int x, int y) = areaDict.First().Value;
                //    grid[x][y] = 1;
                //}

            }

            private int ConnectedIsland(int[][] grid, int x, int y)
            {
                int area = 0;
               
                bool[] connected = new bool[dict.Keys.Count+2];
                for (int i = 0; i < move.Length; i++)
                {
                    int newX = x + move[i][0];
                    int newY = y + move[i][1];
                    if (isInArea(grid, newX, newY) && dict.ContainsKey(grid[newX][newY])
                        && !connected[grid[newX][newY]])
                    {
                        area += dict[grid[newX][newY]];
                      
                        connected[grid[newX][newY]] = true;
                    }
                }
                return  area + 1;
            }

            public void MarkIsland(int[][] grid, int n, int x, int y)
            {

                if (grid[x][y] == 0)
                {
                    return;
                }
                else
                {
                    grid[x][y] = n;
                    counter++;
                }

                for (int i = 0; i < move.Length; i++)
                {
                    int newX = x + move[i][0];
                    int newY = y + move[i][1];

                    if (isInArea(grid, newX, newY) && grid[newX][newY] <= 1)
                    {
                        MarkIsland(grid, n, newX, newY);
                    }
                }
            }

            private bool isInArea(int[][] grid, int x, int y)
            {
                return x >= 0 && x < grid.Length && y >= 0 && y < grid[0].Length;
            }
        }
    }
}
