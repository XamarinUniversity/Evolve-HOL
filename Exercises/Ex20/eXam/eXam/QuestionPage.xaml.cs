using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace eXam
{
    public partial class QuestionPage : ContentPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }

        public QuestionPage (QuestionPageViewModel qpvm)
        {
            InitializeComponent();

            this.BindingContext = qpvm;
        }
    }
}
