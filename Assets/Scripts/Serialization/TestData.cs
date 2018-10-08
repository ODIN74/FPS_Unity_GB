using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class TestData : MonoBehaviour
    {
        private DataManager _dataManager;

        public enum DataProviders
        {
            BINARY,
            ENCRIPTEDTXT,
            JSON,
            XML,
            PLAYER_PREFS
        }

        [SerializeField]
        private DataProviders _provider;
        
        // Use this for initialization
        void Start()
        {
            _dataManager = new DataManager();
            switch (_provider)
            {
                case DataProviders.BINARY:
                    _dataManager.SetData<BinaryData>();
                    break;
                case DataProviders.ENCRIPTEDTXT:
                    _dataManager.SetData<EncryptedData>();
                    break;
                case DataProviders.JSON:
                    _dataManager.SetData<JSONData>();
                    break;
                case DataProviders.XML:
                    _dataManager.SetData<XMLData>();
                    break;
                case DataProviders.PLAYER_PREFS:
                    _dataManager.SetData<PlayerPrefsData>();
                    break;
            }

            var path = Application.dataPath;
            var player = new PlayerData()
            {
                Name = "MyPlayer83",
                HP = 58f,
                Score = 123456,
                IsVisible = true
            };

            if (_dataManager == null)
                return;
            
            _dataManager.SetOption(path);
            _dataManager.Save(player);

            var playerLoaded = _dataManager.Load();

            Debug.Log(playerLoaded);
        }

    }
}


