using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PredictParser
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            while (true)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.predictit.org/api/marketdata/all/");
                request.Accept = "application/xml";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Console.WriteLine(response.StatusDescription);

                Stream dataStream = response.GetResponseStream();
                XmlReader reader = XmlReader.Create(dataStream);

                XmlSerializer serializer = new XmlSerializer(typeof(MarketList));
                MarketList markets = (MarketList)serializer.Deserialize(reader);

                foreach (MarketData market in markets.Markets)
                {
                    FindArb(market);
                }

                reader.Close();
                dataStream.Close();
                response.Close();

                Thread.Sleep(60000);
            }
            
        }

        static void FindArb(MarketData market)
        {
            if (market.Contracts.Length == 1)
                return;

            double sum = 0;

            foreach (MarketContract contract in market.Contracts)
            {
                if (contract.BestBuyYesCost != "")
                    sum += Convert.ToDouble(contract.BestBuyYesCost);
                else
                    return;
            }

            if (sum < 0.9)
            {
                Console.WriteLine("Arb oppty exists in " + market.Name);
            }
        }
    }
}
