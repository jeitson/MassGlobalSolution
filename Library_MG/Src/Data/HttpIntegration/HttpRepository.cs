using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Library_MG.Src.Data.HttpIntegration
{
    /// <summary>
    /// Clase para las conexiones HTTP
    /// </summary>
    internal class HttpRepository
    {
        /// <summary>
        /// Metodo generico para consultas tipo GET
        /// </summary>
        /// <typeparam name="O">Objeto de salida</typeparam>
        /// <param name="url">url de consulta</param>
        /// <returns></returns>
        internal async Task<O> Get<O>(string url)
        {
            O result;
            var stringObj = string.Empty;
            try
            {
                //instanciar cliente http
                var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //consumir servicio
                //stringObj 
                stringObj = client.GetStringAsync(url).Result;
                if (stringObj == null)
                    return default;

                result = JsonConvert.DeserializeObject<O>(stringObj);

                if (result == null)
                    return default;
            }
            catch (HttpRequestException ex)
            {
                throw new ArgumentException("Error de conexión al servicio", ex.Message);
            }
            catch (JsonSerializationException ex)
            {
                throw new ArgumentException("Error en la serialización del objeto");
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            return result;
        }
    }
}
