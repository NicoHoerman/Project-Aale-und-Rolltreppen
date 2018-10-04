using System.Collections.Generic;
using System.Text;
using System.Xml;
using EelsAndEscalators;
using EelsAndEscalators.Contracts;
using EelsAndEscalators.States;
using System.Xml.Linq;
using System.Linq;

namespace EelsAndEscalators
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly string _configurationFile;

        private List<XElement> _configurations;

        public ConfigurationProvider(string configurationFile)
        {
            _configurationFile = configurationFile;

            ReadConfigurationFile();
        }

        public ConfigurationProvider()
            : this(@".\XML\Configurations.xml")
        { }


        private void ReadConfigurationFile()
        {
            var doc = XDocument.Load(_configurationFile);
            _configurations = doc.Root.Elements().ToList();
        }

        public List<XElement> GetEntityConfigurations() => _configurations;
    }
}
