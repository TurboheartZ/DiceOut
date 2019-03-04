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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DiceOut
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Array variale to contain 3 dice numbers
        public int[] diceNum = new int[3];
        // The totol score variable
        public int score = 0;

        public MainPage()
        {
            this.InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            WinText.Text = "Click the \"Roll Dice\" button to play";
            ScoreText.Text = $"{score}";
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            // Generate a random number between 1 and 6 per button click
            // Use system time as random seed
            Random rnd = new Random(System.DateTime.Now.Second);

            for (int i = 0; i < diceNum.Length; i++) {
                diceNum[i] = rnd.Next(1,7);
            }

            DieValueText.Text = $"The values are {diceNum[0]}, {diceNum[1]}, {diceNum[2]}";

            Die1.DisplayFace(diceNum[0]);
            Die2.DisplayFace(diceNum[1]);
            Die3.DisplayFace(diceNum[2]);

            score += Play_Game();
            ScoreText.Text = $"{score}";

            if (ScoreText.Visibility == Visibility.Collapsed || WinText.Visibility == Visibility.Collapsed) {
                ScoreText.Visibility = Visibility.Visible;
                PreScoreText.Visibility = Visibility.Visible;
                WinText.Visibility = Visibility.Visible;
            }
        }

        private int Play_Game() {
            int credit = 0;
            string msg = "";

            if (diceNum[0] == diceNum[1] && diceNum[1] == diceNum[2])
            {
                // The case of 3 matches
                if (diceNum[0] != 6)
                {
                    credit = diceNum[0] * 100;
                }
                else {
                    credit = 1000;
                }
                //  Message to show user
                msg = $"You rolled Tripples of {diceNum[0]} and won score {credit}";
            }
            else if (diceNum[0] == diceNum[1] || diceNum[0] == diceNum[2] || diceNum[1] == diceNum[2])
            {
                // The case of 2 matches
                credit = 50;
                //  Message to show user
                msg = $"You rolled Doubles and won score {credit}";
            }
            else {
                // The case of no match, zero credit earn
                credit = 0;
                msg = $"No match this roll";
            }
            WinText.Text = msg;

            return credit;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            ScoreText.Text = $"{score}";
            WinText.Text = "Game reseted !";
        }
    }
}
