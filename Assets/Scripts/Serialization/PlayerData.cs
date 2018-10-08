using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public struct PlayerData
    {
        public string Name;
        public float HP;
        public int Score;
        public bool IsVisible;

        public override string ToString()
        {
            return string.Format("Name: {0}, Health: {1}, Score: {2}, Visible: {3}", Name, HP, Score, IsVisible);
        }
    }
}
