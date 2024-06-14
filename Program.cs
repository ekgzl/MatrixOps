using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

namespace EKGMatrixExercises
{
    internal class Program
    {
        //Diagonel elemanlar soldan sağ aşağı doğru köeşegendir.
        // a11 a12 a13
        // a21 a22 a23 bunlar matristir.
        // a31 a32 a33 
        // a11 a22 a33 bunlar diagonel elemanlardır.
        static void Main(string[] args)
        {

            int[,] X = CreateUpperTriangleMatrix(1, 9, 4);
            PrintMatrix(X);
            Console.WriteLine("Is lower: {0}", IsUpperTriangleMatrix(X));


        }



        public static int[,] CreateMatrix(int row = 3,
            int column = 3,int min = 1, int max = 9)
        {
            int[,] matrix = new int[row, column];
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    matrix[i, j] = new Random().Next(min, max);

            return matrix;
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i< matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static int[,] CreateZeroMatrix(int row =3,
            int column= 3)
        {
            return CreateMatrix(row, column, 0, 0);
        }

        public static int[,] CreateOnlyOneMatrix(int row = 3,
            int column = 3)
        {
            return CreateMatrix(row, column, 1, 1);
        }
        
        // Sadece x[i,i] değerlerinde değer olan matrixtir.
        // Diğer elemanlar 0 olmalıdır.
        // KARE MATRIS OLMALI [i,i]!!!
        public static int[,] CreateDiagonalMatrix(int min = 1,
            int max = 9,
            int size = 3)
        {
            int[,] X = CreateZeroMatrix(size,size);
            for (int i = 0; i < size; i++)
                X[i, i] = new Random().Next(min, max);

            return X;
        }

        // köşegendeki değerler birbirine eşit olmalı
        public static int[,] CreateScalerMatrix(int scaler= 3,int size = 3)
        {
            int[,] X = CreateDiagonalMatrix(scaler, scaler, size);
            return X;
        }

        //Kontrol kare matris mi değil mi
        public static bool IsSquareMatrix(int[,] matrix)
        {
            return matrix.GetLength(0) == matrix.GetLength(1);

        }

        public static bool IsUnitMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, i] == 1)
                    continue;
                else
                {
                    Console.WriteLine("Is unit matrix: False");
                    return false;
                }
                    
            }
            Console.WriteLine("Is unit matrix: True");
            return true;
        }


        // Birim matris diagonal elemanları
        // 1 diğerleri 0'a eşit olanlardır.

        public static int[,] CreateUnitMatrix(int size)
        {
            int[,] X = CreateScalerMatrix(1, size);
            return X;
        }

        // if it is diagonal it is squared matrix
        public static int[] TakeDiagonalElements(int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
            {
                Console.WriteLine("ERROR!");
                return null;
            }
                

            int[] array = new int[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0);i++)
                array[i] = matrix[i, i];

            return array;

        }


        // nxn boyutunda kare bir matris için
        // matrisin izi  diagonal elementlerin toplamıdır

        public static int TraceOfMatrix(int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
            {
                Console.WriteLine("ERROR!");
                return -1;
            }
            int[] array = new int[matrix.GetLength(0)];

            array = TakeDiagonalElements(matrix);
            int sum = 0;
            for(int i = 0;i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }
        // take row and replace on another matrix's column
        public static int[,] TransposeOfMatrix(int[,] matrix)
        {
            int[,] temp = new int[matrix.GetLength(1)
                , matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    temp[j, i] = matrix[i, j];

            return temp;
        }
        // yeni satır ve sütun ile aynı elementelere sahip
        // yeni bir matris oluşturma.

        public static int[,] ReshapeMatrix(int[,] matrix,
            int newRow, int newColumn)
        {
            int[] array = new int[matrix.Length];
            int count = 0;
            int[,] newMatrix = new int[newRow, newColumn];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    array[count++] = matrix[i, j];

            if (array.Length != newRow * newColumn)
                throw new ArgumentException("new dimensions is not fit.");
            count = 0;
            for (int i = 0; i < newRow; i++)
                for (int j = 0; j < newColumn; j++)
                    newMatrix[i, j] = array[count++];

            return newMatrix;
        }

        public static bool IsEqual(int[,] mX1, int[,] mX2)
        {
            if (mX1.GetLength(0) == mX2.GetLength(0) && mX1.GetLength(1)
                == mX2.GetLength(1))
            {
                 for(int i = 0; i < mX1.GetLength(0);i++)
                    for(int j = 0; j < mX1.GetLength(1);j++)
                    {
                        if (mX1[i, j] == mX2[i, j])
                            continue;
                        else
                            return false;
                    }
                return true;
            }
            else
                return false;

        }

        public static int CalculateDeterminant2x2(int[,] matrix)
        {
            int d;
            if(matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2)
            {
                d = -1 * (matrix[0, 1] * matrix[1, 0]) + matrix[0, 0] * matrix[1, 1];
                return d;
            }
            else
            {
                throw new ArgumentException("should be squared matrix");
                return -1;
            }

        }

        //scaler çarpım
        public static int[,] ScalerMultiplication(int c, int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] *= c;
            return matrix;
        }

        public static int SumOfElements(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    sum += matrix[i, j];

            return sum;
        }

        //kare matrix olmak zorunda
        // eğer aij = aji ve diagonal elementlere bakamya gerek yok
        // (i != j) ise bu simetrik matrixtir.
        public static bool IsSymmetric(int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
                throw new ArgumentException("it should be squared matrix");

            for(int i = 1; i < matrix.GetLength(0);i++)
            {
                for(int j = 0; j<= i-1;j++)
                {
                    if (matrix[i, j] == matrix[j, i])
                        continue;
                    else
                        return false;
                }
            }

            return true;

        }

        public static int[,] CreateSymmetricMatrix(int min,int max,int size)
        {

            int[,] tempMatrix = CreateDiagonalMatrix(min, max, size);

            for(int i = 1; i <tempMatrix.GetLength(0);i++)
                for(int j = 0; j <= i-1;j++)
                {
                    tempMatrix[i, j] = new Random().Next(min, max);
                    tempMatrix[j, i] = tempMatrix[i, j];
                }

            return tempMatrix;
        }

        public static bool IsDiagonalMatrix(int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
                throw new ArgumentException("it should be" +
                    "squared matrix");

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        continue;
                    if (!(matrix[i, j] == 0))
                        return false;
                }

            return true;
        }

        //sadece diagonal kısmın üstü dolu olan matrix.
        public static int[,] CreateUpperTriangleMatrix(int min,int max,int size)
        {
            int[,] temp = CreateDiagonalMatrix(min,max,size);int j = 0;
            for (int i = 0; i < temp.GetLength(0); i++)
            {
                j += 1;
                int k = j;
                while(k < temp.GetLength(0))
                {
                    temp[i, k] = new Random().Next(min, max);
                    k++;
                }
            }
            return temp;
        }

        public static int[,] CreateLowerTriangleMatrix(int min,int max,int size)
        {

            int[,] temp = CreateDiagonalMatrix(min, max, size);

            for (int i = 1; i < temp.GetLength(0); i++)
                for (int j = 0; j <= i - 1; j++)
                    temp[i, j] = new Random().Next(min, max);

            return temp;
        }

        public static bool IsUpperTriangleMatrix(int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
                throw new ArgumentException("it must be squared.");
            
            for(int i = 1; i < matrix.GetLength(0);i++)
                for(int j = 0; j < i - 1; j++)
                {
                    if (matrix[i, j] == 0)
                        continue;
                    return false;
                }
            return true;

        }

        public static bool IsLowerTriangleMatrix(int[,] matrix)
        {
            if (!IsSquareMatrix(matrix))
                throw new ArgumentException("it must be squared.");
            int k = 1;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = k; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                        continue;
                    return false;
                }
                k++;
            }
            return true;
                
        }






    }
    }

    

