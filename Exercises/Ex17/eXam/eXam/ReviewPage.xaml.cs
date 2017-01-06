using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace eXam
{
    public partial class ReviewPage : ContentPage
    {
        public ReviewPage(ReviewPageViewModel rpvm)
        {
            InitializeComponent();

            BindingContext = rpvm;
        }
    }
}
