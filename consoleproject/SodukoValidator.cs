using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleproject
{
    /// <summary>
    /// Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:
    /// -Each row must contain the digits 1-9 without repetition.
    /// -Each column must contain the digits 1-9 without repetition.
    /// -Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
    /// Problem: https://leetcode.com/problems/valid-sudoku   
    /// </summary>
    class SodukoValidator
    {
        List<char[,]> dataSet;
        public SodukoValidator()
        {
            dataSet = new List<char[,]>();
            dataSet.Add(new char[,]{
                { '5', '3', '.', '.', '7', '.', '.', '.', '.'},
                {'6', '.', '.', '1', '9', '5', '.', '.', '.' },
                {'.', '9', '8', '.', '.', '.', '.', '6', '.' },
                {'8', '.', '.', '.', '6', '.', '.', '.', '3' },
                {'4', '.', '.', '8', '.', '3', '.', '.', '1' },
                {'7', '.', '.', '.', '2', '.', '.', '.', '6' },
                {'.', '6', '.', '.', '.', '.', '2', '8', '.' },
                {'.', '.', '.', '4', '1', '9', '.', '.', '5' },
                {'.', '.', '.', '.', '8', '.', '.', '7', '9' }
            });
            dataSet.Add(new char[,]
            {
                { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                {'6', '.', '.', '1', '9', '5', '.', '.', '.' },
                {'.', '9', '8', '.', '.', '.', '.', '6', '.' },
                {'8', '.', '.', '.', '6', '.', '.', '.', '3' },
                {'4', '.', '.', '8', '.', '3', '.', '.', '1' },
                {'7', '.', '.', '.', '2', '.', '.', '.', '6' },
                {'.', '6', '.', '.', '.', '.', '2', '8', '.' },
                {'.', '.', '.', '4', '1', '9', '.', '.', '5' },
                {'.', '.', '.', '.', '8', '.', '.', '7', '9' }
            });
        }

        public void Execute()
        {
            dataSet.ForEach(data =>
            {
                Console.WriteLine("The given matrix is valid soduko? " + IsValidSudoku(data));
            });
        }

        public bool IsValidSudoku(char[,] board)
        {
            HashSet<char> row = new HashSet<char>();
            HashSet<char> col = new HashSet<char>();
            HashSet<char> box = new HashSet<char>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // Validate Rows
                    if (board[i,j] != '.')
                    {
                        if (row.Contains(board[i,j]))
                        {
                            return false;
                        }
                        else
                        {
                            row.Add(board[i,j]);
                        }
                    }


                    // Validate Columns
                    if (board[j,i] != '.')
                    {
                        if (col.Contains(board[j,i]))
                        {
                            return false;
                        }
                        else
                        {
                            col.Add(board[j,i]);
                        }
                    }

                    // Validate box
                    int boxi = (i/3 * 3) + j / 3;
                    int boxj = (i%3 * 3) + j % 3;
                    if (board[boxi,boxj] != '.')
                    {
                        if (box.Contains(board[boxi,boxj]))
                        {
                            return false;
                        }
                        else
                        {
                            box.Add(board[boxi,boxj]);
                        }
                    }
                }
                row.Clear();
                col.Clear();
                box.Clear();
            }
            return true;
        }
    }
}
