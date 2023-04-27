using System;
using System.Collections.Generic;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            const int boardHeight = 10;
            int[] ships = { 5, 4, 4 };
            char[] boardWidth = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        
            Console.WriteLine("Welcome to Battleships!");
            
            new BattleshipsGameManager(boardHeight, boardWidth, ships)
                .StartGame();
            
            Console.WriteLine("Game over!");
        }
    }
}