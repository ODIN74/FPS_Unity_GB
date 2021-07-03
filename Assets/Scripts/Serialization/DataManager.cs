using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class DataManager
    {
        private IDataProvider _dataProvider;

        public void SetData<T>() where T : IDataProvider, new()
        {
            _dataProvider = new T();
        }

        public void Save(PlayerData data)
        {
            if (_dataProvider != null)
                _dataProvider.Save(data);
        }

        public PlayerData Load()
        {
            if (_dataProvider == null)
                return default(PlayerData);

            return _dataProvider.Load();
        }

        public void SetOption(string path)
        {
            if (_dataProvider != null)
                _dataProvider.SetOption(path);
        }
    }
}