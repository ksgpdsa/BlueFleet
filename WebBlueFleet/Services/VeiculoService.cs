using Application.Dto;
using Application.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Application.Services
{
    public class VeiculoService : IVeiculoService
    {

        private readonly string Url;
        private readonly HttpClient HttpClient;

        public VeiculoService()
        {
            IConfigurationRoot? builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            Url = builder.GetSection("UrlApi").Value;
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(Url)
            };
        }

        public async Task<ResultService<bool>> DeleteAsync(int id)
        {
            try
            {
                HttpResponseMessage? resposta = await HttpClient.DeleteAsync("api/veiculos/" + id);

                string? resposta_json = await resposta.Content.ReadAsStringAsync();
                ResultService<bool>? resultado = JsonConvert.DeserializeObject<ResultService<bool>>(resposta_json);

                if (resposta.IsSuccessStatusCode && resultado != null)
                    return resultado;

                return new ResultService<bool>
                {
                    IsSucess = false,
                    Message = resposta.RequestMessage.ToString(),
                    Erros = resultado.Erros
                };
            }
            catch (Exception e)
            {
                return new ResultService<bool>
                {
                    IsSucess = false,
                    Message = e.Message
                };
            }

        }

        public async Task<ResultService<IEnumerable<VeiculosDto>>> GetAllAsync()
        {
            try
            {
                HttpResponseMessage? resposta = await HttpClient.GetAsync("api/veiculos");

                string? resposta_json = await resposta.Content.ReadAsStringAsync();
                ResultService<IEnumerable<VeiculosDto>>? resultado = JsonConvert.DeserializeObject<ResultService<IEnumerable<VeiculosDto>>>(resposta_json);

                if (resposta.IsSuccessStatusCode && resultado != null)
                    return resultado;

                return new ResultService<IEnumerable<VeiculosDto>>
                {
                    IsSucess = false,
                    Message = resposta.RequestMessage.ToString(),
                    Erros = resultado.Erros
                };
            }
            catch (Exception e)
            {
                return new ResultService<IEnumerable<VeiculosDto>>
                {
                    IsSucess = false,
                    Message = e.Message
                };
            }
        }

        public async Task<ResultService<VeiculosDto>> GetByIdAsync(int id)
        {
            try
            {
                HttpResponseMessage? resposta = await HttpClient.GetAsync("api/veiculos/" + id);

                string? resposta_json = await resposta.Content.ReadAsStringAsync();
                ResultService<VeiculosDto>? resultado = JsonConvert.DeserializeObject<ResultService<VeiculosDto>>(resposta_json);

                if (resposta.IsSuccessStatusCode && resultado != null)
                    return resultado;

                return new ResultService<VeiculosDto>
                {
                    IsSucess = false,
                    Message = resposta.RequestMessage.ToString(),
                    Erros = resultado.Erros
                };
            }
            catch (Exception e)
            {
                return new ResultService<VeiculosDto>
                {
                    IsSucess = false,
                    Message = e.Message
                };
            }
        }

        public async Task<ResultService<bool>> SaveAsync(VeiculosDto veiculoDto)
        {
            try
            {
                StringContent? conteudo = new StringContent(JsonConvert.SerializeObject(veiculoDto), Encoding.UTF8, "application/Json");

                HttpResponseMessage? resposta = await HttpClient.PostAsync("api/veiculos/", conteudo);

                string? resposta_json = await resposta.Content.ReadAsStringAsync();
                ResultService<bool>? resultado = JsonConvert.DeserializeObject<ResultService<bool>>(resposta_json);

                if (resposta.IsSuccessStatusCode && resultado != null)
                    return resultado;

                return new ResultService<bool>
                {
                    IsSucess = false,
                    Message = resposta.RequestMessage.ToString(),
                    Erros = resultado.Erros
                };
            }
            catch (Exception e)
            {
                return new ResultService<bool>
                {
                    IsSucess = false,
                    Message = e.Message
                };
            }
        }

        public async Task<ResultService<bool>> UpdateAsync(VeiculosDto veiculoDto)
        {
            try
            {
                StringContent? conteudo = new StringContent(JsonConvert.SerializeObject(veiculoDto), Encoding.UTF8, "application/Json");

                HttpResponseMessage? resposta = await HttpClient.PutAsync("api/veiculos/" + veiculoDto.Id, conteudo);
                string? resposta_json = await resposta.Content.ReadAsStringAsync();

                ResultService<bool>? resultado = JsonConvert.DeserializeObject<ResultService<bool>>(resposta_json);

                if (resposta.IsSuccessStatusCode && resultado != null)
                    return resultado;

                return new ResultService<bool>
                {
                    IsSucess = false,
                    Message = resposta.RequestMessage.ToString(),
                    Erros = resultado.Erros
                };
            }
            catch (Exception e)
            {
                return new ResultService<bool>
                {
                    IsSucess = false,
                    Message = e.Message
                };
            }
        }
    }
}
