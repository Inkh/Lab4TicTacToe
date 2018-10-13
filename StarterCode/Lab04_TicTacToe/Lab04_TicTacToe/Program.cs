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
            // TODO: Instantiate your players
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
                Marker = "0",
                IsTurn = false
            };
            // Create the Game
            // Play the Game
            // Output the winner
        }
	}
}
