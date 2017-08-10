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

        public string From { get; set; }

        public string To { get; set; }

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
