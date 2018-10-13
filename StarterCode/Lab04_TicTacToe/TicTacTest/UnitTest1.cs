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
        /// <summary>
        /// Checks the method that returns if a game is over.
        /// </summary>
        [Fact]
        public void ChecksForWinnersTest()
        {
            // creates the players
            Player p1 = new Player()
            {
                Marker = "X",
            };

            Player p2 = new Player()
            {
                Marker = "O",
            };

            // creates a new game board and sets the winning gameboard
            Board newBoard = new Board();
            Game newGame = new Game(p1, p2);
            newGame.Board.GameBoard = new string[,]
                {
                    {"X", "2", "3"},
                    {"X", "O", "O"},
                    {"X", "8", "9"},
                };

            // checks for a winner
            Assert.True(newGame.CheckForWinner(newBoard) == true);
        }

        /// <summary>
        /// Tests specific winners. Winner should always be first player.
        /// </summary>
        /// <param name="p1Name">First player's name.</param>
        /// <param name="p2Name">Second player's name.</param>
        /// <param name="expected">The expected winner'a name.</param>
        [Theory]
        [InlineData("jimmy", "jeff", "jimmy")]
        [InlineData("jeff", "jimmy", "jeff")]
        public void SpecificWinnerTest(string p1Name, string p2Name, string expected)
        {
            // creates the players
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

            // creates a new game board and sets the winning gameboard
            Board newBoard = new Board();
            Game newGame = new Game(p1, p2);
            newGame.Board.GameBoard = new string[,]
                {
                    {"X", "X", "X"},
                    {"4", "O", "O"},
                    {"7", "8", "9"},
                };

            // checks for a winner
            newGame.CheckForWinner(newBoard);
            Assert.Equal(expected, newGame.Winner.Name);
        }

        /// <summary>
        /// Tests that switch players actually switches them.
        /// </summary>
        [Fact]
        static void SwitchPlayerTest()
        {
            // creates the players
            Player p1 = new Player()
            {
                Marker = "X",
            };

            Player p2 = new Player()
            {
                Marker = "O",
            };

            // creates new game with those players
            Game newGame = new Game(p1, p2);

            // current player is the next player
            Player current = newGame.NextPlayer();

            // switches them
            newGame.SwitchPlayer();

            // finds new player
            Player next = newGame.NextPlayer();

            Assert.True(current != next);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(2, 0, 1)]
        [InlineData(3, 0, 2)]
        [InlineData(4, 1, 0)]
        [InlineData(5, 1, 1)]
        [InlineData(6, 1, 2)]
        [InlineData(7, 2, 0)]
        [InlineData(8, 2, 1)]
        [InlineData(9, 2, 2)]
        static void PlayerPositionTest(int input, int row, int column)
        {
            Position pos = Player.PositionForNumber(input);
            Assert.True(row == pos.Row && column == pos.Column);
        }
    }
}
