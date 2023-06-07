using System.Net;

namespace GasStation.Application.Server
{
    public class HttpServer
    {
        private readonly string _url;

        public HttpServer(string url)
        {
            _url = url;
        }

        /// <summary>
        /// Прослушивает запросы по указанному адресу
        /// </summary>
        /// <param name="methods">Набор действий, на каждый тип HTTP запроса</param>
        /// <returns></returns>
        public async Task Start(Dictionary<string, Delegate> methods)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(_url);
            listener.Start();

            while (true)
            {
                var context = await listener.GetContextAsync();

                var method = methods[context.Request.HttpMethod];
                if (method is null)
                    continue;

                //на null, просто ""

                //параметры нужного метода
                var a = method.Method.GetParameters();

                var data = new StreamReader(context.Request.InputStream).ReadToEnd();

                //method.DynamicInvoke(data);

                //method.DynamicInvoke();
            }
        }
    }
}
