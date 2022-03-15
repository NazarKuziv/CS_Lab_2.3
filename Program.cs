using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Lab_2._3
{
    internal class Program
    {

        static void Create(int[,] R, int rowCount,  int colCount,   int Low,  int High)
        {
            Random x = new Random();

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    R[i, j] = Convert.ToInt32(x.Next(Low, High));
             
        }

        static void Print(int[,] R,  int rowCount,  int colCount)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(string.Format("{0} ", R[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            
        }
        static int Sum(int[,] R, int rowCount, int colCount )
        {
            int S = 0; 
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    if (R[i,j] % 7 == 0 || i % 2 != 0 || j % 2 != 0)
                        S += R[i,j];


            return S;
        }
        static int NumberIndex(int[,] R, int rowCount, int colCount)
        {
            int k = 0;
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    if (R[i, j] % 7 == 0 || i % 2 != 0 || j % 2 != 0)
                        k++;


                        return k;
        }

        static void MakeZero(int[,] R, int rowCount, int colCount)
        {
            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < colCount; j++)
                    if (R[i, j] % 7 == 0 || i % 2 != 0 || j % 2 != 0)
                        R[i,j] = 0;
        }
        static void Sort(int[,] R, int rowCount, int colCount)
        {
            for(int i0 = 0; i0 < rowCount - 1; i0++)
            {
                for (int i1 = 0; i1 < rowCount - i0 - 1; i1++)
                {
                    if ((R[i1, 0] < R[i1 + 1, 0])
                        ||
                        (R[i1, 0] == R[i1 + 1, 0] &&
                            R[i1, 1] > R[i1 + 1, 1])
                        ||
                        (R[i1, 0] == R[i1 + 1, 0] &&
                            R[i1, 1] == R[i1 + 1, 1] &&
                            R[i1, 3] < R[i1 + 1, 3]))
                            Change(R, i1, i1 + 1, colCount);
                }
                    
            }
		       
        }
        static void Change(int[,] R,  int row1,  int row2,  int colCount)
        {

                 int tmp = 0;
	            for (int j = 0; j<colCount; j++)
	            {
		            tmp = R[row1,j];
		            R[row1,j] = R[row2,j];
		            R[row2,j] = tmp;
	            }
        }
static void Main(string[] args)
        {
            //Діапазон значень елементів матриці
            int Low = 16;
            int High = 97;

            int rowCount = 8; // Кількість рядків
            int colCount = 6; // Кількість стовпців

            int[,] R = new int[rowCount,colCount];

            Create(R, rowCount, colCount, Low, High);
            Print(R, rowCount, colCount);

            int S = Sum(R, rowCount, colCount); // Сума елементів, які задовольняють вказаному критерію;
            int k = NumberIndex(R, rowCount, colCount); // Кількість елементів, які задовольняють вказаному критерію;

            Console.WriteLine($"Sum : {S}");
            Console.WriteLine($"Number : {k}");
            
            Console.WriteLine("Sort:");
            Sort(R, rowCount, colCount);
            Print(R, rowCount, colCount);
            Console.WriteLine("Make Zero:");
            MakeZero(R, rowCount, colCount);
            Print(R, rowCount, colCount);


            Console.ReadKey();
        }
    }
}
