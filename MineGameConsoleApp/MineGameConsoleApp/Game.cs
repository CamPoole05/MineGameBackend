using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Game
{
    public static void StartGame()
    {
        int minesBeforeLose = 3;

        Grid gameGrid = new Grid(8, 8);

        
        string[,] gridValues = gameGrid.GetGrid();



        while (gameGrid.GetMinesHit() < minesBeforeLose && gameGrid.playerY != 0)
        {
            UI.printGrid(gridValues);
            UI.ShowOptions();
            string moveOption = Console.ReadLine();

            int newPlayerX;
            int newPlayerY;

            switch (moveOption)
            {
                case "u":
                case "U":
                    newPlayerX = gameGrid.playerX;
                    newPlayerY = gameGrid.playerY - 1;
                    gameGrid.MovePlayer(newPlayerX, newPlayerY);
                    break;
                case "d":
                case "D":
                    newPlayerX = gameGrid.playerX;
                    newPlayerY = gameGrid.playerY + 1;
                    gameGrid.MovePlayer(newPlayerX, newPlayerY);
                    break;
                case "l":
                case "L":
                    newPlayerX = gameGrid.playerX - 1;
                    newPlayerY = gameGrid.playerY;
                    gameGrid.MovePlayer(newPlayerX, newPlayerY);
                    break;
                case "r":
                case "R":
                    newPlayerX = gameGrid.playerX + 1;
                    newPlayerY = gameGrid.playerY;
                    gameGrid.MovePlayer(newPlayerX, newPlayerY);
                    break;

                default:
                    Console.WriteLine("Not valid option");
                    break;
            }
            
        }

        if (gameGrid.GetMinesHit() >= minesBeforeLose)
        {
            Console.WriteLine("You Lose!");
        }
        else
        {
            Console.WriteLine("You Win!");
        }
    }

}