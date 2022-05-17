using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using UnityEngine.UI;


[XmlRoot("quest")]
public class ReedQuest
{

    [XmlElement("task")]
    public Quest[] quests;

    public static ReedQuest Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ReedQuest));
        StringReader reader = new StringReader(_xml.text);
        ReedQuest firstDialoge = serializer.Deserialize(reader) as ReedQuest;
        return firstDialoge;
    }
    [System.Serializable]
    public class Quest
    {
        [XmlAttribute("kvest")]
        public int numberofkvest;

        [XmlAttribute("type")]
        public int typequest;

        [XmlElement("name")]
        public string NameText;

        [XmlElement("short")]
        public string ShortText;

        [XmlElement("long")]
        public string LongText;

        [XmlArray("parameters")]
        [XmlArrayItem("parameter")]
        public Parameters[] Parameters;
    }

    public class Parameters
    {
        [XmlAttribute("kolvo")]
        public int kolvo;
        [XmlElement("text")]
        public string text;
    }

}
