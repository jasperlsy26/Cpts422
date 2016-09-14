using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace CS422
{
    public class WebServer
    {
        public WebServer()
        {

        }

        /// <summary>
        ///  takes an integer port for the TCP connection as
        ///  the first parameter.The second parameter is a template string for the HTTP response
        /// </summary>
        /// <remarks>using 4220 for port testing (80 by default)</remarks>
        /// <param name="port"></param>
        /// <param name="responseTemplate"></param>
        /// <returns></returns>
        public static bool Start(int port, string responseTemplate)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();

            //blocking call
            var client = listener.AcceptTcpClient();

            //use using keyword to ensure ns get disposed
            using(NetworkStream ns = client.GetStream())
            {
                byte[] buf = new byte[4096];
                //consider using a string buildder form the connection string as everytime it reads
                StringBuilder sb = new StringBuilder();



                //using a while loop to keep reading til its done
                while (true)
                {
                    //TODO: check, if done reading, break

                    int bytesRead = ns.Read(buf, 0, buf.Length);
                    sb.Append(Encoding.ASCII.GetString(buf, 0, bytesRead));

                    //TODO: check for valid HTTP GET cmd

                    
                    

                }
            }



            return true;
        }
    }
}
