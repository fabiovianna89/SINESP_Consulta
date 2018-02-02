using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsultaSinesp
{
    public class DebitosVeiculo
    {
        public string codigoRetorno { get; set; }
        public string mensagemRetorno { get; set; }
        public string codigoSituacao { get; set; }
        public string situacao { get; set; }
        public string modelo { get; set; }
        public string marca { get; set; }
        public string cor { get; set; }
        public string ano { get; set; }
        public string anoModelo { get; set; }
        public string chassi { get; set; }
        public string uf { get; set; }
        public string municipio { get; set; }
    }
    public class ConsultarPlaca2
    {
        private string secret = "#8.1.0#Mw6HqdLgQsX41xAGZgsF";
        private string url = "https://189.9.194.154/sinesp-cidadao/mobile/consultar-placa/v3";
        private string proxy = null;
        private string placa = "";
        private string response = "";
        private Array dados;
        private CookieContainer cookies;





        private string RemoverAcentos(string texto)
        {
            string s = texto.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < s.Length; k++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(s[k]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(s[k]);
                }
            }
            return sb.ToString();
        }
        private string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
        public string ConsultarPlaca(string placa)
        {
            XmlDocument document = new XmlDocument();
            XmlDocument doc = new XmlDocument();
            try
            {

                int nErros = 0;

                Uri urlpost = new Uri(url);
                HttpWebRequest httpPostConsulta = (HttpWebRequest)HttpWebRequest.Create(urlpost);
                string key = placa + secret;
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] keyByte = encoding.GetBytes(key);
                HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
                byte[] messageBytes = encoding.GetBytes(placa);

                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);

                string hmac2 = ByteToString(hashmessage).ToLower();
                //Xml que vai para o servidor do sinesp cidadao
                StringBuilder postConsultaComParametros = new StringBuilder();

                postConsultaComParametros.Append("<v:Envelope xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns:d='http://www.w3.org/2001/XMLSchema' xmlns:c='http://schemas.xmlsoap.org/soap/encoding/' xmlns:v='http://schemas.xmlsoap.org/soap/envelope/'>");
                postConsultaComParametros.Append("<v:Header>                                                                  ");
                postConsultaComParametros.Append("<b>Google Android SDK built for x86</b>                                                     ");
                postConsultaComParametros.Append("<c>ANDROID</c>                                                              ");
                postConsultaComParametros.Append("<d>8.1.0</d>                                                                ");

                postConsultaComParametros.Append("<e>4.3.2</e>                                                                ");
                postConsultaComParametros.Append("<f>10.0.2.15</f>                                                             ");
                postConsultaComParametros.Append("<g>" + hmac2 + "</g>                                                                   ");

                postConsultaComParametros.Append("<h>0.0</h>                                                                   ");
                postConsultaComParametros.Append("<i>0.0</i>                                                                   ");
                postConsultaComParametros.Append("<k></k>                                                                     ");
                postConsultaComParametros.Append("<l>" + String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + "</l>");
                postConsultaComParametros.Append("<m>8797e74f0d6eb7b1ff3dc114d4aa12d3</m>                                     ");
                postConsultaComParametros.Append("</v:Header>                                                                 ");
                postConsultaComParametros.Append("<v:Body>                                                                    ");
                postConsultaComParametros.Append("<n0:getStatus xmlns:n0='http://soap.ws.placa.service.sinesp.serpro.gov.br/'>");
                postConsultaComParametros.Append("<a>" + placa + "</a>");
                postConsultaComParametros.Append("</n0:getStatus>");
                postConsultaComParametros.Append("</v:Body>");
                postConsultaComParametros.Append("</v:Envelope>");





                var data = Encoding.ASCII.GetBytes(postConsultaComParametros.ToString());
                httpPostConsulta.Method = "POST";
                httpPostConsulta.ContentType = "text/xml;charset=utf-8";
                httpPostConsulta.ContentLength = data.Length;
                httpPostConsulta.KeepAlive = false;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                // Skip validation of SSL/TLS certificate
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                using (var stream = httpPostConsulta.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)httpPostConsulta.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString.ToString();




            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return "";
        }






        private static double longitude()
        {
            Random rng = new Random();
            int random = rng.Next(100000, 999999);



            return -3.7d - random / 1000000000d;
        }

        private static double latitude()
        {
            Random rng = new Random();
            int random = rng.Next(100000, 999999);

            return -38.5d - random / 1000000000d;
        }
    }
}
