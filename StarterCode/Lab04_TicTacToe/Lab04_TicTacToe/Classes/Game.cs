﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_TicTacToe.Classes
{
	public class Game
	{
		public Player PlayerOne { get; set; }
		public Player PlayerTwo { get; set; }
		public Player Winner { get; set; }
		public Board Board { get; set; }


		/// <summary>
		/// Require 2 players and a board to start a game. 
		/// </summary>
		/// <param name="p1">Player 1</param>
		/// <param name="p2">Player 2</param>
		public Game(Player p1, Player p2)
		{
			PlayerOne = p1;
			PlayerTwo = p2;
			Board = new Board();
		}

        /// <summary>
        /// Goes through the gameboard and determines if the whole board is populated by markers.
        /// If the board is populated without a Winner, then the game is a draw.
        /// </summary>
        /// <returns>True if full of markers, False if available coordinates are available</returns>
        public bool FullBoard()
        {
            for (int i = 0; i < Board.GameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GameBoard.GetLength(1); j++)
                {
                    if (Int32.TryParse(Board.GameBoard[i, j], out int _))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
		/// <summary>
		/// Activate the Play of the game
		/// </summary>
		/// <returns>Winner</returns>
		public Player Play()
		{

            //DONE: Complete this method and utilize the rest of the class structure to play the game.
            //While there isn't a winner determined or too many turns have been taken,
            //allow each player to see the board and take a turn.
            //A turn consists of picking a position on the board, and then putting their appropriate marker
            //in the board. Be sure to display the board after every turn to show the most up to date 
            //board so the next player can accurately choose. 
            //Once a winner is determined, display the board and return a winner 
            while (!CheckForWinner(Board) && !FullBoard())
            {
                Board.DisplayBoard();
                if (NextPlayer().TakeTurn(Board))
                {
                    SwitchPlayer();
                }
            }
            Board.DisplayBoard();
            return Winner;
		}


		/// <summary>
		/// Check if winner exists
		/// </summary>
		/// <param name="board">current state of the board</param>
		/// <returns>if winner exists</returns>
		public bool CheckForWinner(Board board)
		{
			int[][] winners = new int[][]
			{
				new[] {1,2,3},
				new[] {4,5,6},
				new[] {7,8,9},

				new[] {1,4,7},
				new[] {2,5,8},
				new[] {3,6,9},

				new[] {1,5,9},
				new[] {3,5,7}
			};

			// Given all the winning conditions, Determine the winning logic. 
			for (int i = 0; i < winners.Length; i++)
			{
				Position p1 = Player.PositionForNumber(winners[i][0]);
				Position p2 = Player.PositionForNumber(winners[i][1]);
				Position p3 = Player.PositionForNumber(winners[i][2]);

				string a = Board.GameBoard[p1.Row, p1.Column];
				string b = Board.GameBoard[p2.Row, p2.Column];
				string c = Board.GameBoard[p3.Row, p3.Column];

                // Done:  Determine a winner has been reached. 
                if (a.Equals(b) && b.Equals(c))
                {
                    // return true if a winner has been reached.
                    Winner = PlayerOne.IsTurn ? PlayerTwo : PlayerOne;
                    return true;
                }
            }

			return false;
		}


		/// <summary>
		/// Determine next player
		/// </summary>
		/// <returns>next player</returns>
		public Player NextPlayer()
		{
			return (PlayerOne.IsTurn) ? PlayerOne : PlayerTwo;
		}

		/// <summary>
		/// End one players turn and activate the other
		/// </summary>
		public void SwitchPlayer()
		{
			if (PlayerOne.IsTurn)
			{
				PlayerOne.IsTurn = false;
				PlayerTwo.IsTurn = true;
			}
			else
			{
				PlayerOne.IsTurn = true;
				PlayerTwo.IsTurn = false;
			}
		}


	}
}
