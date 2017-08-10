using PerpetualEngine.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gemidapp.ViewModels
{
    class TokenViewModel : BaseViewModel
    {
        SimpleStorage storage;
        public TokenViewModel()
        {
            Title = "Token";
            OpenWebBrowser = new Command(() => Device.OpenUri(new Uri("https://api2.totalvoice.com.br/painel/signup.php")));

            storage = SimpleStorage.EditGroup(nameof(Token));

            this.Token = storage.Get(nameof(Token)) ?? "";
        }

        string _token;
        public string Token
        {
            get
            { return _token; }
            set
            {
                if (_token != value) storage.Put(nameof(Token), value);
                SetProperty(ref _token, value);
            }
        }
        
        public ICommand OpenWebBrowser { get; }
    }
}
