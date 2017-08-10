using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gemidapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendGemidaoPage : ContentPage
    {
        ViewModels.SendGemidaoViewModel vm;
        public SendGemidaoPage()
        {
            InitializeComponent();

            this.BindingContext = vm = new ViewModels.SendGemidaoViewModel();
        }
    }
}