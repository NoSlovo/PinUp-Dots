using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LoadingScreen
{
    [Serializable]
    public struct DataSlider
    {
        [SerializeField] private List<String> _listTextData;
        [SerializeField] private List<Sprite> _spritesData;

        private int _itemsIndex;
        
        public void SetDataSlide(TextMeshProUGUI _textData, Image _sprite)
        {
            _textData.text = _listTextData[_itemsIndex];
            _sprite.sprite = _spritesData[_itemsIndex];
            NextItems();
        }

        private void NextItems()
        {
            _itemsIndex++;
            if (_itemsIndex >= _listTextData.Count || _itemsIndex >= _spritesData.Count)
                _itemsIndex = 0;
            
        }
    }
}