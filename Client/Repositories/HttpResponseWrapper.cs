using System.Net;

namespace appAUGEuropa2.Client.Repositories
{
    public class HttpResponseWrapper<T>
    {
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;
        }

        public bool Error { get; set; }
        public T? Response { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> ObtenerMensajeError()
        {
            if (!Error)
            {
                return null;
            }
            var codigoEstatus = HttpResponseMessage.StatusCode;

            if (codigoEstatus == HttpStatusCode.NotFound)
            {
                return "Resource not found";
            }
            else if (codigoEstatus == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (codigoEstatus == HttpStatusCode.Unauthorized)
            {
                return "You need tob registered to select this option";
            }
            else if (codigoEstatus == HttpStatusCode.Forbidden)
            {
                return "You do not have sufficient permissions to perform this option";
            }
            else if (codigoEstatus == HttpStatusCode.NoContent)
            {
                return "Ok";
            }
            else
            {
                return "An unexpected error has occurred";
            }
        }
    }
}
