using System;
using System.Collections.Generic;
using GamePlay;
using UnityEngine;

namespace Screens
{
    [CreateAssetMenu(fileName = "FoatConfigs", menuName = "FoatConfigs/Config")]
    public class FoatConfigs : ScriptableObject
    {
        [SerializeField] public List<LevelData> ConfigsPrefab;

        public LevelData GetConfigs(int indexConfig)
        {
            if (indexConfig >= ConfigsPrefab.Count)
                return ConfigsPrefab[ConfigsPrefab.Count - 1];

            return ConfigsPrefab[indexConfig];
        }

        public void SaveResult(int indexConfig, Sprite result)
        {
            var levelData = ConfigsPrefab[indexConfig];
            levelData.Result = result;
            ConfigsPrefab[indexConfig] = levelData;
        }
    }

    [Serializable]
    public struct LevelData
    {
        public int Index;
        public BaseConfig Prefab;
        public Sprite PaternImage;
        public float Time;
        public Sprite Result;

        public void SetResult(Sprite result)
        {
            Result = result;
        }
    }
}