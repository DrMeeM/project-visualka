using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using UnityEngine.UI;


[XmlRoot("locations")]
public class ReedNameLoc
{
    [XmlElement("location")]
    public Lock[] lockes;

    public static ReedNameLoc Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ReedNameLoc));
        StringReader reader = new StringReader(_xml.text);
        ReedNameLoc Locat = serializer.Deserialize(reader) as ReedNameLoc;
        return Locat;
    }
    [System.Serializable]



    public class Lock
    {
        [XmlAttribute("toloc")]
        public int numberloc;

        [XmlElement("name")]
        public string name;

        [XmlElement("discr")]
        public string discr;
    }
}
