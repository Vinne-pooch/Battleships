using System.Collections.Generic;

namespace Battleships
{
    internal partial class BattleshipsGame
    {
        public class Ship
        {
            public readonly int Size;
            public readonly List<int[]> Positions;
            public bool Sunk;

            public Ship(int size)
            {
                this.Size = size;
                this.Positions = new List<int[]>();
                this.Sunk = false;
            }
        }
    }
}