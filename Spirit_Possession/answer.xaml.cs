using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;

namespace Spirit_Possession
{
    public partial class answer : PhoneApplicationPage
    {
        private string[] noOwnerText = new string[3];
        public answer()
        {
            InitializeComponent();
            noOwnerText[0] = StringResource.String1;
            noOwnerText[1] = StringResource.String2;
            noOwnerText[2] = StringResource.String3;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string newText = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("userAnswer", out newText))
            {
                answerText.Text = newText;
            }

            string flagAnswer = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("flagAnswer", out flagAnswer))
            {
                //answerText.Text = flagAnswer;
                if (flagAnswer == "True")
                {
                    spirituImg.Source = new BitmapImage(new Uri("/Images/spiritu.png", UriKind.Relative));
                }
                else {
                    spirituImg.Source = new BitmapImage(new Uri("/Images/spirituFurious.png", UriKind.Relative));
                    Random r = new Random(DateTime.Now.Millisecond);
                    int aleat = r.Next(0, 2);
                    answerText.Text = noOwnerText[aleat];
                }

            }

            base.OnNavigatedTo(e);
        }
    }
}