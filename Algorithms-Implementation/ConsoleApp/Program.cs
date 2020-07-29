using System;
using System.Collections.Generic;
using System.Linq;
using MatrixRotation;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            {
                MatrixRotation.MatrixRotation.initMatrix();
                MatrixRotation.MatrixRotation.matrixRotation(MatrixRotation.MatrixRotation.matrix, MatrixRotation.MatrixRotation.r);
            }
        }
    }
}
