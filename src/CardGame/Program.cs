using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardCame
{
    class Program
    {
        static void checkForBustOrBlackJack(Player player, Dealer dealer, Boolean gameWon)
        {
            string? winner = "";
            if (player.IsBusted || dealer.HasNaturalBlackjack)
            {
                winner = "Dealer";
            }
            if (dealer.IsBusted || player.HasNaturalBlackjack)
            {
                winner = "Player";

            }
            if (winner != "")
            {
                Console.WriteLine(winner + " wins");
                gameWon = true;
            }
        }
        static void checkHighestScore(Player player, Dealer dealer, Boolean gameWon)
        {
            string winner = "Drawer";

            if (player.Score > dealer.Score)
            {
                winner = "Player";

            }
            if (dealer.Score > player.Score)
            {
                winner = "Dealer";

            }
            Console.WriteLine(winner + " wins");
            gameWon = true;

        }
        static void dealerDeal(Dealer dealer, Player player, CardDeck deck)
        {
            dealer.DealToPlayer(player, deck);
            dealer.DealToSelf(deck);
            Console.WriteLine("\r\n\r\n");
            Console.WriteLine("Dealer Score is " + dealer.ScoreDisplay);
            Console.WriteLine("\r\n\r\n");
            Console.WriteLine("Player Score is " + player.ScoreDisplay);


        }
        static Boolean validateUserInput(string? userInput)
        {
            userInput = Console.ReadLine()?.ToUpper();
            if (userInput != "Y" && userInput != "N")
            {
                return false;


            }
            return true;
        }
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            bool gameWon = false;
            Player player = new Player();


            // Game begins 
            Console.WriteLine("Welcome to Blackjack!" + "\r\n\r\n\r\n");

            // Set player's name.

            player.SetPlayerName();

            // Create and shuffle deck.
            CardDeck deck = new CardDeck();
            deck.BuildCardDeck();

            // Deal first round of cards.

            dealerDeal(dealer, player, deck);


            // If player hasnt bust.
            string? userInput = "";

            while (!gameWon)
            {
                Console.Write("Would you like another card (y/n)? ");
                    userInput = Console.ReadLine()?.ToUpper();

                Boolean valid = validateUserInput(userInput);
                if (!valid)
                {
                    Console.WriteLine("Incorect input...");
                    Console.Write("\r\n" + "Would you like another card(y/n)?: ");
                                        userInput = Console.ReadLine()?.ToUpper();

                }


                if (userInput?.ToUpper() == "N")
                {
                    checkForBustOrBlackJack(player, dealer, gameWon);
                    checkHighestScore(player, dealer, gameWon);

                }

                if (userInput?.ToUpper() == "Y")
                {
                    dealerDeal(dealer, player, deck);



                }
                                    checkForBustOrBlackJack(player, dealer, gameWon);


            }





        }
    }
}


