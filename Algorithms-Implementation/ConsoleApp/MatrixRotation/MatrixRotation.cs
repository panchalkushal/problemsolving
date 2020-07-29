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

            int numRect = row > col ? col / 2 : row / 2;
            int[] arrT = new int[te];
            int ap = 0;

            for (int i = 1; i <= numRect; i++)
            {
                int reduction = (i - 1) * 2;
                te = ((m - reduction) * 2) + ((n - reduction) * 2) - 4;

                int sc = i;
                int sr = i;

                int tp = 1;

                for (int j = sr; j <= row; j++)
                {
                    arrT[ap + getnp(tp, r, te) - 1] = matrix.ElementAt(j - 1).ElementAt(sc - 1);
                    tp++;
                }
                for (int j = sc + 1; j <= col; j++)
                {
                    arrT[ap + getnp(tp, r, te) - 1] = matrix.ElementAt(row - 1).ElementAt(j - 1);
                    tp++;
                }
                for (int j = row - 1; j >= sr; j--)
                {
                    arrT[ap + getnp(tp, r, te) - 1] = matrix.ElementAt(j - 1).ElementAt(col - 1);
                    tp++;
                }
                for (int j = col - 1; j > sc; j--)
                {
                    arrT[ap + getnp(tp, r, te) - 1] = matrix.ElementAt(sr - 1).ElementAt(j - 1);
                    tp++;
                }
                row = row - 1;
                col = col - 1;
                ap += te;
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
            int[][] arT = new int[r][];

            int tp = 1;
            int j = 1;

            while (j <= nr)
            {
                int sCol = j;
                int sRow = j;

                for (int i = sRow; i <= r; i++)
                {
                    if (j == 1)
                    {
                        arT[i - 1] = new int[c];
                    }
                    arT[i - 1][sCol - 1] = ar[tp - 1];
                    tp++;
                }
                for (int i = sCol + 1; i <= c; i++)
                {
                    arT[r - 1][i - 1] = ar[tp - 1];
                    tp++;
                }
                for (int i = r - 1; i >= sRow; i--)
                {
                    arT[i - 1][c - 1] = ar[tp - 1];
                    tp++;
                }
                for (int i = c - 1; i > sCol; i--)
                {
                    arT[sRow - 1][i - 1] = ar[tp - 1];
                    tp++;
                }

                r = r - 1;
                c = c - 1;
                j++;
            }

            PrintMatrix(arT);
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
            Console.WriteLine("\n\n\n");
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
