namespace TicTacToe
{
    public interface IGameWinnerService
    {
        char Validate(char[,] gameBoard);
    }
}