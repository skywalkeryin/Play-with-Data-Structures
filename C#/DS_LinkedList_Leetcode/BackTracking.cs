using System;
using System.Collections.Generic;
using System.Text;

namespace DS_LinkedList_Leetcode
{
    public class BackTracking
    {
        #region "17"
        static string[] array = { "", "abc", "def", "ghi", "jkf", "mno", "pqrs", "tuv", "wxyz" };
        static List<string> res = new List<string>();

        public static IList<string> LetterCombinations(string digits)
        {

            GenerateCombinations(digits, 0, "");
            return res;
        }

        public static void GenerateCombinations(string digits, int index, string s)
        {
            if (index == digits.Length - 1)
            {
                res.Add(s);
                return;
            }

            int digit = Int16.Parse(digits[index].ToString());

            for (int i = 0; i < array[digit].Length; i++)
            {
                string c = array[digit][i].ToString();
                GenerateCombinations(digits, index + 1, s + c);
            }
            return;
        }
        #endregion


        #region

        static IList<IList<int>> res2 = new List<IList<int>>();
        static bool[] used = new bool[10];

        public static IList<IList<int>> Permute(int[] nums)
        {

            IList<int> p = new List<int>();
            GeneratePermu(nums, 0, p);
            return res2;
        }


        public static void GeneratePermu(int[] nums, int index, IList<int> p)
        {
            if (index == nums.Length)
            {
                res2.Add(p);
               
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!used[nums[i]])
                {
                    p.Add(nums[i]);
                    used[nums[i]] = true;
                    GeneratePermu(nums, index + 1, p);
                    p.RemoveAt(p.Count - 1);
                    used[nums[i]] = false;
                }
            }
            return;
        }
        #endregion

        #region
        // 规定上右下左 四个方向 的x， y的移动
        static int[][] move = new int[][] { new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 } };

        static int m, n;

        static bool[][] visted;
        public static bool Exist(char[][] board, string word)
        {

            m = board.Length;
            n = board[0].Length;

            visted = new bool[m][];
            for (int i = 0; i < m; i++)
            {
                visted[i] = new bool[n];
            }

            // 遍历二维数组， 依次用回溯法查找是否存在给定的字符串
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                   if(FindCombinations(board, word, 0, i, j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        // 寻找index位置的字符
        public static bool FindCombinations(char[][] board, string word, int index, int startX, int startY)
        {
            if (index == word.Length)
            {
                return true;
            }

            if (isArea(startX, startY))
            {
                if (board[startX][startY] != word[index])
                {
                    return false;
                }
            }

            visted[startX][startY] = true;
            // 依次上有下左四个方向去寻找    
            for (int i = 0; i < move.Length; i++)
            {
                int newX = startX + move[i][0];
                int newY = startY + move[i][1];
                if (isArea(newX, newY) && !visted[newX][newY])
                {
                    if (FindCombinations(board, word, index + 1, newX, newY))
                    {
                        return true;
                    }
                }
            }
            visted[startX][startY] = false;

            return false;
        }

        private static bool isArea(int startX, int startY)
        {
            return startX >= 0 && startX < m && startY >= 0 && startY < n;
        }
        #endregion


        #region "number of islands"

        public static class NoofIslands
        {
            static int[][] move = new int[][]{
        new int[]{-1, 0},
        new int[]{0, 1},
        new int[]{1, 0},
        new int[]{0, -1}
         };
            static int m, n;
            static bool[][] visted;

            public static int NumIslands(char[][] grid)
            {

                int result = 0;
                m = grid.Length;
                n = grid[0].Length;

                visted = new bool[m][];
                for (int i = 0; i < m; i++)
                {
                    visted[i] = new bool[n];
                }


                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (!visted[i][j] && grid[i][j] == '1')
                        {
                            findIslands(grid, i, j);
                            result++;
                        }
                    }
                }
                return result;
            }

            // floodFill算法
            public static  void findIslands(char[][] grid, int startX, int startY)
            {

                if (grid[startX][startY] == '1' && !visted[startX][startY] && isArea(startX, startY))
                {
                    visted[startX][startY] = true;
                    for (int i = 0; i < move.Length; i++)
                    {
                        int newX = startX + move[i][0];
                        int newY = startY + move[i][1];

                        findIslands(grid, newX, newY);
                    }
                    // visted[startX][startY] = false;
                }

            }

            private static bool isArea(int startX, int startY)
            {
                return startX > 0 && startX <= m && startY > 0 && startY <= n;
            }
        }

        #endregion


        #region "N queens"
        public static class Nqueens {
            // 列数组，正对角线(右上到左下)，斜对角线
            static List<bool> col, diagonal1, diagonal2;
            static IList<IList<string>> result = new List<IList<string>>();
            public static IList<IList<string>> SolveNQueens(int n)
            {
                col = new List<bool>();
                diagonal1 = new List<bool>();
                diagonal2 = new List<bool>();

                for (int i = 0; i < n; i++)
                {
                    col.Add(false);
                }

                // 2 *n-1为对角线的个数
                for (int i = 0; i < 2 * n - 1; i++)
                {
                    diagonal1.Add(false);
                    diagonal2.Add(false);
                }
                List<int> row = new List<int>();
                putQueen(n, 0, row);
                return result;

            }
            //  从第一行开始， 依次对每一行发现queen的位置
            // index 为棋盘的行虚数， row 为每一行queen的列虚数
            private static void putQueen(int n, int index, List<int> row)
            {

                //  到达最后一行， 发现一个solution
                if (n == index)
                {
                    result.Add(generateRow(n, row));
                    return;
                }

                // 循环列数
                for (int i = 0; i < n; i++)
                {
                    if (!col[i] && !diagonal1[index + i] && !diagonal2[index - i + n - 1])
                    {
                        row.Add(i);
                        col[i] = true;
                        diagonal1[index + i] = true;
                        diagonal2[index - i + n - 1] = true;
                        //进行下一行
                        putQueen(n, index + 1, row);
                        // 回溯， 复位状态
                        col[i] = false;
                        diagonal1[index + i] = false;
                        diagonal2[index - i + n - 1] = false;
                        row.RemoveAt(row.Count - 1);
                    }

                }
            }

            private static List<string> generateRow(int n, List<int> row)
            {
                List<string> result = new List<string>();
                if (row.Count != n)
                {
                    return result;
                }

                string str = "";
                for (int i = 0; i < n; i++)
                {
                    str += ".";
                }
                for (int i = 0; i < n; i++)
                {
                    result.Add(str);
                }
                // 遍历行数
                for (int i = 0; i < n; i++)
                {

                    // 把i位置的字符替换成Q
                    result[i].Remove(row[i], 1).Insert(row[i], "Q");
                }
                return result;
            }

        }
        #endregion


        #region "37 Sudoku Solver"
        public static class SudokuSolver {
            static bool[][] rows;
            static bool[][] cols;
            static bool[][] boxs;
            public static void SolveSudoku(char[][] board)
            {
                rows = new bool[9][];
                cols = new bool[9][];
                boxs = new bool[9][];

                for (int i = 0; i < board.Length; i++)
                {
                    rows[i] = new bool[10];
                    cols[i] = new bool[10];
                    boxs[i] = new bool[10];
                }

                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (board[i][j] != '.')
                        {
                            int cur = (int)(board[i][j] - '0');
                            rows[i][cur] = true;
                            cols[j][cur] = true;
                            boxs[j / 3 + (i / 3) * 3][cur] = true;
                        }

                    }
                }

                PutSudoku(board, 0, 0);
            }

            public static bool PutSudoku(char[][] board, int startX, int startY)
            {
                // 遍历结束
                if (startY == 9)
                {
                    return true;
                }

                // 下一个节点需要fill
                int newX = (startX + 1) % 9;
                int newY = (newX == 0) ? startY + 1 : startY;

                if (board[startY][startX] != '.')
                {
                    return PutSudoku(board, newX, newY);
                }
                //遍历所有的可能 1- 9
                for (int i = 1; i <= 9; i++)
                {
                    if (!rows[startY][i] && !cols[startX][i] && !boxs[startX / 3 + (startY / 3) * 3][i])
                    {
                        board[startY][startX] = Convert.ToChar(i.ToString());
                        rows[startY][i] = true;
                        cols[startX][i] = true;
                        boxs[startX / 3 + (startY / 3) * 3][i] = true;
                        if (PutSudoku(board, newX, newY))
                        {
                            return true;
                        }
                        board[startY][startX] = '.';
                        rows[startY][i] = false;
                        cols[startX][i] = false;
                        boxs[startX / 3 + (startY / 3) * 3][i] = false;
                    }
                }

                return false;

            }

        }
        #endregion


        #region "Unique paths"
        public static class UniquePaths {
            public static int UniquePaths1(int m, int n)
            {

                // m 为列数
                // n 为行数
                int[][] result = new int[m][];
                for (int i = 0; i < m; i++)
                {
                    result[i] = new int[n];
                }

                // 初始化 initilization
                result[0][0] = 1;

                // 转移方程
                // f(m-1, n-1) = f(m-2, n-1) + f(m-1, n-2);      
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i != 0 || j != 0)
                        {
                            int right = 0;
                            int down = 0;
                            if (j - 1 >= 0)
                            {
                                down = result[i][j - 1];
                            }
                            if (i - 1 >= 0)
                            {
                                right = result[i - 1][j];
                            }
                            result[i][j] = right + down;
                        }
                    }
                }
                return result[m - 1][n - 1];

            }
        }
        #endregion
    }
}
