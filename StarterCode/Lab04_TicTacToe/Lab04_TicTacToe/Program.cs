using System;
using Lab04_TicTacToe.Classes;
using static System.Console;

namespace Lab04_TicTacToe
{
	class Program
	{
		static void Main(string[] args)
		{
            PlayGame();
		}

		static void PlayGame()
		{
            // DONE: Instantiate your players
            WriteLine("Enter player one name:");
            Player playerOne = new Player()
            {
                Name = ReadLine(),
                Marker = "X",
                IsTurn = true
            };
            WriteLine("Enter player two name:");
            Player playerTwo = new Player()
            {
                Name = ReadLine(),
                Marker = "O",
                IsTurn = false
            };

            // Create the Game
            Game newGame = new Game(playerOne, playerTwo);
            // Play the Game
            newGame.Play();
            // Output the winner
        }
	}
}
