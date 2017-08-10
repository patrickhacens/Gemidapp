using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gemidapp.Services
{
    class TotalVoiceService
    {

        public async Task<HttpResponseMessage> Call(string from, string to, string token)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Access-Token", token);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var data = new
            {
                numero_destino = to,
                dados = new object[]
                {
                    new
                    {
                        acao = "audio",
                        acao_dados = new
                        {
                            url_audio = "https://github.com/haskellcamargo/gemidao-do-zap/raw/master/resources/gemidao.mp3"
                        }
                    }
                },
                bina = from
            };
            return await client.PostAsync("https://api.totalvoice.com.br/composto", new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
        }
    }

    
}
