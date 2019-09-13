using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Card_Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int[] Cards = new int[3];    // Array to hold the three cards index values
        public int PlayerScore = 0;   // initialize score to 0
        public int OpponentScore = 0;   // initialize score to 0
        public Random RandomGenerator = new Random();   // Random generator for the cards

        public MainPage()
        {
            this.InitializeComponent();
            SetupGame();    // Run the SetupGame() Method to start the program
        }


        /****************************************************************************************
         * Method: SetupGame()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: This method  enables/disables starting buttons, sets up the backs of the
         * cards, and tells the user to press the start button.
         * Input(s)/Output(s): No inputs, outputs a card picture and a message to the screen.
         * *************************************************************************************/
        private void SetupGame()
        {
            // Ensure only the start game button is waiting to be pressed
            StartGameButton.IsEnabled = true;
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            ShuffleButton.IsEnabled = false;

            // Start the game seeing the backs of the cards
            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);
            ChosenCard.DisplayCard(14);
            OpponentCard.DisplayCard(14);

            // Notify User to press Start Game Button
            WinText.Text = "Click The Start Game Button!";
            PlayerScoreText.Text = $"Player Score: {PlayerScore}";
            OpponentScoreText.Text = $"Opponent Score: {OpponentScore}";
        }


        /****************************************************************************************
         * Method: Start_Click()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: Display the back of cards, enable buttons, for loop to pick new cards, 
         * while loop to ensure no two cards picked were the same, output cards to the screen.
         * Input(s)/Output(s): No inputs, removes text message, enables buttons, outputs new 
         * cards to the screen.
         * *************************************************************************************/
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            // Set the text of the start Game Button back to "Start Game" and clear the Card Value text Box
            StartGameButton.Content = "Start Game";
            CardValueText.Text = "Card Value = ";

            // Start the game seeing the backs of the cards
            ChosenCard.DisplayCard(14);
            OpponentCard.DisplayCard(14);

            // Advise the user to choose a card
            WinText.Text = "Choose a card"; 

            // Enable the game buttons
            PickCard1.IsEnabled = true;
            PickCard2.IsEnabled = true;
            PickCard3.IsEnabled = true;
            ShuffleButton.IsEnabled = true;

            // For loop to choose the cards
            for (int i = 0; i < Cards.Length; i++)
            {
                int CardValue = RandomGenerator.Next(1, 14);
                Cards[i] = CardValue;
            }
            // While loop to ensure no duplicate cards are chosen
            while (Cards[0] == Cards[1] || Cards[0] == Cards[2] || Cards[1] == Cards[2])
            {
                // For loop to choose the cards
                for (int i = 0; i < Cards.Length; i++)
                {
                    int CardValue = RandomGenerator.Next(1, 14);
                    Cards[i] = CardValue;
                }
            }
            // Display Cards
            Card1.DisplayCard(Cards[0]);
            Card2.DisplayCard(Cards[1]);
            Card3.DisplayCard(Cards[2]);
        }


        /****************************************************************************************
         * Method: ShuffleButton_Click()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: disable shuffle button, for loop to choose new cards, while loop to
         * ensure no two cards chosen are the same, displays cards to the screen.
         * Input(s)/Output(s): No inputs, outputs new cards to the screen.
         * *************************************************************************************/
        private void ShuffleButton_Click(object sender, RoutedEventArgs e)
        {
            // Disable the Shuffle Button so it cannot be clicked twice.
            ShuffleButton.IsEnabled = false;

            // Advise the user to choose a card
            WinText.Text = "Choose a card";

            // For loop to choose the cards
            for (int i = 0; i < Cards.Length; i++)
            {
                int CardValue = RandomGenerator.Next(1, 14);
                Cards[i] = CardValue;
            }
            // While loop to ensure no duplicate cards are chosen
            while (Cards[0] == Cards[1] || Cards[0] == Cards[2] || Cards[1] == Cards[2])
            {
                // For loop to choose the cards
                for (int i = 0; i < Cards.Length; i++)
                {
                    int CardValue = RandomGenerator.Next(1, 14);
                    Cards[i] = CardValue;
                }
            }
            // Display the cards
            Card1.DisplayCard(Cards[0]);
            Card2.DisplayCard(Cards[1]);
            Card3.DisplayCard(Cards[2]);
        }


        /****************************************************************************************
         * Method: PickCard1Button_Click()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: Disables buttons, puts chosen card in box, changes 3 cards to display
         * the back of the card, runs the ApplyGameRules() method.
         * Input(s)/Output(s): Input - button is clicked, Output: Back of cards displayed, chosen
         * card is placed in ChosenCard Box.
         * *************************************************************************************/
        private void PickCard1Button_Click(object sender, RoutedEventArgs e)
        {
            // Disable other buttons once a card has been chosen
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            ShuffleButton.IsEnabled = false;

            // Put chosen card in the Chosen Card box
            ChosenCard.DisplayCard(Cards[0]);

            // Show the back of cards in the 3 upper boxes
            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);

            // Player Index Chosen
            int PlayerIndex = Cards[0];

            // Run the rules of the game
            ApplyGameRules(PlayerIndex);
        }


        /****************************************************************************************
         * Method: PickCard2Button_Click()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: Disables buttons, puts chosen card in box, changes 3 cards to display
         * the back of the card, runs the ApplyGameRules() method.
         * Input(s)/Output(s): Input - button is clicked, Output: Back of cards displayed, chosen
         * card is placed in ChosenCard Box.
         * *************************************************************************************/
        private void PickCard2Button_Click(object sender, RoutedEventArgs e)
        {
            // Disable other buttons once a card has been chosen
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            ShuffleButton.IsEnabled = false;

            // Put chosen card in the Chosen Card box
            ChosenCard.DisplayCard(Cards[1]);

            // Show the back of cards in the 3 upper boxes
            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);

            // Player Index Chosen
            int PlayerIndex = Cards[1];

            // Run the rules of the game
            ApplyGameRules(PlayerIndex);
        }


        /****************************************************************************************
         * Method: PickCard3Button_Click()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: Disables buttons, puts chosen card in box, changes 3 cards to display
         * the back of the card, runs the ApplyGameRules() method.
         * Input(s)/Output(s): Input - button is clicked, Output: Back of cards displayed, chosen
         * card is placed in ChosenCard Box.
         * *************************************************************************************/
        private void PickCard3Button_Click(object sender, RoutedEventArgs e)
        {
            // Disable other buttons once a card has been chosen
            PickCard1.IsEnabled = false;
            PickCard2.IsEnabled = false;
            PickCard3.IsEnabled = false;
            ShuffleButton.IsEnabled = false;

            // Put chosen card in the Chosen Card box
            ChosenCard.DisplayCard(Cards[2]);

            // Show the back of cards in the 3 upper boxes
            Card1.DisplayCard(14);
            Card2.DisplayCard(14);
            Card3.DisplayCard(14);

            // Player Index Chosen
            int PlayerIndex = Cards[2];

            // Run the rules of the game
            ApplyGameRules(PlayerIndex);
        }


        /****************************************************************************************
         * Method: ApplyGameRules()
         * Programmer(s): Jayce Merinchuk, Upma Sharma
         * Date: August 09, 2018
         * Description: Initialize variables for use, grab passed variables and assign a score to
         * the card, choose a random card for the opponent, while loop to ensure the card is not
         * the same as the one the user has, assign it to the opponentcard box, if statement to 
         * check who's card has a higher index value. If the user's card is higher, they are assigned
         * a score of the index value multiplied by 100. Set message. Add it to the total score.
         * Input(s)/Output(s): Inputs - PlayerIndex from a PickCard Method based on what button 
         * is pressed. 
         * Outputs - Win or Lose message based on result of if statement.
         * *************************************************************************************/
        private void ApplyGameRules(int PlayerIndex)
        {
            // Initialize the variables for use below.
            int NewScore = 0;
            string WinMessage = "";

            // Grab the Player's card index to ensure the opponent card doesn't choose the same one
            int ChosenCardIndex = PlayerIndex;
            int CardValue = ChosenCardIndex * 100;
            CardValueText.Text = "Card Value = " + CardValue;

            // Choose a random card for the AI player
            int rand = RandomGenerator.Next(1, 14);

            // While loop to ensure the AI doesn't pick the same card the Player did
            while (ChosenCardIndex == rand)
            {
                rand = RandomGenerator.Next(1, 14);
            }

            // Assign the card to the opponent
            OpponentCard.DisplayCard(rand);
            int OpponentCardIndex = rand;

            /* If statement to check if chosen card value is higher than opponent card.
               If true, compute the score, if false, score = 0 and set message to say sorry and try again. */
            if (ChosenCardIndex > OpponentCardIndex)
            {
                NewScore = ((ChosenCardIndex + OpponentCardIndex) * 10);
                WinMessage = "You won and gained " + NewScore + " points!";
                PlayerScore = PlayerScore + NewScore;
            }
            else
            {
                // You lose, try again, no new score
                NewScore = ((ChosenCardIndex + OpponentCardIndex) * 10);
                WinMessage = "Sorry, you lose this time...";
                OpponentScore = OpponentScore + NewScore;
            }

            // Change the Start Game Button Text to "Play Again?"
            StartGameButton.Content = "Play Again?";

            // Compute score
            
            PlayerScoreText.Text = $"Player Score: {PlayerScore}";
            OpponentScoreText.Text = $"Opponent Score: {OpponentScore}";
            WinText.Text = WinMessage;
        }
    }
}
