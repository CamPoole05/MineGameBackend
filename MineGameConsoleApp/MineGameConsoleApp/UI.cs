using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class UI
{
    public static void printGrid(string[,] gridValues)
    {
        for (int i = 0; i < gridValues.GetLength(0); i++)
        {
            Console.Write("|");
            for (int j = 0; j < gridValues.GetLength(1); j++)
            {
                Console.Write($"{(gridValues[i, j]).Replace("M","-")}|");
            }
            Console.WriteLine();
        }
    }

    public static void ShowOptions()
    {
        Console.WriteLine("Options:");
        Console.WriteLine("'U': Move Up");
        Console.WriteLine("'D': Move Down");
        Console.WriteLine("'R': Move Right");
        Console.WriteLine("'L': Move Left");
    }

}