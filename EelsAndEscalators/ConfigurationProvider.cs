using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.Configurations;
using EelsAndEscalators.States;

namespace EelsAndEscalators
{
    class ConfigurationProvider
    {
        XmlDocument doc = new XmlDocument();
        int iD = 1;

        public List<PawnConfig> GetPawnConfig()
        {
            doc.Load(@"C:\Users\HNI\Documents\Aale und rolltreppen\Projekt AuR\EelsAndEscalators\XML\ClassicPawnConfig.xml");
             List<PawnConfig> configurations = new List<PawnConfig>();

            foreach(XmlNode configNode in doc.DocumentElement.ChildNodes)
            {
                string location = configNode.Attributes["location"]?.InnerText;
                string color = configNode.Attributes["color"]?.InnerText;
                string playerID = configNode.Attributes["playerID"]?.InnerText;

                configurations.Add(new PawnConfig(int.Parse(location), int.Parse(color)
                                                 ,int.Parse(playerID),iD));
                iD++;
            }
            iD = 1;
            return configurations;
        }


        public List<EelConfig> GetEelConfig()
        {
            doc.Load(@"C:\Users\HNI\Documents\Aale und rolltreppen\Projekt AuR\EelsAndEscalators\XML\ClassicEelConfig.xml");
            List<EelConfig> configurations = new List<EelConfig>();

            foreach (XmlNode configNode in doc.DocumentElement.ChildNodes)
            {
                string topLocation = configNode.Attributes["toplocation"]?.InnerText;
                string bottomLocation = configNode.Attributes["toplocation"]?.InnerText;

                configurations.Add(new EelConfig(int.Parse(topLocation), int.Parse(bottomLocation)
                                                ,iD));
                iD++;
            }
            iD = 1;
            return configurations;
        }

        public List<EscalatorConfig> GetEscalatorConfig()
        {
            doc.Load(@"C:\Users\HNI\Documents\Aale und rolltreppen\Projekt AuR\EelsAndEscalators\XML\ClassicEscalatorConfig.xml");
            List<EscalatorConfig> configurations = new List<EscalatorConfig>();

            foreach (XmlNode configNode in doc.DocumentElement.ChildNodes)
            {
                string topLocation = configNode.Attributes["toplocation"]?.InnerText;
                string bottomLocation = configNode.Attributes["botlocation"]?.InnerText;

                configurations.Add(new EscalatorConfig(int.Parse(topLocation), int.Parse(bottomLocation)
                                                , iD));
                iD++;
            }
            iD = 1;
            return configurations;
        }

    }
}
