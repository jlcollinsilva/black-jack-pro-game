/*****************************************************************************

Project: Black Jack Game - Unit 13 - CoderCamps
Lenguage: C#
Platform: .NET
Type: Console
Author: Jose L Collins
Date Created: 06/12/2016
Libraries used:  BlackJackLib , PlayerLibrary and CardLibrary
Scope: Implementation of a classic Black Jack card game with a simple user interface thru the Console or command prompt. There are two players: the Computer and the User, each player receive 2 cards and the user has the opportunity of request more cards in order to beat the computer. The winner is the player that reach the 21 limit, also if either players did not reach the limit 21 then the player with more points win the game. If a user excedde 21 points then lose his hand.  Here are the rules for Blackjack:

 - The goal of the game is to have a hand that has a value greater than the dealer but not greater than 21.
 - The number cards have their face values. The Queen, King, Jack have the value 10. Finally, the Ace is worth either 1 or 11 (player's choice).
 - If a player's cards add up to over 21 then the player loses (busts).
 - Each round, a player can either hit (take a new card) or stand (not take a card).

Approach: 
 
For this project were created one main program (project) and 3 libraries with the definition or 3 major class: Card, Player and BlackJack (the game himself). In this version was used a 52 cards set, this set was implemented with an object (DeckSet) and each player has a Hand implemented with a Dictionary of Objects (Cards), the values of the Cards and his standard names also were implemented with a Dictionary. The identification of deck (type) of card was implemented with a List.
 */

using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlackJackLib;
using PlayerLibrary;

namespace BlackJackPro
{    
    public class Program
    {
        public static void Main(string[] args)
        {           
            string continuePlay;
                do
                {
                    
                    Console.WriteLine("Start/Continue Black Jack Game? (Y/N)");
                    continuePlay = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("New Game:.....\r\n");

                if (continuePlay.ToUpper() != "Y" && continuePlay.ToUpper() != "N")
                        {
                            Console.WriteLine("!Wrong option, please type Y (yes) or N (no)...try again!");
                            continuePlay = "Y";
                        }

                    else if (continuePlay.ToUpper() == "Y") {

                        var ComputerPlayer = new CardPlayer() { Name = "Computer" };
                        var UserPlayer = new CardPlayer() { Name = "User" };
                        var currentGame = new BlackJackGame();
                        var winnerIs = "NoWinner";

                        currentGame.InitPlayer(ComputerPlayer);
                        //For the production version do not to show the Computer cards.
                        //Console.WriteLine("Cards For: " + ComputerPlayer.Name + ComputerPlayer.showCards());
                        currentGame.InitPlayer(UserPlayer);
                        Console.WriteLine("\r\nCards For: " + UserPlayer.Name + "\r\n" +
                                           UserPlayer.showCards());
                        winnerIs = currentGame.CheckWinner(ComputerPlayer, UserPlayer);

                        var resp = "H";

                        while (resp.ToUpper() == "H" && winnerIs == "NoWinner")
                        {
                            Console.WriteLine("\r\nHit or Stand? ");
                            resp = Console.ReadLine();

                            if (resp.ToUpper() == "H")
                            {
                                //Provide more cards to the user Player
                                UserPlayer.RequestCard(currentGame.DeckBlackJack);
                                Console.WriteLine("\r\nCards For: " + UserPlayer.Name + "\r\n" +  
                                                    UserPlayer.showCards());
                                winnerIs = currentGame.CheckWinner(ComputerPlayer, UserPlayer);
                            }
                            else if (resp.ToUpper() == "S")
                            {
                                winnerIs = currentGame.CheckWinnerFinal(ComputerPlayer, UserPlayer);
                            }
                            else
                            {
                                Console.WriteLine("Wrong Choice, please use H (hit) or S (stand)...try again");
                                resp = "H";
                            }
                        }

                        if (winnerIs != "NoWinner")
                        {
                            Console.WriteLine("\r\n" + winnerIs);
                        }
                    }

                } while (continuePlay.ToUpper() == "Y");

            Console.Clear();
            Console.WriteLine("\r\nThanks...Bye!,...hit Enter key for to close the window");
            Console.Read();
        }            
      }    
  }