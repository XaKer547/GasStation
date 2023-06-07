using GasStation.Domain.Models.DTOs.FuelDTO;
using GasStation.Domain.Services;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;

namespace GasStation.Application.Services
{
    public class ServerService
    {
        public async Task<TcpClient> ConnectToServer(string ip, int port)
        {
            return new TcpClient(ip, port);
        }

        public async Task StartHttpServer(string uri)
        {
            var server = new HttpListener();
            server.Prefixes.Add(uri);

            server.Start();

            while (true)
            {
                //сработает когда кто-то кинет запрос
                var context = await server.GetContextAsync();

                var request = context.Request;


                string text;

                text = new StreamReader(request.InputStream, request.ContentEncoding).ReadToEnd();

                //queryString содержит переменные
                var response = context.Response;
                string responseText =
                  @"<!DOCTYPE html>
                  <html>
                        <head>
                            <meta charset='utf8'>
                           <title>METANIT.COM</title>
                        </head>
                         <body>
                              <h2>Hello METANIT.COM</h2>
                         </body>
                 </html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseText);
                // получаем поток ответа и пишем в него ответ
                response.ContentLength64 = buffer.Length;
                using Stream output = response.OutputStream;
                // отправляем данные
                await output.WriteAsync(buffer);
                await output.FlushAsync();
            }
        }

        //данные получаем через запросы, как REPONSE

        private async Task SendData(string message)
        {


        }




        public async Task StartTCPServer(IPAddress ip, int id)
        {
            //$"{102}{id}"
            var server = new TcpListener(ip, int.Parse(string.Join("", 102, id)));
            server.Start();

            while (true)
            {



            }
        }


        //сервер просто курирует процесс, методы в классах других
    }
}
