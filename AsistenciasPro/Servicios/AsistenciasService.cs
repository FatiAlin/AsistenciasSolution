using System.Net.Http;
using System.Net.Http.Json;
using AsistenciasShared;
using static System.Net.WebRequestMethods;

namespace AsistenciasPro.Servicios
{
    public class AsistenciasService
    {
        private readonly HttpClient _httpClient;

        public AsistenciasService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<AsistenciaDTO>> GetListaAsistencia()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Asistencias");

                if (response.IsSuccessStatusCode)
                {
                    var Lista = await response.Content.ReadFromJsonAsync<List<AsistenciaDTO>>();
                    if (Lista != null)
                    {
                        return Lista;
                    }
                    else
                    {
                        Console.WriteLine("Carga academica no encontrada");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine($"Error al obtener la Carga academica: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al obtener la Carga academica: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Asistencias/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var Lista = await response.Content.ReadFromJsonAsync<List<AsistenciaDTO>>();
                    if (Lista != null)
                    {
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Carga academica no encontrada");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine($"Error al obtener la Carga academica: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción al obtener la Carga academica: {ex.Message}");
                return null;
            }
        }
    }
}
