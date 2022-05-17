using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using UnityEngine.UI;


[XmlRoot("dialogue")]
public class Dialogue
{
    [XmlAttribute("more")]
    public int more;

    [XmlElement("node")]
    public Node[] nodes;

    public static Dialogue Load(TextAsset _xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Dialogue));
        StringReader reader = new StringReader(_xml.text);
        Dialogue firstDialoge = serializer.Deserialize(reader) as Dialogue;
        return firstDialoge;
    }
    [System.Serializable]
    public class Node
    {
        [XmlAttribute("tochar")]
        public int Charnow;

        [XmlAttribute("actquest")]
        public int ActQuest;

        [XmlAttribute("numquest")]
        public int NumQuest;

        [XmlAttribute("posofquest")]
        public int PosOfQuest;

        [XmlElement("npctext")]
        public string Npctext;

        [XmlArray("answers")]
        [XmlArrayItem("answer")]
        public Answer[] answers;
    }

    public class Answer
    {
        [XmlAttribute("tonode")]
        public int nextNode;

        [XmlAttribute("actquestA")]
        public int ActQuestA;

        [XmlAttribute("numquestA")]
        public int NumQuestA;

        [XmlAttribute("posofquestA")]
        public int PosOfQuestA;

        [XmlElement("text")]
        public string text;

        [XmlElement("dialend")]
        public string end;
    }

}
