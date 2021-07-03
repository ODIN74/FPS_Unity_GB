using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FPS
{
    public class BinaryData : IDataProvider
    {
        private string path;

        public PlayerData Load()
        {
            if (!File.Exists(this.path))
                return default(PlayerData);

            var playerData = new PlayerData();

            using (var br = new BinaryReader(File.Open(this.path, FileMode.Open)))
            {
                playerData.Name = br.ReadString();
                playerData.HP = br.ReadSingle();
                playerData.Score = br.ReadInt32();
                playerData.IsVisible = br.ReadBoolean();
            }

            Debug.Log("Data loaded");

            return playerData;
        }

        public void Save(PlayerData data)
        {
            using (var bw = new BinaryWriter(File.Open(this.path, FileMode.Create)))
            {
                bw.Write(data.Name);
                bw.Write(data.HP);
                bw.Write(data.Score);
                bw.Write(data.IsVisible);
            }

            Debug.Log("Data saved");
        }

        public void SetOption(string path)
        {
            this.path = Path.Combine(path, "BinaryData.bin");
        }
    }
}
