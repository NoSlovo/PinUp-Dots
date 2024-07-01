using System;
using System.Collections.Generic;
using GamePlay;
using UnityEngine;

namespace Screens
{
    [CreateAssetMenu(fileName = "FoatConfigs", menuName = "FoatConfigs/Config")]
    public class FoatConfigs : ScriptableObject
    {
        [SerializeField] public List<LevelData> _configsPrefab;

        public LevelData GetConfigs(int indexConfig)
        {
            if (indexConfig >= _configsPrefab.Count)
                return _configsPrefab[_configsPrefab.Count - 1];
            
            return _configsPrefab[indexConfig];
        }
    }

    [Serializable]
    public struct LevelData
    {
        public int Index;
        public BaseConfig Prefab;
        public Sprite PaternImage;
    }
}