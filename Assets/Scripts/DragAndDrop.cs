using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;

    private Vector3 _offset;
    private bool _isDragging;

    public bool IsDragging => _isDragging;

    private void OnMouseDown()
    {
        _isDragging = true;
        _offset = transform.position - GetCursorWorldPosToDragObject();
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }

    private void OnMouseDrag()
    {
        transform.position = GetCursorWorldPosToDragObject() + _offset;
    }

    //Получаем мировые координаты курсора
    private Vector3 GetCursorWorldPosToDragObject()
    {
        var mousePosistion = Input.mousePosition;

        mousePosistion.z = playerCamera.WorldToScreenPoint(transform.position).z; //Глубина
        return playerCamera.ScreenToWorldPoint(mousePosistion);
    }
}
