using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;
using System.Windows.Input;
using Microsoft.Devices;
using System.Windows.Media;

namespace Spirit_Possession
{
    public partial class question : PhoneApplicationPage
    {
        public enum PhoneTheme
        {
            Light,
            Dark
        };
        private string str = StringResource.spt;
        public question()
        {
         
            InitializeComponent();   
            
            string theme = Resources["PhoneBackgroundColor"].ToString();
            bool isCurrentThemeDark = theme == "#FF000000"
                                    ? true
                                    : false;
            if (!isCurrentThemeDark)
            {
                askTxt.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
            else {
                askTxt.Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            }
        }


       // private string aux= "";
        private string userAnswerText = "";
        private bool userAnswerFlag = false;
        private bool flagAnswer = false;
        private int count = 0;
        private int countEnter = 0;

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (count < str.Length)
            {
                if (userAnswerFlag == true && e.Key != Key.Enter) //si se activo el flag de guardar la respuesta...
                {
                    userAnswerText += e.Key.ToString();
                    askTxt.Text += str[count].ToString();
                    askTxt.Select(askTxt.Text.Length, 0);
                    count++;
                }

                if (countEnter == 1)
                {
                    if (e.Key == Key.Enter) //si es la segunda vez que se preciona el enter...
                    {

                        askTxt.Text += str[count].ToString();
                        askTxt.Select(askTxt.Text.Length, 0);
                        userAnswerFlag = false;//desactivado el flag de guardar la respuesta
                        count++;
                        countEnter++;
                        flagAnswer = true;
                    }

                }

                if (count == 0)
                { //si es la promera letra que se entra...
                    if (e.Key == Key.Enter) //si la primera letra es un enter...
                    {
                        //answerText = e.Key.ToString();
                        askTxt.Text = str[0].ToString();
                        askTxt.Select(askTxt.Text.Length, 0);
                        userAnswerFlag = true;//activado el flag de guardar la respuesta
                        count++;
                        countEnter++;
                    }
                    
                }



               // count++;

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            askTxt.Text = "";
            questionTxt.Text = "";

            userAnswerText = "";
            userAnswerFlag = false;
            flagAnswer = false;
            count = 0;
            countEnter = 0;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(askTxt.Text) && !string.IsNullOrEmpty(questionTxt.Text))
            {
                NavigationService.Navigate(new Uri("/answer.xaml?userAnswer=" + userAnswerText + "&flagAnswer=" + flagAnswer, UriKind.Relative));
            }
            else {
                MessageBox.Show("Para preguntarle al espiritu rellene los campos de texto, no lo haga enfurecer!!!");
                Button_Click_2(null, null);
            }
            VibrateController vc = VibrateController.Default;
            vc.Start(TimeSpan.FromMilliseconds(1000));
        }

      

           
      
    }
}