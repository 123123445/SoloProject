using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using TMPro;

public class BestScore : MonoBehaviour
{
    private void Start()
    {
        string path = @"./Assets/Resource/Score.xml";
        bool fileExist = File.Exists(path);

        if (!fileExist)
        {
            CreateXml();
        }
        else
        {
            SaveOverlapXml();
        }
    }

    void CreateXml()   //Xml파일 만들기
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.AppendChild(xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

        XmlNode root = xmlDoc.CreateNode(XmlNodeType.Element, "BestScoreNode", string.Empty);
        xmlDoc.AppendChild(root);

        XmlNode child = xmlDoc.CreateNode(XmlNodeType.Element, "Best", string.Empty);
        root.AppendChild(child);

        XmlElement BestScore = xmlDoc.CreateElement("BestScore");
        BestScore.InnerText = GameManager.instance.score.ToString();
        child.AppendChild(BestScore);

        xmlDoc.Save("./Assets/Resource/Score.xml");
    }

    void SaveOverlapXml()  //Xml파일 덮어씌기
    {
        TextAsset textAsset = (TextAsset)Resources.Load("BestScore");
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(textAsset.text);

        XmlNodeList nodes = xmlDoc.SelectNodes("BestScoreNode/Best");
        XmlNode BestScoreNode = nodes[0];

        BestScoreNode.SelectSingleNode("BestScore").InnerText = GameManager.instance.score.ToString();

        xmlDoc.Save("./Assets/Resources/BestScore.xml");
    }
}
