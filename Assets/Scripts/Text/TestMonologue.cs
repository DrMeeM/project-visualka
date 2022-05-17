using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using UnityEngine.UI;

[XmlRoot("monologue")]
public class TestMonologue
{
    [XmlElement("node")]
    public MainRootNode[] nodes;

    public static TestMonologue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(TestMonologue));
        StringReader reader = new StringReader(_xml.text);
        TestMonologue mono = serializer.Deserialize(reader) as TestMonologue;
        return mono;
    }
    
    [System.Serializable]
    public class MainRootNode
    {
        [XmlElement("npctext")]
        public string Npctext;
    }
   
}
