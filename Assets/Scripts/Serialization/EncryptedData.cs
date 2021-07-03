using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FPS
{
    public class EncryptedData : IDataProvider
    {
        private string path;

        private string tempPath;

        private DES dcsp;

        public PlayerData Load()
        {

            if (!File.Exists(this.path))
                return default(PlayerData);

            var playerData = new PlayerData();

            dcsp = new DESCryptoServiceProvider();
            dcsp.Key = Encoding.ASCII.GetBytes("ABCDEFGH");
            dcsp.IV = Encoding.ASCII.GetBytes("ABCDEFGH");

            using (var cr = new CryptoStream(File.Open(this.path, FileMode.Open), dcsp.CreateDecryptor(dcsp.Key, dcsp.IV), CryptoStreamMode.Read))
            {
                using (var sr = new StreamReader(cr))
                {
                    playerData.Name = sr.ReadLine();
                    float.TryParse(sr.ReadLine(), out playerData.HP);
                    int.TryParse(sr.ReadLine(), out playerData.Score);
                    bool.TryParse(sr.ReadLine(), out playerData.IsVisible);
                }
            }

            Debug.Log("Data loaded");

            return playerData;
        }

        public void Save(PlayerData data)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(data.Name);
            sb.AppendLine(data.HP.ToString());
            sb.AppendLine(data.Score.ToString());
            sb.AppendLine(data.IsVisible.ToString());

            dcsp = new DESCryptoServiceProvider();
            dcsp.Key = Encoding.ASCII.GetBytes("ABCDEFGH");
            dcsp.IV = Encoding.ASCII.GetBytes("ABCDEFGH");

            using (var cs = new CryptoStream(File.Create(this.path), dcsp.CreateEncryptor(dcsp.Key, dcsp.IV), CryptoStreamMode.Write))
            {
                byte[] tempData = Encoding.ASCII.GetBytes(sb.ToString());
                cs.Write(tempData, 0, tempData.Length);
            }

            sb.Clear();
            Debug.Log("Data saved");
        }

        public void SetOption(string path)
        {
            this.path = Path.Combine(path, "EncryptedData.txt");
        }
    }
}


