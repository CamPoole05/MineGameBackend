using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Grid
{
    public string message;
    public string[,] gridValues = new string[0, 0];
    public int playerX = 0;
    public int playerY = 0;
    public int minesHit = 0;
    public int Height { get; private set; }
    public int Width { get; private set; }
    public Grid(int width, int height)
    {
        Height = height;
        Width = width;
        gridValues = new string[Height, Width];
        RefreshGrid();

        Random random = new Random();
        int mines = random.Next(1, (int)Math.Round(Height * Width * 0.5));
        AddMines(mines);

        playerY = Height - 1;
        gridValues[playerY, 0] = "P";
        playerX = 0;
    }


    public void RefreshGrid()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int y = 0; y < Width; y++)
            {
                gridValues[i, y] = "-";
            }
        }
    }

    

    public void AddMines(int numberOfMines)
    {
        Random random = new Random();

        for (int i = 0; i < numberOfMines; i++)
        {
            int randomRow = random.Next(Height);
            int randomColumn = random.Next(Width);

            while (gridValues[randomRow, randomColumn] == "M" || gridValues[randomRow, randomColumn] == "P")
            {
                randomRow = random.Next(Height);
                randomColumn = random.Next(Width);
            }

            gridValues[randomRow, randomColumn] = "M";
        }
    }

    public string[,] GetGrid()
    {
        return gridValues;
    }

    public bool MovePlayer(int x, int y)
    {
        if (x < 0 || y < 0 || x >= Width || y >= Height)
        {
            return false;
        }

        if (gridValues[y, x] == "M")
        {
            minesHit++;
            Console.WriteLine("You hit a mine!");
            Console.WriteLine($"You have hit: {minesHit} mines so far");
        }

        gridValues[playerY, playerX] = "-"; // Clear the current position
        

        playerX = x; // Update player's X position
        playerY = y; // Update player's Y position
        gridValues[playerY, playerX] = "P"; // Set the new position
        return true;
    }


    public int GetMinesHit()
    {
        return minesHit;
    }

}