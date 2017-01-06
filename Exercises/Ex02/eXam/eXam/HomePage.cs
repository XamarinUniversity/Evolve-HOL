using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace eXam
{
    public class HomePage : ContentPage
    {
        public HomePage()
        {
            var layout = new AbsoluteLayout();

            Content = layout;

            var button = new Button()
            {
                Text = "Start eXam!",
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#0892d0"),
                Font = Font.SystemFontOfSize(NamedSize.Medium),
            };

           layout.Children.Add(button, new Rectangle(0.5, 0.5, 200, 60), AbsoluteLayoutFlags.PositionProportional);
        }
    }
}
