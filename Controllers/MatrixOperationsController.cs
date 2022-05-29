using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MatrixRest.Data;
using Microsoft.AspNetCore.Cors;

namespace MatrixRest.Controllers;
    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class MatrixOperationsController:ControllerBase
    {
        private IMatrixProvider _MatrixProvider;
        public MatrixOperationsController(IMatrixProvider matrixProvider)
        {
            _MatrixProvider = matrixProvider;
        }

        [HttpPost]
        [Route("Multiply")]
        public ActionResult<string> Multiply([FromBody] MatrixContentDTO MatrixContent){
            //int[,] MatrixA = new int[2,4]{{5,3,-4,-2},{8,-1,0,-3}};
            //int[,] MatrixB = new int[4,3]{{1,4,0},{-5,3,7},{0,-9,5},{5,1,4}};
            int[,] MatrixA = TransformStringtoMatrix(MatrixContent.StrMatrixA);
            int[,] MatrixB = TransformStringtoMatrix(MatrixContent.StrMatrixB);
            string result = _MatrixProvider.MatrixMultiplication(MatrixA,MatrixB);
            if(result == null)
                return Problem("The dimensions of the array make not posible to multiply them.");

            return Ok(result);
        }

        static int[,] TransformStringtoMatrix(string strMatrix){
            //int[,] result = new int[5,5];
            string[] dimensions = strMatrix.Split("],[",StringSplitOptions.None);
            int[,] result = new int[dimensions.Count(),dimensions[0].Split(',').Count()];
            Console.WriteLine(dimensions[0]);
            for (int i = 0; i < dimensions.Count(); i++)
            {
                string[] numbers = dimensions[i].Split(',');
                for (int j = 0; j < numbers.Count(); j++)
                {
                    Console.WriteLine(numbers[j]);
                    result[i,j] = int.Parse(numbers[j].Replace("[","").Replace("]",""));
                }
            }
            return result;
        }

    }

    public record MatrixContentDTO{
        public string StrMatrixA {get; set;}
        public string StrMatrixB {get; set;}
    }
