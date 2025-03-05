using UnityEngine;

public class PropsLogic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _appleRb;
    [SerializeField] private DragAndDrop _dragAndDrop;

    private void OnTriggerStay2D(Collider2D collider)
    {
        CheckAppleOnProp(_appleRb, _dragAndDrop);   
    }

    private void CheckAppleOnProp(Rigidbody2D appleRb, DragAndDrop dragAndDrop)
    {
        //Если пользователь не двигает объект, тогда "замораживаем" его значения координат и поворота (с помощью rigidbody).
        //Иначе проверяем, блокировалась ли ранее позиция. Если да, то задаем константы по умолчанию.
        if (dragAndDrop.IsDragging is false)
        {
            appleRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            if (appleRb.constraints == RigidbodyConstraints2D.FreezeAll) appleRb.constraints = RigidbodyConstraints2D.None;
        }
    }
}