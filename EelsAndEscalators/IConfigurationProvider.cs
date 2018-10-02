using System.Collections.Generic;
using System.Xml.Linq;

namespace EelsAndEscalators
{
    //Nico
    public interface IConfigurationProvider
    {
        List<XElement> GetEntityConfigurations();
    }
}