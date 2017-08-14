using Gemidapp.Services;
using PerpetualEngine.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gemidapp.ViewModels
{
    class SendGemidaoViewModel : BaseViewModel
    {
        public ICommand EnviarGemidao { get; set; }

        private string _from;
        public string From { get => _from; set => SetProperty(ref _from, value); }

        private string _to;
        public string To { get => _to; set => SetProperty(ref _to, value); }

        SimpleStorage storage;
        public SendGemidaoViewModel()
        {
            this.Title = "Enviar Gemidão";

            storage = SimpleStorage.EditGroup(nameof(TokenViewModel.Token));
            EnviarGemidao = new Command(async () =>
            {
                if (IsBusy) return;

                IsBusy = true;
                string token = await storage.GetAsync(nameof(TokenViewModel.Token));
                var result = await new TotalVoiceService().Call(From, To, token);
                IsBusy = false;
                if (result.IsSuccessStatusCode)
                    await App.Current.MainPage.DisplayAlert("Gemidasso!", "dentro de instantes o gemidão será efetuado", "ok");
                else await App.Current.MainPage.DisplayAlert("Gemifalha!", $"A API retornou '{result.ReasonPhrase}'\nVerifique o seu token!", "ok");
            });
        }

    }
}
