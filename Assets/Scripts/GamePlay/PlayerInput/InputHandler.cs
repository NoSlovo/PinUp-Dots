using UnityEngine;

public class InputHandler
{
    private Camera _mainCamera;

    public InputHandler(Camera mainCamera)
    {
        _mainCamera = mainCamera;
    }

    public Vector3 GetClikcPoint()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            
             RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.TryGetComponent(out Point point))
            {
                Debug.Log("Попали в точку");
                return point.RectTransform.position;
            }
        }

        return Vector3.zero;
    }
}