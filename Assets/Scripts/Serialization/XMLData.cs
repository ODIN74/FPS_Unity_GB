using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

namespace FPS
{

    public class XMLData : IDataProvider
    {
        private string path;

        public PlayerData Load()
        {
            if (!File.Exists(this.path))
                return default(PlayerData);

            var playerData = new PlayerData();

            string key;

            using (var reader = new XmlTextReader(File.OpenRead(path)))
            {
                while (reader.Read())
                {
                    key = "Name";
                    if (reader.IsStartElement(key))
                        playerData.Name = reader.GetAttribute("value");

                    key = "Health";
                    if (reader.IsStartElement(key))
                        float.TryParse(reader.GetAttribute("value"), out playerData.HP);

                    key = "Score";
                    if (reader.IsStartElement(key))
                        int.TryParse(reader.GetAttribute("value"), out playerData.Score);

                    key = "IsVisible";
                    if (reader.IsStartElement(key))
                        bool.TryParse(reader.GetAttribute("value"), out playerData.IsVisible);
                }
            }
            Debug.Log("Data Loaded");
            return playerData;
        }

        public void Save(PlayerData data)
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement("PlayerData");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", data.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("Health");
            element.SetAttribute("value", data.HP.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("Score");
            element.SetAttribute("value", data.Score.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsVisible");
            element.SetAttribute("value", data.IsVisible.ToString());
            rootNode.AppendChild(element);

            xmlDoc.Save(this.path);

            Debug.Log("Data saved");
        }

        public void SetOption(string path)
        {
            this.path = Path.Combine(path, "XMLData.xml");
        }
    }
}
