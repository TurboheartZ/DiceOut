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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace DiceOut
{
    public sealed partial class DieImage : UserControl
    {
        private const int FaceNum = 6;
        public Image[] Faces = new Image[FaceNum];
        // Remember what is the last face that is visible
        // So next time only set this face to be collapsed
        private int LastFace = 0;

        public DieImage()
        {
            this.InitializeComponent();
            SetupFace();
        }

        private void SetupFace()
        {
            Faces[0] = Face1;
            Faces[1] = Face2;
            Faces[2] = Face3;
            Faces[3] = Face4;
            Faces[4] = Face5;
            Faces[5] = Face6;
        }

        public void DisplayFace(int DiceNum)
        {
            int FaceId = DiceNum - 1;
            Faces[FaceId].Visibility = Visibility.Visible;
            if (LastFace != FaceId) {
                Faces[LastFace].Visibility = Visibility.Collapsed;
            }           
            LastFace = FaceId;
        }
    }
}
