using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace FPS
{
    public class JSONData : IDataProvider
    {
        private string path;

        public PlayerData Load()
        {
            if (!File.Exists(path))
                return default(PlayerData);

            var playerData = new PlayerData();
            var str = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(str);
            Debug.Log("Data loaded");
            return playerData;
        }

        public void Save(PlayerData data)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, str);
            Debug.Log("Data saved");
        }

        public void SetOption(string path)
        {
            this.path = Path.Combine(path, "JSONData.txt");
        }
    }
}

