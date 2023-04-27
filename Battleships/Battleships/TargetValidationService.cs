namespace Battleships
{
    internal class TargetValidationService
    {
        private readonly int boardSize;

        public TargetValidationService(int boardSize)
        {
            this.boardSize = boardSize;
        }
        
        public bool ParseTarget(string input, out int row, out int col)
        {
            row = -1;
            col = -1;
            
            if (input.Length != 2 && input.Length != 3)
            {
                return false;
            }
            
            if (!char.IsLetter(input[0]))
            {
                return false;
            }
            
            if (!int.TryParse(input[1..], out row))
            {
                return false;
            }
            
            col = char.ToUpper(input[0]) - 'A';
            
            return true;
        }
        
        public bool IsValidTarget(int row, int col)
        {
            return row >= 0 && row < boardSize && col >= 0 && col < boardSize;
        }
    }
}