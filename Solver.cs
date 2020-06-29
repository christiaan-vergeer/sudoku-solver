﻿using SudokuSolver.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    public class Solver
    {
        int counter = 0;

        public int[][] Solve(int[][] sudoku)
        {
            while (counter < 100)
            {
                for (int a = 0; a < 9; a++)
                {
                    for (int b = 0; b < 9; b++)
                    {
                        if (sudoku[a][b] == 0)
                        {

                            var numberlist = Enumerable.Range(1, 9).ToList();

                            numberlist = horizontalchecker(sudoku, a, b, numberlist);

                            numberlist = verticalchecker(sudoku, a, b, numberlist);

                            numberlist = boxchecker(sudoku, a, b, numberlist);

                            if (numberlist.Count == 1)
                            {
                                sudoku[a][b] = numberlist[0];
                                counter = 0;
                            }

                        }
                        else
                        {
                            counter++;
                        }
                    }
                }
            }
            return sudoku;
            
        }


        public int[][] SolveGuessing(int[][] sudoku)
        {
            int[][] startsudoku = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                startsudoku[i] = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    startsudoku[i][j] = sudoku[i][j];
                }
            }

            
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    if (sudoku[a][b] == 0)
                    {

                        var numberlist = Enumerable.Range(1, 9).ToList();

                        numberlist = horizontalchecker(sudoku, a, b, numberlist);

                        numberlist = verticalchecker(sudoku, a, b, numberlist);

                        numberlist = boxchecker(sudoku, a, b, numberlist);

                        int numberlistcounter = 0;
                        while (numberlistcounter < numberlist.Count)
                        {
                            sudoku[a][b] = numberlist[numberlistcounter];
                            sudoku = Solve(sudoku);
                            if (!SudokuSolver(sudoku))
                            {
                                numberlistcounter++;
                                for (int i = 0; i < 9; i++)
                                { 
                                    for (int j = 0; j < 9; j++)
                                    {
                                       // startsudoku[i][j] = sudoku[i][j];
                                        sudoku[i][j] = startsudoku[i][j];
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }
        return sudoku;
        }

        public int[][] Create(int[][] sudoku)
        {
            return sudoku;
        }




        public List<int> boxchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            if (a >= 0 && a <= 2)
            {
                if (b >= 0 && b <= 2)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        for (int d = 0; d <= 2; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        for (int d = 3; d <= 5; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else
                {
                    for (int c = 0; c <= 2; c++)
                    {
                        for (int d = 6; d <= 8; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
            }
            else if (a >= 3 && a <= 5)
            {
                if (b >= 0 && b <= 2)
                {
                    for (int c = 3; c <= 5; c++)
                    {
                        for (int d = 0; d <= 2; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    for (int c = 3; c <= 5; c++)
                    {
                        for (int d = 3; d <= 5; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else
                {
                    for (int c = 3; c <= 5; c++)
                    {
                        for (int d = 6; d <= 8; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }

            }
            else
            {
                if (b >= 0 && b <= 2)
                {
                    for (int c = 6; c <= 8; c++)
                    {
                        for (int d = 0; d <= 2; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else if (b >= 3 && b <= 5)
                {
                    for (int c = 6; c <= 8; c++)
                    {
                        for (int d = 3; d <= 5; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
                else
                {
                    for (int c = 6; c <= 8; c++)
                    {
                        for (int d = 6; d <= 8; d++)
                        {
                            if (numberlist.Contains(sudoku[c][d]))
                            {
                                numberlist.Remove(sudoku[c][d]);
                            }
                        }
                    }
                }
            }
            return numberlist;
        }

        public List<int> horizontalchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            for (int c = 0; c < 9; c++)
            {
                if (numberlist.Contains(sudoku[a][c]))
                {
                    numberlist.Remove(sudoku[a][c]);
                }
            }
            return numberlist;
        }

        public List<int> verticalchecker(int[][] sudoku, int a, int b, List<int> numberlist)
        {
            for (int d = 0; d < 9; d++)
            {
                if (numberlist.Contains(sudoku[d][b]))
                {
                    numberlist.Remove(sudoku[d][b]);
                }
            }
            return numberlist;
        }

        public bool SudokuSolver(int[][] sudoku)
        {
            for (int a = 0; a < 9; a++)
            {
                for (int b = 0; b < 9; b++)
                {
                    if(sudoku[a][b] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

    }
}





//Boolean solved = false;
//int numberlistID = 0;

//                            while (solved == false && counter<100)
//                            {
//                                if (numberlist.Count <= 9 && numberlist.Count<=numberlistID)
//                                {
//                                    sudoku[a][b] = numberlist[numberlistID];
//                                    sudoku = Solve(sudoku);
//                                    for (int i = 0; i< 9; i++)
//                                    {
//                                        for (int j = 0; j< 9; j++)
//                                        {
//                                            if (sudoku[i][j] == 0)
//                                            {
//                                                sudoku = startsudoku;
//                                                numberlistID++;
                                                
//                                            }
//                                            else
//                                            {
//                                                solved = true;
//                                            }
//                                        }
//                                    }
//                                }
//                                else
//                                {
//                                    counter++;
//                                }
//                            }