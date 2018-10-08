using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public interface IDataProvider
    {
        void Save(PlayerData data);
        PlayerData Load();
        void SetOption(string path);
    }
}
