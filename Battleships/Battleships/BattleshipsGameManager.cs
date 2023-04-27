using System;

namespace Battleships
{
    internal class BattleshipsGameManager
    {
        private readonly int boardHeight;
        private readonly char[] boardWidth;
        private readonly BattleshipsGame game;
        private readonly TargetValidationService validator;
        
        public BattleshipsGameManager(int boardHeight, char[] boardWidth, int[] ships)
        {
            this.boardHeight = boardHeight;
            this.boardWidth = boardWidth;
            this.game = new BattleshipsGame(boardHeight, ships);
            this.validator = new TargetValidationService(boardHeight);
        }
        
        public void StartGame()
        {
            while (!game.IsGameOver()) {
                
                Console.WriteLine();
                this.PrintBoard();
                Console.Write("Enter a cell (e.g. A5): ");
                
                var targetStr = Console.ReadLine();

                int col, row;
                
                while (!validator.ParseTarget(targetStr, out row, out col) || !validator.IsValidTarget(row, col))
                {
                    Console.Write("Invalid target. Enter a target (e.g. A5): ");
                    targetStr = Console.ReadLine();
                }

                Console.WriteLine(game.IsHit(row, col) ? "Hit!" : "Miss!");
            }
            
            Console.WriteLine();
            this.PrintBoard();
        }


        private void PrintBoard()
        {
            Console.WriteLine($"  {string.Join(" ", boardWidth)}");
            for (var row = 0; row < boardHeight; row++)
            {
                Console.Write(row + " ");
                for (var col = 0; col < boardWidth.Length; col++)
                {
                    Console.Write(game.Board[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}