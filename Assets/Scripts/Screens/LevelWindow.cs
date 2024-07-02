using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
    public class LevelWindow : BaseScreen.BaseScreen
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private ItemLevel _itemLevel;
        [SerializeField] private FoatConfigs _foatConfigs;
        [SerializeField] private RectTransform _instanceContainer;
        [SerializeField] private Button _buttonNext;
        [SerializeField] private Button _buttonPrev;

        private int _itemsIndex = 0;
        private int _maxElements = 0;

        private int _stepItems = 9;

        private List<ItemLevel> _activeElements = new();

        private void OnEnable()
        {
            _buttonNext.onClick.AddListener(NextObjects);
            _buttonPrev.onClick.AddListener(BackData);
        }

        private void Start()
        {
            _buttonBack.onClick.AddListener(ScreenService.OpenScreenMenu);
            _buttonPrev.gameObject.SetActive(false);
            _maxElements = _stepItems;
            InitDataLevel();
        }

        private void InitDataLevel()
        {
            for (int i = _itemsIndex; _itemsIndex < _maxElements; _itemsIndex++)
            {
                var instantiateLevel = Instantiate(_itemLevel, _instanceContainer.transform);
                instantiateLevel.SetDataLevel(_foatConfigs.ConfigsPrefab[_itemsIndex].Index,
                    _foatConfigs.ConfigsPrefab[_itemsIndex].Result);
                _activeElements.Add(instantiateLevel);
            }
        }

        private void NextObjects()
        {
            _itemsIndex = _maxElements;
            _maxElements += _stepItems;
            ClearElements();
            InitDataLevel();
            _buttonNext.gameObject.SetActive(false);
            _buttonPrev.gameObject.SetActive(true);
        }

        private void BackData()
        {
            _itemsIndex = 0;
            _maxElements -= _stepItems;
            ClearElements();
            InitDataLevel();
            _buttonPrev.gameObject.SetActive(false);
            _buttonNext.gameObject.SetActive(true);
        }

        private void ClearElements()
        {
            foreach (var element in _activeElements)
            {
                Destroy(element.gameObject);
            }
            _activeElements.Clear();
        }

        private void OnDisable()
        {
            _buttonBack.onClick.RemoveListener(ScreenService.OpenScreenMenu);
            _buttonNext.onClick.RemoveListener(NextObjects);
            _buttonPrev.onClick.RemoveListener(BackData);
        }
    }
}