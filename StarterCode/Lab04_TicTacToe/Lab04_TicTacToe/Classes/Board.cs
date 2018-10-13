using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
    public class Board
    {
		/// <summary>
		/// Tic Tac Toe Gameboard states
		/// </summary>
        /// 
		public string[,] GameBoard = new string[,]
		{
			{"1", "2", "3"},
			{"4", "5", "6"},
			{"7", "8", "9"},
		};

        /// <summary>
        /// Displays the board to the console
        /// </summary>
		public void DisplayBoard()
		{
			
			//DONE: Output the board to the console
		    for(int i = 0; i < GameBoard.GetLength(0); i++)
            {
                string row = "";
                for (int j = 0; j < GameBoard.GetLength(1); j++)
                {
                    row += ($"|{GameBoard[i,j]}|");
                }
                Console.WriteLine(row);
            }
		}
	}
}
