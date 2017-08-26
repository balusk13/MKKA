using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
System.Data.SQLite;

using Xamarin.Forms;

namespace DBReader
{
    public class DBReader : ContentPage
    {
        public DBReader()
        {
            var button = new Button
            {
                Text = "Click Me!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            int clicked = 0;
            button.Clicked += (s, e) => button.Text = "Clicked: " + clicked++;

            Content = button;
        }
    }
}
