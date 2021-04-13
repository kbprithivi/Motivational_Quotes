using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using System.IO;

namespace AdaptiveCardsBot
{
    public class ReadXml
    {
        private string jsonString;

        public string carddata()
        {
            var nodeCount = 0;
            using (var reader = XmlReader.Create(@"C:\Users\kbpri\source\repos\123\samples\csharp_dotnetcore\07.using-adaptive-cards\Resources\Quotes.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element &&
                        reader.Name == "Quotes")
                    {
                        nodeCount++;
                    }
                }
            }
            //Console.WriteLine("Count" + nodeCount);

            List<string> xmlnamme = new List<string>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\Users\kbpri\source\repos\123\samples\csharp_dotnetcore\07.using-adaptive-cards\Resources\Quotes.xml");
            XmlNodeList xmlNodeList = xmlDoc.DocumentElement.SelectNodes("/Motivational_Quotes");
            //Console.WriteLine(xmlNodeList);
            XmlNodeList nodeList = xmlNodeList;

            //Console.WriteLine("Test:" + xmlDoc.DocumentElement.SelectSingleNode("Name[" + 2 + "]").InnerText);
            // XmlNode node = nodeList;
            for (int i = 1; i <= nodeCount; i++)
            {
                string Nameqw = xmlDoc.DocumentElement.SelectSingleNode("Quotes[" + i + ']').InnerText;
                xmlnamme.Add(Nameqw);

                //Console.WriteLine("List ADD :" + Nameqw);
            }
            Random r = new Random();

            jsonwrite(xmlnamme[r.Next(1,774)]);

            return xmlnamme[99];
        }


        public void jsonwrite(string quote)
        {
            var json = File.ReadAllText(@"C:\Users\kbpri\source\repos\123\samples\csharp_dotnetcore\07.using-adaptive-cards\Resources\SolitaireCard.json");
            dynamic jObject = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            // JToken jToken = jObject.SelectToken("body.text");
            jObject["body"][0]["text"] = quote;
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C:\Users\kbpri\source\repos\123\samples\csharp_dotnetcore\07.using-adaptive-cards\Resources\SolitaireCard.json", output);
           // string updatedJsonString = jObject.ToString();
          //  File.WriteAllText(@"C:\Users\kbpri\source\repos\123\samples\csharp_dotnetcore\07.using-adaptive-cards\Resources\SolitaireCard.json", updatedJsonString);
        }
    }
}
    

    

