using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MineGameAPI.Controllers
{
    [Route("api/hello")]
    [ApiController]
    public class NewGridController : ControllerBase
    {
        [HttpGet]
        public JsonResult NewGrid(int width, int height)
        {
            Grid newGrid = new Grid(width, height);
            var json = new Dictionary<string, string[]>();

            string[,] newGridValues = newGrid.GetGrid();

            for (int i = 0; i < newGridValues.GetLength(0); i++)
            {
                string key = "row" + i.ToString();

                // Convert the row to an array before adding to the dictionary
                string[] rowArray = new string[newGridValues.GetLength(1)];
                for (int j = 0; j < newGridValues.GetLength(1); j++)
                {
                    rowArray[j] = newGridValues[i, j];
                }

                json[key] = rowArray;
            }

            return new JsonResult(json);
        }
    }

    [Route("api/makemove")]
    [ApiController]
    public class MakeMoveController : ControllerBase
    {
        [HttpGet]
        public JsonResult MakeMove(string stringGrid, int rowWidth, int minesHit, string dir)
        {
            
            minesHit++;
            var json = new Dictionary<string, string[]>();
            string[] array1d = stringGrid.Split(';');
            string[,] array2d = new string[array1d.Length, array1d[0].Split(',').Length];
            Grid newGrid = new Grid(array2d.GetLength(1), array2d.GetLength(0));

            for (int i = 0; i < array1d.Length; i++)
            {
                for (int y = 0; y < array1d[0].Split(',').Length; y++)
                {
                    array2d[i, y] = array1d[i].Split(',')[y];
                }
            }

            newGrid.gridValues = array2d;

            Grid returnGrid = Game.makeMove(newGrid, dir, minesHit);

            string[,] newGridValues = returnGrid.GetGrid();

            for (int i = 0; i < newGridValues.GetLength(0); i++)
            {
                string key = "row" + i.ToString();

                // Convert the row to an array before adding to the dictionary
                string[] rowArray = new string[newGridValues.GetLength(1)];
                for (int j = 0; j < newGridValues.GetLength(1); j++)
                {
                    rowArray[j] = newGridValues[i, j];
                }

                json[key] = rowArray;
            }


            return new JsonResult(json);
        }

        
    }
}
