using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class PlayerPrefsData : IDataProvider
    {
        public PlayerData Load()
        {
            var playerData = new PlayerData();
            playerData.Name = PlayerPrefs.GetString("Name", playerData.Name);
            playerData.HP = PlayerPrefs.GetFloat("Health", playerData.HP);
            playerData.Score = PlayerPrefs.GetInt("Score", playerData.Score);
            bool.TryParse(PlayerPrefs.GetString("IsVisible", playerData.IsVisible.ToString()), out playerData.IsVisible);

            Debug.Log("Data loaded");
            return playerData;
        }

        public void Save(PlayerData data)
        {
            PlayerPrefs.SetString("Name", data.Name);
            PlayerPrefs.SetFloat("Health", data.HP);
            PlayerPrefs.SetInt("Score", data.Score);
            PlayerPrefs.SetString("IsVisible", data.IsVisible.ToString());
            PlayerPrefs.Save();
            Debug.Log("Data saved");
        }

        public void SetOption(string path)
        {
        }
    }
}