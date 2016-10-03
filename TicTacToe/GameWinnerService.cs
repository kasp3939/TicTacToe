using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe
{
    [TestClass]
    public class GameWinnerService : IGameWinnerService
    {
        //public GameWinnerService _gameWinnerService { get; private set; }
        //public char[,] _gameboard { get; private set; }
        private const char SymbolForNoWinner = ' ';

        [TestMethod]
        public void NeitherPlayerHasthreeInARow()
        {
            IGameWinnerService gameWinnerService;
            gameWinnerService = new GameWinnerService();
            const char expected = ' ';
            var gameBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };

            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void PlayerWithAllSpaceInTopRowIsWinner()
        {
            IGameWinnerService gameWinnerService;
            gameWinnerService = new GameWinnerService();
            const char expected = 'X';
            var gameBoard = new char[3, 3]
                            { {expected, expected, expected},
                            {' ', ' ', ' '},
                            {' ', ' ', ' '}
                            };
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void SetupUnitTest()
        {
            _gameWinnerService = new GameWinnerService();
            _gameboard = new char[3, 3]
           {
            {' ', ' ', ' '},{' ', ' ', ' '}, {' ', ' ', ' ' } };

        }

        public char Validate(char[,] gameBoard)
        {

            var currentWinningSymbol = CheckForThreeInARowInHorizantalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner)
                return currentWinningSymbol;

            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
                return currentWinningSymbol;

        }

        private char CheckForThreeInARowInHorizantalRow(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 0];
            var rowTwoChar = gameBoard[0, 1];
            var rowThreeChar = gameBoard[0, 2];
            if (rowOneChar == rowTwoChar &&
                rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }

            return SymbolForNoWinner;
        }

        private char CheckForThreeInARowInVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 0];
            var rowTwoChar = gameBoard[1, 0];
            var rowThreeChar = gameBoard[2, 0];
            if (rowOneChar == rowTwoChar &&
                rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }

            return SymbolForNoWinner;

        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];
            if (cellOneChar == cellTwoChar && cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }

        [TestMethod]
        public void PlayerWithAllSpaceInFistColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameboard[columnIndex, 0] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [TestMethod]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            const char expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameboard[cellIndex, cellIndex] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

    }
}






//var currentWinningSymbol = ' ';
//currentWinningSymbol = CheckForThreeInARowInHorizantalRow(gameBoard);

//var rowOneChar = gameBoard[0, 0];
//var rowTwoChar = gameBoard[1, 0];
//var rowThreeChar = gameBoard[2, 0];
//if (rowOneChar == rowTwoChar && rowTwoChar == rowThreeChar)
//{
//    currentWinningSymbol = rowOneChar;
//}

//return currentWinningSymbol

//var columnOneChar = gameBoard[0, 0];
//var columnTwoChar = gameBoard[0, 1];
//var columnThreeChar = gameBoard[0, 2];
//if (columnOneChar == columnTwoChar && 
//    columnTwoChar == columnThreeChar)
//{
//    return columnOneChar;
//}

//var rowTwoChar = gameBoard[1, 0];
//var rowThreeChar = gameBoard[2, 0];
//if (columnOneChar == rowTwoChar && 
//        rowTwoChar == rowThreeChar)
//{
//    return columnOneChar;
//}

//return ' ';

//var columnOneChar = gameBoard[0, 0];
//var columnTwoChar = gameBoard[0, 1];
//var columnThreeChar = gameBoard[0, 2];
//if (columnOneChar == columnTwoChar && 
//    columnTwoChar == columnThreeChar)
//{
//    return columnOneChar;
//}

//return ' ';