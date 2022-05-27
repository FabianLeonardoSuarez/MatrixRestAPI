using System;

namespace MatrixRest.Data;
    public interface IMatrixProvider
    {
        public string MatrixMultiplication(int[,] MatrixA, int[,] MatrixB);
    }
    
