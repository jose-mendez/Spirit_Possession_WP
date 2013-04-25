using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Spirit_Possession
{
    public partial class about : PhoneApplicationPage
    {
        public about()
        {
            InitializeComponent();
        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask email = new EmailComposeTask();
            email.To = "jmendez.blogspot@gmail.com";

            email.Subject = "Evolucion Browser Feedback";

            email.Show();
        }

        private void textBlock1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask review = new MarketplaceReviewTask();

            review.Show();

        }

        private void textBlock2_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

            marketplaceSearchTask.SearchTerms = "evolucion_phone";

            marketplaceSearchTask.Show();
        }
    }
}