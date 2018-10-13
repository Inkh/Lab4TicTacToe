using System;
using Xunit;
using static Lab04_TicTacToe.Program;
using Lab04_TicTacToe.Classes;

namespace TicTacTest
{
//    Given a game board, Test for winners(at least 3)
//    Test that there is a switch in players between turns
//    Confirm that the position the player inputs correlates to the correct index of the array
//    One other “unique” test of your own
    public class UnitTest1
    {
        [Theory]
        [InlineData("jimmy", "jeff", "jimmy")]
        [InlineData("jeff", "jimmy", "jeff")]
        public void SpecificWinnerTest(string p1Name, string p2Name, string expected)
        {

        Player p1 = new Player()
            {
                Name = p1Name,
                Marker = "X",
                IsTurn = false
            };

            Player p2 = new Player()
            {
                Name = p2Name,
                Marker = "O",
                IsTurn = true
            };

            Board newBoard = new Board();
            Game newGame = new Game(p1, p2);
            newGame.Board.GameBoard = new string[,]
                {
                    {"X", "X", "X"},
                    {"4", "O", "O"},
                    {"7", "8", "9"},
                };

            newGame.CheckForWinner(newBoard);
            Assert.Equal(expected, newGame.Winner.Name);
        }
    }
}
