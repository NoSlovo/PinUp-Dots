using System.Collections.Generic;
using UnityEngine;

public class LineRendererBetweenPoints : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private List<Vector3> _template;
    [SerializeField] private List<Vector3> _positionsPoints = new();
    
    private InputHandler _inputHandler;


    private void Awake() => _inputHandler = new InputHandler(_mainCamera);

    private void Update()
    {
        var pointClick = _inputHandler.GetClikcPoint();

        if (pointClick != Vector3.zero)
        {
            AddPointClick(pointClick);
        }

        if (_template == _positionsPoints)
        {
            Debug.Log("Победа");
        }
    }

    private void AddPointClick(Vector3 pointClick)
    {
        if (_positionsPoints.Count > 0)
            if (CheckPositions(pointClick))
            {
                Debug.Log("Попали в туже самую точку ");
                return;
            }

        Debug.Log("Добавили новую точку");
        _positionsPoints.Add(pointClick);
        _lineRenderer.positionCount = _positionsPoints.Count;
        _lineRenderer.SetPosition(_positionsPoints.Count - 1, _positionsPoints[_positionsPoints.Count - 1]);
    }

    private bool CheckPositions(Vector3 position)
    {
        if (position == _positionsPoints[_positionsPoints.Count - 1])
            return true;

        return false;
    }
}