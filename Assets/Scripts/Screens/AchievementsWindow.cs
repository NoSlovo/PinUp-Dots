using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class AchievementsWindow : BaseScreen.BaseScreen
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private AchigmentsConfig _configsAchigments; 
        [SerializeField] private Sprite _activeAchigment;
        [SerializeField] private Sprite  _inactiveAchigment;
        [SerializeField] private List<AchigmenstsData> _achigments;
        private void Start()
        {
            _buttonBack.onClick.AddListener(ScreenService.OpenScreenMenu);
            InitAchievements();
        }

        private void InitAchievements()
        {
            for (int i = 0; i < _achigments.Count; i++)
            {
                var achigmentsData = _configsAchigments.GetAchigmentsData(i);
                _achigments[i]._discription.text  = achigmentsData._description;
                _achigments[i]._imageAchigment.sprite = achigmentsData._status ? _activeAchigment : _inactiveAchigment;
            }
        }
    }


    [Serializable]
    public struct AchigmenstsData
    {
        public Image _imageAchigment;
        public TextMeshProUGUI _discription;
    }

}