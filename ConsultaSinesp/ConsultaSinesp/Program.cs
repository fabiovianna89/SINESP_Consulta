using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsultaSinesp
{
    class Program
    {
        static void Main(string[] args)
        {
            var placa = "Inserir placa aqui";


            DebitosVeiculo debitos = new DebitosVeiculo();
            ConsultarPlaca2 consultar = new ConsultarPlaca2();

            XDocument doc = XDocument.Parse(consultar.ConsultarPlaca(placa));
            XNamespace ns = "http://soap.ws.placa.service.sinesp.serpro.gov.br/";
            IEnumerable<XElement> responses = doc.Descendants("return");
            foreach (XElement response in responses)
            {
                debitos.mensagemRetorno = (string)response.Element("mensagemRetorno");
                debitos.codigoSituacao = (string)response.Element("codigoSituacao");
                debitos.codigoRetorno = (string)response.Element("codigoRetorno");
                debitos.situacao = (string)response.Element("situacao");
                debitos.modelo = (string)response.Element("modelo");
                debitos.marca = (string)response.Element("marca");
                debitos.cor = (string)response.Element("cor");
                debitos.ano = (string)response.Element("ano");
                debitos.anoModelo = (string)response.Element("anoModelo");
                debitos.chassi = (string)response.Element("chassi");
                debitos.uf = (string)response.Element("uf");
                debitos.municipio = (string)response.Element("municipio");
            }
            Console.WriteLine(debitos.mensagemRetorno);
            Console.WriteLine(debitos.codigoSituacao);
            Console.WriteLine(debitos.codigoRetorno);
            Console.WriteLine(debitos.situacao);
            Console.WriteLine(debitos.modelo);
            Console.WriteLine(debitos.marca);
            Console.WriteLine(debitos.cor);
            Console.WriteLine(debitos.ano);
            Console.WriteLine(debitos.anoModelo);
            Console.WriteLine(debitos.chassi);
            Console.WriteLine(debitos.uf);
            Console.WriteLine(debitos.municipio);

            Console.ReadKey();
        }
    }
}
