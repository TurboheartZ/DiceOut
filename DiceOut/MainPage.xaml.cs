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
        // Variale to contain dice number
        public int dieNum;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            // Generate a random number between 1 and 6 per button click
            // Use system time as random seed
            Random rnd = new Random(System.DateTime.Now.Second);
            dieNum = rnd.Next(1, 7);
            DieValueText.Text = "The number is " + dieNum.ToString();
        }
    }
}
