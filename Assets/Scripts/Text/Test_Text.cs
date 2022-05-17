using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Test_Text : MonoBehaviour
{
    public Text firstTry;
    void Start()
    {
        Test_str();
    }
    public void Test_str()
    {
        
        //StreamReader sr = new StreamReader("C:\\Users\\Игорь\\wkspaces\\Ocnovs\\Assets\\Text\\Test.txt", Encoding.GetEncoding("windows-1251"));
        StreamReader ss = new StreamReader(Application.dataPath + "/Text/Test.txt", Encoding.GetEncoding("windows-1251"));
        //string line = sr.ReadLine();
        string line2 = ss.ReadLine();
        firstTry.text = line2;
        //Debug.Log(line);
        Debug.Log(line2);      
    }
    /*
    [XmlRoot("firstdialog")]
    public class FirstDialoge
    {
        [XmlElement("text")]
        public string text;

        [XmlElement("node")]
        public Node[] nodes;

        public static FirstDialoge Load(TextAsset _xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(FirstDialoge));
            StringReader reader = new StringReader(_xml.text);
            FirstDialoge firstDialoge = serializer.Deserialize(reader) as FirstDialoge;
            return firstDialoge;
        }
    }
    [System.Serializable]
    public class Node
    {
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
        [XmlElement("text")]
        public string text;
        [XmlElement("dialend")]
        public string end;
    }
    */
}
