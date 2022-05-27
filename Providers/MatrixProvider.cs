using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace MatrixRest.Data;
    public class MatrixProvider: IMatrixProvider
    {
        //private LibraryContext _context;
        //private HttpClient client = new HttpClient();
        //private string APIPATH = "https://fakerestapi.azurewebsites.net/api/v1/";

        public MatrixProvider(){
        }


        public string MatrixMultiplication(int[,] MatrixA, int[,] MatrixB){
            string MatrixResult = "[";
            if(MatrixA.GetLength(1) != MatrixB.GetLength(0))
                return null;
            
            for (int i = 0; i < MatrixA.GetLength(0); i++)
            {
                MatrixResult += MatrixResult == "[" ? "[" : ",[";
                string RowPreResult = "";
                for (int j = 0; j < MatrixB.GetLength(1); j++)
                {
                   string multresult = SubMultiply(MatrixA,MatrixB,i,j).ToString();
                   RowPreResult += RowPreResult == "" ? multresult.ToString() : ","+multresult;
                }
                MatrixResult += RowPreResult + "]";
            }
            MatrixResult += "]";
            Console.WriteLine(MatrixResult);
            return MatrixResult;
        }

        private int SubMultiply(int[,] MatrixA, int[,] MatrixB, int row, int col){
            Console.WriteLine($"row:{row}");
            Console.WriteLine($"col:{col}");
            int RowPreResult = 0;
            for (int j = 0; j < MatrixB.GetLength(0); j++)
            {
               Console.WriteLine($"value:{MatrixA[row,j]}");
               Console.WriteLine($"value:{MatrixB[j,col]}");
               RowPreResult += MatrixA[row,j] * MatrixB[j,col];
            }
            return RowPreResult;
        }

    }
    
