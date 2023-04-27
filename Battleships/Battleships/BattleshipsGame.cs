using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships
{
    internal partial class BattleshipsGame
    {
        private readonly int boardSize;
        private readonly int[] ships;
        private readonly List<Ship> shipInstances;
        private readonly Random random;
        
        public char[,] Board { get; }

        internal BattleshipsGame(int boardSize, int[] ships)
        {
            this.boardSize = boardSize;
            this.ships = ships;
            Board = new char[boardSize, boardSize];
            shipInstances = new List<Ship>();
            random = new Random();
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (var row = 0; row < boardSize; row++)
            {
                for (var col = 0; col < boardSize; col++)
                {
                    Board[row, col] = '-';
                }
            }
            
            PlaceShips();
        }

        private void PlaceShips()
        {
            foreach (var ship in ships)
            {
                var shipInstance = new Ship(ship);
                var placed = false;
                
                while (!placed)
                {
                    var row = random.Next(boardSize);
                    var column = random.Next(boardSize);
                    var horizontal = random.Next(2) == 0;

                    if (!CanPlaceShip(shipInstance, row, column, horizontal))
                    {
                        continue;
                    }
                    
                    PlaceShip(shipInstance, row, column, horizontal);
                    placed = true;
                }

                shipInstances.Add(shipInstance);
            }
        }

        private bool CanPlaceShip(Ship ship, int row, int col, bool horizontal)
        {
            var end = horizontal ? col + ship.Size : row + ship.Size;

            if (end > boardSize)
            {
                return false;
            }

            for (var i = 0; i < ship.Size; i++)
            {
                var rowNum = horizontal ? row : row + i;
                var colNum = horizontal ? col + i : col;

                if (Board[rowNum, colNum] != '-')
                {
                    return false;
                }
            }

            return true;
        }

        private void PlaceShip(Ship ship, int row, int col, bool horizontal)
        {
            for (var i = 0; i < ship.Size; i++)
            {
                var pos = horizontal ? new[] { row, col + i } : new[] { row + i, col };
                ship.Positions.Add(pos);
                Board[pos[0], pos[1]] = 'S';
            }
        }

        public bool IsGameOver()
        {
            return shipInstances.All(ship => ship.Sunk);
        }

        public bool IsHit(int row, int col)
        {
            foreach (var ship in shipInstances)
            {
                var positions = ship.Positions.Where(pos => pos[0] == row && pos[1] == col);
                
                foreach (var pos in positions)
                {
                    ship.Positions.Remove(pos);
                    
                    if (ship.Positions.Count == 0)
                    {
                        ship.Sunk = true;
                    }

                    Board[row, col] = 'X';
                    
                    return true;
                }
            }

            Board[row, col] = 'O';
            
            return false;
        }
    }
}