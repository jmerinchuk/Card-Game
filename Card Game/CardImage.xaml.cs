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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Card_Game
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CardImage : Page
    {

        private const int NumCards = 14;
        public Image[] Cards = new Image[NumCards];


        public CardImage()
        {
            this.InitializeComponent();
            CardArray();
        }

        private void CardArray()
        {
            Cards[0] = cA;
            Cards[1] = c2;
            Cards[2] = c3;
            Cards[3] = c4;
            Cards[4] = c5;
            Cards[5] = c6;
            Cards[6] = c7;
            Cards[7] = c8;
            Cards[8] = c9;
            Cards[9] = c10;
            Cards[10] = cJ;
            Cards[11] = cQ;
            Cards[12] = cK;
            Cards[13] = backofcard;
        }


        public void DisplayCard(int CardID)
        {
            CardID = CardID - 1;

            for (int i = 0; i < NumCards; i++)
            {
                if (i == CardID)
                {
                    Cards[i].Visibility = Visibility.Visible;
                }
                else
                {
                    Cards[i].Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
