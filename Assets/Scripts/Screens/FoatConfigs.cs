using System.Collections.Generic;
using GamePlay;
using UnityEngine;

namespace Screens
{
    [CreateAssetMenu(fileName = "FoatConfigs", menuName = "FoatConfigs/Config")]
    public class FoatConfigs : ScriptableObject
    {
        [SerializeField] public List<BaseConfig> _configsPrefab;

        public BaseConfig GetConfigs(int indexConfig) => _configsPrefab[indexConfig];
    }
}