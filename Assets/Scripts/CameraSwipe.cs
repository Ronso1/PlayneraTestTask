using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    [SerializeField] private DragAndDrop _dragAndDrop;
    [SerializeField] private float dragSpeed = 0.5f; // Скорость перемещения камеры
    [SerializeField] private Vector2 minPosition; // Минимальная граница камеры (X, Y)
    [SerializeField] private Vector2 maxPosition; // Максимальная граница камеры (X, Y)

    private Vector3 _dragOrigin; // Начальная точка касания/нажатия
    private bool _isSwipping = false; // Флаг для отслеживания состояния перетаскивания

    private void Update()
    {
        SwipeScreen();
    }

    private void SwipeScreen()
    {
        if (Input.GetMouseButton(0) is false || _dragAndDrop.IsDragging) return;

        if (Input.GetMouseButtonDown(0)) // Прикосновение/нажатие
        {
            _dragOrigin = GetWorldPosition();
            _isSwipping = true;
        }

        if (Input.GetMouseButton(0) && _isSwipping) // Перемещение пальцем/мышью
        {
            Vector3 difference = _dragOrigin - GetWorldPosition();
            MoveCamera(difference);
        }

        if (Input.GetMouseButtonUp(0)) // Отпускание пальца/мыши
        {
            _isSwipping = false;
        }
    }

    // Получаем мировые координаты точки касания/нажатия
    private Vector3 GetWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Двигаем камеру и ограничиваем её положение
    void MoveCamera(Vector3 difference)
    {
        Vector3 newPosition = transform.position + difference * dragSpeed;

        // Ограничиваем координаты в пределах min/max
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        transform.position = newPosition;
    }
}
