# MatrixOps

This project includes various operations and utility functions for working with matrices in C#.

## Features

- **Matrix Creation**: Create different types of matrices such as zero matrices, matrices filled with ones, diagonal matrices, and more.
- **Matrix Operations**: Perform operations like transposing matrices, reshaping matrices, and scalar multiplication.
- **Matrix Properties**: Check for properties such as if a matrix is square, symmetric, diagonal, or a unit matrix.
- **Matrix Calculations**: Calculate the trace and determinant of matrices.
- **Matrix Comparison**: Compare two matrices for equality.
- **Special Matrices**: Generate upper and lower triangular matrices, as well as symmetric matrices.

## Usage

To use the matrix utilities, instantiate the `Matrix` class and call the static methods provided. Here’s an example:

```csharp
using System;
using MatrixOpsTraining;

class Program
{
    static void Main(string[] args)
    {
        // Create a 3x3 random matrix
        int[,] matrix = Matrix.CreateMatrix();

        // Print the matrix
        Matrix.PrintMatrix(matrix);

        // Get the transpose of the matrix
        int[,] transpose = Matrix.TransposeOfMatrix(matrix);

        // Print the transposed matrix
        Matrix.PrintMatrix(transpose);
    }
}
