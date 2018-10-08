using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class TestData : MonoBehaviour
    {
        private IDataProvider _dataProvider;
        
        // Use this for initialization
        void Start()
        {
            _dataProvider = new EncryptedData();
            var path = Application.dataPath;
            var player = new PlayerData()
            {
                Name = "MyPlayer83",
                HP = 58f,
                Score = 123456,
                IsVisible = true
            };

            if (_dataProvider == null)
                return;
            
            _dataProvider.SetOption(path);
            _dataProvider.Save(player);

            var playerLoaded = _dataProvider.Load();

            Debug.Log(playerLoaded);
        }

    }
}


