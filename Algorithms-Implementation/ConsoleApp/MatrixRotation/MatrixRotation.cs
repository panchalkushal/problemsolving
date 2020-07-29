using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixRotation
{
    public static class MatrixRotation
    {
        public static List<List<int>> matrix = new List<List<int>>();
        public static int r = 0;
        public static void matrixRotation(List<List<int>> matrix, int rotation)
        {
            int row = matrix.Count;
            int col = matrix[0].Count;
            int m = row;
            int n = col;
            int te = (row * col); 
            Console.WriteLine($"r x c: {row} {col}");

            int numRect = row > col ? col / 2 : row / 2;
            int[] arrT = new int[te];
            int arStart = 0;

            te = (row * 2) + (col * 2) - 4; 

            for (int i = 1; i <= numRect; i++)
            {
                if (i > 1)
                {
                    te = ((row - 1) * 2) + ((col - 1) * 2) - 4;
                }

                int startCol = i;
                int startRow = i;

                int traversingpointer = 1;

                for (int y = startRow; y <= row; y++)
                {
                    int np = getnp(traversingpointer, rotation, te);
                    arrT[arStart + np - 1] = matrix.ElementAt(y - 1).ElementAt(startCol - 1);
                    traversingpointer++;                
                }                
                for (int x = startCol + 1; x <= col; x++)
                {
                    arrT[arStart + getnp(traversingpointer, rotation, te) - 1] = matrix.ElementAt(row - 1).ElementAt(x - 1);
                    traversingpointer++;
                }
                for (int y = row - 1; y >= startRow; y--)
                {
                    int np = getnp(traversingpointer, rotation, te);
                    arrT[arStart + np - 1] = matrix.ElementAt(y - 1).ElementAt(col - 1);
                    traversingpointer++;
                }
                for (int x = col - 1; x > startCol; x--)
                {
                    arrT[arStart + getnp(traversingpointer, rotation, te) - 1] = matrix.ElementAt(startRow - 1).ElementAt(x - 1);
                    traversingpointer++;
                }
                row = row - 1;
                col = col - 1;
                arStart = te;
            }

            CreateMatrix(arrT, m, n, numRect);            
        }

        public static int getnp(int c, int r, int tn)
        {            
            if (r > tn) r %= tn;
            if (r == 0) return c;
            else
            {
                c += r;
                if (c > tn) c -= tn;
            }
            return c;
        }

        public static void CreateMatrix(int[] ar, int r, int c, int nr)
        {
            int[][] arrTranspose = new int[r][];

            int traversingPointer = 1;
            int j = 1;

            while (j <= nr)
            {
                int sCol = j;
                int sRow = j;

                for (int i = sRow; i <= r; i++)
                {
                    if (j == 1)
                    {
                        arrTranspose[i - 1] = new int[c];
                    }
                    arrTranspose[i - 1][sCol - 1] = ar[traversingPointer - 1];
                    traversingPointer++;
                }
                for (int i = sCol + 1; i <= c; i++)
                {
                    arrTranspose[r - 1][i - 1] = ar[traversingPointer - 1];
                    traversingPointer++;
                }
                for (int i = r - 1; i >= sRow; i--)
                {
                    arrTranspose[i - 1][c - 1] = ar[traversingPointer - 1];
                    traversingPointer++;
                }
                for (int i = c - 1; i > sCol; i--)
                {
                    arrTranspose[sRow - 1][i - 1] = ar[traversingPointer - 1];
                    traversingPointer++;
                }

                r = r - 1;
                c = c - 1;
                j++;
            }

            PrintMatrix(arrTranspose);            
        }

        public static void initMatrix() 
        {
            string[] mnr = Console.ReadLine().TrimEnd().Split(' ');

            int m = Convert.ToInt32(mnr[0]);
            int n = Convert.ToInt32(mnr[1]);
            r = Convert.ToInt32(mnr[2]);            

            for (int i = 0; i < m; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }            
        }

        public static void PrintMatrix(int[][] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = 0; j < ar[i].Length; j++)
                {
                    PrintWithSpace(ar[i][j]);
                }
                Console.WriteLine();
            }
        }

        public static void PrintWithSpace(int i)
        {
            Console.Write($"{i} ");
        }
    }
}
