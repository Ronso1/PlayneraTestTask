using UnityEngine;

public class CameraSwipe : MonoBehaviour
{
    [SerializeField] private DragAndDrop _dragAndDrop;
    [SerializeField] private float dragSpeed = 0.5f; // �������� ����������� ������
    [SerializeField] private Vector2 minPosition; // ����������� ������� ������ (X, Y)
    [SerializeField] private Vector2 maxPosition; // ������������ ������� ������ (X, Y)

    private Vector3 _dragOrigin; // ��������� ����� �������/�������
    private bool _isSwipping = false; // ���� ��� ������������ ��������� ��������������

    private void Update()
    {
        SwipeScreen();
    }

    private void SwipeScreen()
    {
        if (Input.GetMouseButton(0) is false || _dragAndDrop.IsDragging) return;

        if (Input.GetMouseButtonDown(0)) // �������������/�������
        {
            _dragOrigin = GetWorldPosition();
            _isSwipping = true;
        }

        if (Input.GetMouseButton(0) && _isSwipping) // ����������� �������/�����
        {
            Vector3 difference = _dragOrigin - GetWorldPosition();
            MoveCamera(difference);
        }

        if (Input.GetMouseButtonUp(0)) // ���������� ������/����
        {
            _isSwipping = false;
        }
    }

    // �������� ������� ���������� ����� �������/�������
    private Vector3 GetWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // ������� ������ � ������������ � ���������
    void MoveCamera(Vector3 difference)
    {
        Vector3 newPosition = transform.position + difference * dragSpeed;

        // ������������ ���������� � �������� min/max
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        transform.position = newPosition;
    }
}
