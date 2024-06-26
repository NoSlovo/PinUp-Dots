using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private RectTransform _rectTransform;

    public RectTransform RectTransform => _rectTransform;
}