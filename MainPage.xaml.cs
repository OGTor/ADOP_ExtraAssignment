using ADOP_ExtraAssignment.Models;
using ADOP_ExtraAssignment.Services;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

namespace ADOP_ExtraAssignment
{
    public partial class MainPage : ContentPage
    {
        private RandomService _randomService;
        private List<Friend> _friends;

        public MainPage()
        {
            InitializeComponent();

            _randomService = new RandomService();

            
            _friends = new List<Friend>();
            for (int i = 0; i < 50; i++)
            {
                _friends.Add(Friend.Factory.CreateRandom(_randomService));
            }

       
            var stackLayout = new StackLayout();
            foreach (var friend in _friends)
            {
                var friendLabel = new Label { Text = friend.FullName, FontSize = 25, FontAttributes = FontAttributes.Bold };
                var quotesLabel = new Label { Text = "Favorite Quotes:", FontSize = 14 };
                friendslist.Children.Add(friendLabel);
                friendslist.Children.Add(quotesLabel);

                foreach (var quote in friend.FavoriteQuotes)
                {
                    var quoteLabel = new Label { Text = quote.ToString(), FontSize = 16 };
                    friendslist.Children.Add(quoteLabel);


                }
                friendslist.Children.Add(new BoxView { HeightRequest = 1, HorizontalOptions = LayoutOptions.FillAndExpand });
            }

            Content = friendslist;
            
        }
    }
}

